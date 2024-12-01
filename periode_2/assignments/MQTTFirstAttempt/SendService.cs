using SimpleMqtt;
public static class SendService 
{
   public async static Task<bool> SendMessage(string topic, string message)
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
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fout bij het verzenden van een bericht: {ex.Message}");
            return false;
        }
    }

}