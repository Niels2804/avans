using SimpleMqtt;

namespace MessageService
{
    public class ResponseService 
    {
        public async Task<bool> ReceiveMessage(string topic)
        {
            try
            {
                var client = SimpleMqttClient.CreateSimpleMqttClientForHiveMQ(topic);
                await client.SubscribeToTopic(topic);
                client.OnMessageReceived += (sender, args) =>
                {
                    Console.WriteLine($"Bericht ontvangen; topic={args.Topic}; message={args.Message}");
                };
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fout bij het verzenden van een bericht: {ex.Message}");
                return false;
            }
        }
    }

    public class SendService 
    {
        public async Task<bool> SendMessage(string message, string topic)
        {
            try
            {
                var client = SimpleMqttClient.CreateSimpleMqttClientForHiveMQ(topic);
                await client.PublishMessage(message, topic);                
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fout bij het verzenden van een bericht: {ex.Message}");
                return false;
            }
        }
    }
}
