using SimpleMqtt;

namespace MessageService
{
    public class ResponseService 
    {
        public async Task ReceiveMessage(string topic, string message)
        {
            try
            {
                var client = SimpleMqttClient.CreateSimpleMqttClientForHiveMQ(topic);
                client.OnMessageReceived += (sender, args) =>
                {
                    Console.WriteLine($"Bericht ontvangen; topic={args.Topic}; message={args.Message}");
                };
                await client.SubscribeToTopic(topic);
                await client.PublishMessage(message, topic);                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fout bij het ontvangen van een bericht: {ex.Message}");
            }
        }
    }

    public class SendService 
    {
        public async Task SendMessage(string message, string topic)
        {
            try
            {
                var client = SimpleMqttClient.CreateSimpleMqttClientForHiveMQ(topic);
                await client.PublishMessage(message, topic);                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fout bij het verzenden van een bericht: {ex.Message}");
            }
        }
    }
}
