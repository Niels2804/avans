namespace Mqtt 
{
    public class Data 
    {
        public static List<string> motionDetectedData {get; set;}
        public static List<(TimeSpan, int)> reminders {get; set;} // int references to the mention type
        static Data()
        {
            motionDetectedData = new List<string>();
            reminders = new List<(TimeSpan, int)>();
        }
    }
}