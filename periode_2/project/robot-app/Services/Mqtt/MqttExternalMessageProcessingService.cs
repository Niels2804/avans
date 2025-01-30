using BlazorMqttDatabase.Services;
using SimpleMqtt;
public class MqttExternalMessageProcessingService : IHostedService
{
    private MqttData _mqttData;
    public event EventHandler<bool> RobotFinishedMentionCallback;
    private readonly SimpleMqttClient _mqttClient;
    public MqttExternalMessageProcessingService(SimpleMqttClient mqttClient, MqttData mqttData)
    {
      	_mqttClient = mqttClient;
        _mqttData = mqttData;
    }

    // Trigger het event wanneer de robot klaar is met de vermelding
    public virtual void OnRobotFinishedMention()
    {
        RobotFinishedMentionCallback?.Invoke(this, _mqttData.RobotFinishedMention);
        _mqttData.RobotFinishedMention = false; // Reset to default
    }

    public async Task PublishMessageToRobot(string message, string key)
    {
        try 
        {
            string mqttMessage = key + "|" + message;
            await _mqttClient.PublishMessage(mqttMessage, "web");
            Console.WriteLine($"Het volgende bericht is verzonden naar de robot: {mqttMessage}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Er is iets misgegaan bij het verzenden van een bericht naar de robot: {ex}");
        }
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
    
    }
 
    public async Task StopAsync(CancellationToken cancellationToken)
    {
        _mqttClient.Dispose();  
    }
}

