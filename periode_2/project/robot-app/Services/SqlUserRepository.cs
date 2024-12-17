using System;
using Microsoft.Data.SqlClient;

namespace BlazorMqttDatabase.Services;

public class SqlUserRepository : IUserRepository
{
    public void InsertUser(User user)
    {
        // Reading .env file and building a connection string
        EnvReader.Load(".env");
        var builder = new SqlConnectionStringBuilder
        {
            DataSource = Environment.GetEnvironmentVariable("DB_SERVER").Trim('\''),
            InitialCatalog = Environment.GetEnvironmentVariable("DB_DATABASE").Trim('\''),
            UserID = Environment.GetEnvironmentVariable("DB_UID").Trim('\''),
            Password = Environment.GetEnvironmentVariable("DB_PASSWORD").Trim('\''),
            TrustServerCertificate = bool.Parse(Environment.GetEnvironmentVariable("DB_TRUSTSERVERCERTIFICATE").Trim('\''))
        };

        using (var connection = new SqlConnection(builder.ConnectionString))
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