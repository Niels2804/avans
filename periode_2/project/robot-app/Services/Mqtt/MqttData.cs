namespace BlazorMqttDatabase.Services;
public class MqttData 
{
    public int BatteryVoltage {get; set;}
    public Dictionary<DateTime, bool> MotionData = new();
    public bool RobotFinishedMention {get; set;} = false;
}   