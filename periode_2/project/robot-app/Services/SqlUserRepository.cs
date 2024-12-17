using System;
using Microsoft.Data.SqlClient;

namespace BlazorMqttDatabase.Services;

public class SqlUserRepository : IUserRepository
{
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
        } catch (Exception e) {
            Console.WriteLine($"Failed to build a SqlConnectionString: {e}");
            return "";
        }
    }

    private async void InsertUser(User user)
    {
        try {
            using (var connection = new SqlConnection(BuildSqlConnectionString()))
            {
                await connection.OpenAsync();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $"INSERT INTO [User] (Name, Age, IsActive) VALUES (@Name, @Age, @IsActive)"; 
                    command.Parameters.AddWithValue("@Name", user.Name);
                    command.Parameters.AddWithValue("@Age", user.Age);
                    command.Parameters.AddWithValue("@IsActive", user.IsActive);
                    await command.ExecuteNonQueryAsync();
                }
                await connection.CloseAsync();
            }
        } catch (Exception e) {
            Console.WriteLine($"Failed to insert an user to the database: {e}");
        }
    }

    public List<User> GetAllUsers()
    {
        throw new NotImplementedException();
    }

    public void SaveUser(User user)
    {
        InsertUser(user);
    }
}