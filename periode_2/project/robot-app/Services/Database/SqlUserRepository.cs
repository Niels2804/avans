using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;

namespace BlazorMqttDatabase.Services;

public class SqlUserRepository
{
    public User User {get; set;}
    public PersonalSettings PersonalSettings {get; set;}
    public Robot Robot {get; set;}
    public Dictionary<int, Timer> Timers {get; set;}
    public Dictionary<DateTime, Activity> Activities {get; set;}
    public SqlUserRepository()
    {
        User = new User();
        PersonalSettings = new PersonalSettings();
        Robot = new Robot();
        Timers = new Dictionary<int, Timer>();
        Activities = new Dictionary<DateTime, Activity>();
    }

    // Initializes all database data
    public async Task InitializeData() 
    {
        // Clear everything
        User = new User();
        PersonalSettings = new PersonalSettings();
        Robot = new Robot();
        Timers = new Dictionary<int, Timer>();
        Activities = new Dictionary<DateTime, Activity>();

        await RefreshUserData();
        await RefreshRobotData();
        await RefreshTimerData();
        await RefreshActivityData();
    }

    private T GetValueOrDefault<T>(Dictionary<string, object> row, string key, T defaultValue)
    {
        return row.ContainsKey(key) && row[key] != null
            ? (T)Convert.ChangeType(row[key], typeof(T))
            : defaultValue;
    }

    // Getting UserInfo
    private async Task RefreshUserData()
    {
        try {
            var userData = await GetTable("users", "INNER JOIN personal_settings ON users.personal_settings = personal_settings.personal_settings");
            if (userData.Any())
            {
                var row = userData.First(); // Only gets the first user
                User.Username = GetValueOrDefault(row, "username", "undefined");
                User.Password = GetValueOrDefault(row, "password", "undefined");
                User.PersonalSettingsId = int.TryParse(GetValueOrDefault(row, "personal_settings", "0"), out var personalSettingsId) ? personalSettingsId : 0;

                PersonalSettings.PersonalSettingsId = User.PersonalSettingsId;
                PersonalSettings.DarkMode = GetValueOrDefault(row, "dark_mode", "0") == "1";
                PersonalSettings.Notifications = GetValueOrDefault(row, "notifications", "1") == "1";
                PersonalSettings.BigFontSize = GetValueOrDefault(row, "big_font_size", "0") == "1";
            } 
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to get USER info: {ex.Message}");      
        } 
    }

    // Getting robot info
    private async Task RefreshRobotData()
    {
        try {
            var robotData = await GetTable("robot");
            if (robotData.Any())
            {
                var row = robotData.First(); // Only gets the first robot
                Robot.Model = GetValueOrDefault(row, "model", "undefined");
                Robot.Username = GetValueOrDefault(row, "username", "undefined");
                Robot.NetworkName = GetValueOrDefault(row, "network_name", "undefined");
                Robot.IsActive = GetValueOrDefault(row, "is_active", "1") == "1";
            }
        } 
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to get ROBOT info: {ex.Message}");      
        }
    }

    // Getting timers
    private async Task RefreshTimerData()
    {
        try {
            var timerData = await GetTable("timers");
            if (timerData.Any())
            {
                foreach(var row in timerData) {
                    Timer timer = new Timer();
                    timer.TimerId = int.TryParse(GetValueOrDefault(row, "timer_id", "0"), out var timerId) ? timerId : 0;
                    timer.Date = Convert.ToDateTime(GetValueOrDefault(row, "date", "2025-00-00 00:00:00"));
                    timer.Model = GetValueOrDefault(row, "model", "undefined");
                    timer.Category = GetValueOrDefault(row, "category", "undefined");
                    timer.Comment = GetValueOrDefault(row, "comment", "undefined");
                    timer.IsActive = GetValueOrDefault(row, "is_active", "0") == "1";
                    Timers.Add(timer.TimerId, timer);
                }
            }
        } 
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to get TIMER info: {ex.Message}");
        }
    }

    // Getting activity data
    private async Task RefreshActivityData()
    {
        try {
            var activityData = await GetTable("activity");
            if (activityData.Any())
            {
                foreach(var row in activityData) {
                    Activity activity = new Activity();
                    activity.Date = Convert.ToDateTime(GetValueOrDefault(row, "date", "2025-00-00 00:00:00"));
                    activity.Model = GetValueOrDefault(row, "model", "undefined");
                    activity.Comment = GetValueOrDefault(row, "comment", "undefined");
                    Activities.Add(activity.Date, activity);
                }
            }
        } 
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to get ACTIVITY info: {ex.Message}");               
        }
    }

    // Reads .env file and building a connection string
    private string BuildSqlConnectionString() 
    {
        try {
            EnvReader.Load(".env");
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = Environment.GetEnvironmentVariable("DB_SERVER").Trim('\''),
                InitialCatalog = Environment.GetEnvironmentVariable("DB_DATABASE").Trim('\''),
                UserID = Environment.GetEnvironmentVariable("DB_UID").Trim('\''),
                Password = Environment.GetEnvironmentVariable("DB_PASSWORD").Trim('\''),
                TrustServerCertificate = bool.Parse(Environment.GetEnvironmentVariable("DB_TRUSTSERVERCERTIFICATE").Trim('\''))
            };
            return builder.ConnectionString;
        } catch (Exception ex) {
            Console.WriteLine($"Failed to build a SqlConnectionString: {ex}");
            return "";
        }
    }

    // SELECT

    // OUTPUT van GetTable() = [{"kolom" => object, "kolom" => object, "kolom" => object}, {"kolom" => object, "kolom" => object, "kolom" => object}]
    private async Task<List<Dictionary<string, object>>> GetTable(string table, string? innerJoin = null)
    {
        var result = new List<Dictionary<string, object>>();
        try {
            if (string.IsNullOrWhiteSpace(table)) 
            {
                throw new ArgumentException("Table name cannot be null or empty.");
            }

            using (var connection = new SqlConnection(BuildSqlConnectionString()))
            {
                await connection.OpenAsync();
                using (var command = connection.CreateCommand())
                {   
                    // Builds command by innerjoin value
                    if(innerJoin.IsNullOrEmpty()) {
                        command.CommandText = $"SELECT * FROM {table}"; 
                    } else {
                        command.CommandText = $"SELECT * FROM {table} {innerJoin}"; 
                    }

                    // Reads the output
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var row = new Dictionary<string, object>();

                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                row[reader.GetName(i)] = reader.GetValue(i); // {"key" => value}
                            }
                            result.Add(row); // [] += {"key" => value}
                        }
                    }
                }
                await connection.CloseAsync();
            }
        } catch (Exception ex) {
            Console.WriteLine($"Failed to retrieve data from table '{table}': {ex.Message}");
        }
        return result;
    }

    // UPDATE

    public async Task UpdatePersonalSettings()
    {
        try {
            using (var connection = new SqlConnection(BuildSqlConnectionString()))
            {
                await connection.OpenAsync();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $"UPDATE personal_settings SET dark_mode = @DarkMode, notifications = @Notifications, big_font_size = @BigFontSize WHERE personal_settings = @PersonalSettingsId"; 
                    command.Parameters.AddWithValue("@PersonalSettingsId", PersonalSettings.PersonalSettingsId);    
                    command.Parameters.AddWithValue("@DarkMode", PersonalSettings.DarkMode);    
                    command.Parameters.AddWithValue("@Notifications", PersonalSettings.Notifications);
                    command.Parameters.AddWithValue("@BigFontSize", PersonalSettings.BigFontSize);
                    await command.ExecuteNonQueryAsync();
                }
                await connection.CloseAsync();
            }
        } catch (Exception ex) {
            Console.WriteLine($"Failed to UPDATE the personal settings: {ex}");
        }
    }

    public async Task UpdateTimer(Timer timer)
    {
        try {
            using (var connection = new SqlConnection(BuildSqlConnectionString()))
            {
                await connection.OpenAsync();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $"UPDATE timers SET date = @Date, model = @Model, category = @Category, comment = @Comment, is_active = @IsActive WHERE timer_id = @TimerId"; 
                    command.Parameters.AddWithValue("@TimerId", timer.TimerId);    
                    command.Parameters.AddWithValue("@Date", timer.Date);    
                    command.Parameters.AddWithValue("@Model", Robot.Model);    
                    command.Parameters.AddWithValue("@Category", timer.Category);    
                    command.Parameters.AddWithValue("@Comment", timer.Comment);    
                    command.Parameters.AddWithValue("@IsActive", timer.IsActive);    
                    await command.ExecuteNonQueryAsync();
                }
                await connection.CloseAsync();
            }
        } catch (Exception ex) {
            Console.WriteLine($"Failed to UPDATE the timer: {ex}");
        }
    }

    public async Task UpdateTimerStatus(int timerId, bool status)
    {
        try {
            using (var connection = new SqlConnection(BuildSqlConnectionString()))
            {
                await connection.OpenAsync();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $"UPDATE timers SET is_active = @IsActive WHERE timer_id = @TimerId"; 
                    command.Parameters.AddWithValue("@IsActive", status);    
                    command.Parameters.AddWithValue("@TimerId", timerId);    
                    await command.ExecuteNonQueryAsync();
                }
                await connection.CloseAsync();
            }
        } catch (Exception ex) {
            Console.WriteLine($"Failed to UPDATE the timer is_active: {ex}");
        }
    }

    public async Task UpdateRobotActivity(bool status)
    {
        try {
            using (var connection = new SqlConnection(BuildSqlConnectionString()))
            {
                await connection.OpenAsync();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $"UPDATE robot SET is_active = @IsActive WHERE model = @RobotId"; 
                    command.Parameters.AddWithValue("@IsActive", status);    
                    command.Parameters.AddWithValue("@RobotId", Robot.Model);    
                    await command.ExecuteNonQueryAsync();
                }
                await connection.CloseAsync();
            }
        } catch (Exception ex) {
            Console.WriteLine($"Failed to UPDATE the ROBOT is_active: {ex}");
        }
    }

    // INSERT

    public async Task AddNewTimer(Timer timer)
    {
        try {
            using (var connection = new SqlConnection(BuildSqlConnectionString()))
            {
                await connection.OpenAsync();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $"INSERT INTO timers (date, model, category, comment, is_active) VALUES (@Date, @Model, @Category, @Comment, @IsActive)"; 
                    command.Parameters.AddWithValue("@Date", timer.Date);    
                    command.Parameters.AddWithValue("@Model", Robot.Model);    
                    command.Parameters.AddWithValue("@Category", timer.Category);    
                    command.Parameters.AddWithValue("@Comment", timer.Comment);    
                    command.Parameters.AddWithValue("@IsActive", timer.IsActive);    
                    await command.ExecuteNonQueryAsync();
                }
                await connection.CloseAsync();
            }
        } catch (Exception ex) {
            Console.WriteLine($"Failed to INSERT a new timer: {ex}");
        }
    }

    // DELETE
    public async Task DeleteTimer(int timerId)
    {
        try
        {
            using (var connection = new SqlConnection(BuildSqlConnectionString()))
            {
                await connection.OpenAsync();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM Timers WHERE timer_id = @TimerId"; 
                    command.Parameters.AddWithValue("@TimerId", timerId);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to DELETE timer {timerId}: {ex}");
        }
    }
}