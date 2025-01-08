using BlazorMqttDatabase.Services;
using SimpleMqtt;
public class MqttMessageProcessingService : IHostedService
{
    private readonly IUserRepository _userRepository;    
    private readonly SimpleMqttClient _mqttClient;
    public MqttMessageProcessingService(IUserRepository userRepository, SimpleMqttClient mqttClient)
    {
      	_mqttClient = mqttClient;
        _userRepository = userRepository;  
        _mqttClient.OnMessageReceived += (sender, args) => {
            Console.WriteLine($"Incoming MQTT message on {args.Topic}:{args.Message}");
        };
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        
        await _mqttClient.SubscribeToTopic("Wall-E");
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        _mqttClient.Dispose();  
    }
}

