namespace HiveMQtt.MessageService
{
    public class MessageData
    {
        public string Type {get; set;}
        public string Value {get; set;}
        public MessageData(string type, string value)
        {
            Type = type;
            Value = value;
        }
    }
}