namespace BlazorMqttDatabase.Services;
public class Timer 
{
    public int TimerId {get; set;}
    public DateTime Date {get; set;}
    public string Model {get; set;}
    public string Category {get; set;}
    public string? Comment {get; set;}
    public bool IsActive {get; set;}
}   