using BlazorMqttDatabase.Services;
using SimpleMqtt;
public class MqttMessageProcessingService : IHostedService
{
    private readonly SimpleMqttClient _mqttClient;
    public MqttMessageProcessingService(SimpleMqttClient mqttClient)
    {
      	_mqttClient = mqttClient;
        _mqttClient.OnMessageReceived += (sender, args) => {
            Console.WriteLine($"Incoming MQTT message on {args.Topic}:{args.Message}");
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

