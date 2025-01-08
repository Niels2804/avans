using System;
using Microsoft.Data.SqlClient;

namespace BlazorMqttDatabase.Services;

public class SqlUserRepository : IUserRepository
{
    public void InsertUser(User user)
    {
        EnvReader.Load(".env");
        string server = Environment.GetEnvironmentVariable("DB_SERVER").Trim('\'');
        string database = Environment.GetEnvironmentVariable("DB_DATABASE").Trim('\'');
        string uid = Environment.GetEnvironmentVariable("DB_UID").Trim('\'');
        string password = Environment.GetEnvironmentVariable("DB_PASSWORD").Trim('\'');
        bool trustServerCertificate = bool.Parse(Environment.GetEnvironmentVariable("DB_TRUSTSERVERCERTIFICATE").Trim('\''));
        var sqlConnectionString = "Server=;Database=;UID=;Password=;TrustServerCertificate=;";

        using (var connection = new SqlConnection(sqlConnectionString))
        {
            connection.OpenAsync();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = $"INSERT INTO [User] (Name, Age, IsActive) VALUES (@Name, @Age, @IsActive)"; 
                command.Parameters.AddWithValue("@Name", user.Name);
                command.Parameters.AddWithValue("@Age", user.Age);
                command.Parameters.AddWithValue("@IsActive", user.IsActive);
                command.ExecuteNonQuery();
            }
            connection.CloseAsync();
        }
    }

    public List<User> GetAllUsers()
    {
        throw new NotImplementedException();
    }

    public void SaveUser(User user)
    {
        throw new NotImplementedException();
    }
}