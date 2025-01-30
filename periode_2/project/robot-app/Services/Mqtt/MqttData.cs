namespace BlazorMqttDatabase.Services;
public class MqttData 
{
    public bool RobotDeactivated {get; set;}
    public int BatteryVoltage {get; set;}
    public Dictionary<DateTime, bool> MotionData = new();
    public bool RobotFinishedMention {get; set;} = false;
    public Dictionary<string, object> dataHistory = new Dictionary<string, object>();
}   