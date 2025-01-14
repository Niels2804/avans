using BlazorMqttDatabase.Services;
using SimpleMqtt;
public class MqttMessageProcessingService : IHostedService
{
    private MqttData _mqttData;
    private readonly TimeZoneInfo _timeZone;
    private readonly SimpleMqttClient _mqttClient;
    private readonly object _lock = new object();
    public MqttMessageProcessingService(SimpleMqttClient mqttClient, MqttData mqttData, MqttExternalMessageProcessingService mqttExternalMessageProcessingService)
    {
      	_mqttClient = mqttClient;
        _timeZone = TimeZoneInfo.FindSystemTimeZoneById("Europe/Amsterdam");
        _mqttData = mqttData;

        _mqttClient.OnMessageReceived += (sender, args) => {
            Console.WriteLine($"Incoming MQTT message on {args.Topic}:{args.Message}");
            string[] message = args.Message.Split('|');
            string key = message[0];
            string value = message[1];
            
            lock (_lock) 
            {
                switch(key)
                {
                    case "batteryVoltage":
                        _mqttData.BatteryVoltage = int.TryParse(value, out int batteryVoltage) ? batteryVoltage : 0;
                        _mqttData.dataHistory.Add("batteryVoltage", _mqttData.BatteryVoltage);
                        break;
                    case "motionDetection":
                        DateTime currentTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, _timeZone);
                        _mqttData.MotionData[currentTime] = bool.TryParse(value, out bool motionDetected) ? motionDetected : false;
                        _mqttData.dataHistory.Add("motionDetection",  _mqttData.MotionData[currentTime]);
                        break;
                    case "taskFinished": 
                        _mqttData.RobotFinishedMention = bool.TryParse(value, out bool RobotFinishedMention) ? RobotFinishedMention : false;
                        if (_mqttData.RobotFinishedMention)
                        {
                            mqttExternalMessageProcessingService.OnRobotFinishedMention(); 
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid topic or topic not found");
                        break;
                }
            }
        };
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await _mqttClient.SubscribeToTopic("robot");
    }
 
    public async Task StopAsync(CancellationToken cancellationToken)
    {
        _mqttClient.Dispose();  
    }
}

