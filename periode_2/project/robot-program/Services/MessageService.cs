using SimpleMqtt;
using RompiRobotApp;
using HiveMQtt.MessageService;

namespace HiveMQtt.Service
{
    public class MessageService
    {
        private readonly string _topic;
        private readonly SimpleMqttClient _mqttClient;
        public event EventHandler<string> MessageReceived;

        public MessageService(string topic)
        {
            _topic = topic;
            _mqttClient = SimpleMqttClient.CreateSimpleMqttClientForHiveMQ(topic);
        }

        public async Task<string?> StartReceivingMessages()
        {
            var tcs = new TaskCompletionSource<string>(); // Dit is om te wachten op het bericht
            try
            {
                await _mqttClient.SubscribeToTopic(_topic);
                _mqttClient.OnMessageReceived += (sender, args) =>
                {
                    Console.WriteLine($"Bericht ontvangen; topic={args.Topic}; message={args.Message}");
                    string message = args.Message ?? "";

                     if (!tcs.Task.IsCompleted)
                    {
                        tcs.SetResult(message); 
                        MessageReceived?.Invoke(this, message);
                    }
                };

                Console.WriteLine("Berichtenluisteraar gestart.");

                // Wacht totdat er een bericht ontvangen is en return het bericht
                return await tcs.Task;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fout bij het starten van de berichtenluisteraar: {ex.Message}");
                return null; // In geval van een fout, return null
            }
        }

        public async Task StopReceivingMessages()
        {
            _mqttClient.OnMessageReceived -= (sender, args) => {}; // Ontkoppelen van de event
            Console.WriteLine("Berichtenluisteraar gestopt.");
        }

        public async Task SendMessage(string message)
        {
            try
            {
                await _mqttClient.PublishMessage(message, _topic);      
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fout bij het verzenden van een bericht: {ex.Message}");
            }
        }
    }
}
