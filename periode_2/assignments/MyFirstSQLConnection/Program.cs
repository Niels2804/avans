using System;
using Microsoft.Data.SqlClient;

EnvReader.Load(".env");

string server = Environment.GetEnvironmentVariable("DB_SERVER").Trim('\'');
string database = Environment.GetEnvironmentVariable("DB_DATABASE").Trim('\'');;
string uid = Environment.GetEnvironmentVariable("DB_UID").Trim('\'');;
string password = Environment.GetEnvironmentVariable("DB_PASSWORD").Trim('\'');;
bool trustServerCertificate = bool.Parse(Environment.GetEnvironmentVariable("DB_TRUSTSERVERCERTIFICATE").Trim('\''));

var sqlConnectionString = "Server=;Database=;UID=;Password=;TrustServerCertificate=;";

Console.WriteLine("Welke sport?");
var filterSport = Console.ReadLine();

using (var sqlConnection = new SqlConnection(sqlConnectionString)) {
    await sqlConnection.OpenAsync();
    var sqlCommand = sqlConnection.CreateCommand();
    sqlCommand.CommandText = "SELECT * FROM Sporter WHERE Sport = @FilterSport";

    SqlParameter param = new SqlParameter();
    param.ParameterName = "@FilterSport";
    param.Value = filterSport;
    sqlCommand.Parameters.Add(param);
    
    using(var sqlReader = await sqlCommand.ExecuteReaderAsync()) {
        List<Sporter> sporters = [];
        while(await sqlReader.ReadAsync()) {
            Sporter sporter = new Sporter();
            sporter.club = sqlReader.GetString(sqlReader.GetOrdinal("Club"));
            sporter.naam = sqlReader.GetString(sqlReader.GetOrdinal("Naam"));
            sporters.Add(sporter);
        }

        foreach(var sporter in sporters) {
            Console.WriteLine($"{sporter.naam} speelt bij {sporter.club}");
        }
    }

    await sqlConnection.CloseAsync();
}
