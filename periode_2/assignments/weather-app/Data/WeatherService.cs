using System;
using System.Net.Http;
using System.Text.Json.Nodes;
using DotNetEnv;

public class OpenWeatherService {
    public void GetWeatherData() {
        // Gets API key from .env
        EnvReader.Load(".env");
        var apiKey = Environment.GetEnvironmentVariable("API_KEY");
        Console.WriteLine($"API Key: {apiKey}");

        var client = new HttpClient();
        var city_name = "breda";
        var userURL = $"https://api.openweathermap.org/data/2.5/weather?q={city_name}&appid={apiKey}&units=imperial";
        
        var weatherResponse = client.GetStreamAsync(userURL).Result;
        var formattedResponseMain = JsonObject.Parse(weatherResponse);
        var formattedResponseTemp = formattedResponseMain?["main"]?["temp"];

        Console.WriteLine(formattedResponseTemp);
    }
}
