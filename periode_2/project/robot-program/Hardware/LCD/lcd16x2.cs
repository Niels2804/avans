using System.Text;
using Avans.StatisticalRobot;
using SensorLibrary;

namespace LCDScreen 
{
    public static class DrivingTextAnimation
    {
        public static bool isActive {get; set;}
        public async static Task Play()
        {
            int countingDots = 0;
            while(isActive) 
            {
                StringBuilder textBuilder = new StringBuilder("Driving");
                int maxDots = 3;
                countingDots = (countingDots % maxDots) + 1;

                for (int i = 0; i < countingDots; i++)
                {
                    textBuilder.Append('.');
                }
                await Task.Delay(1000);
                Sensors.lcd.SetText(textBuilder.ToString());
            }
        }
    }
}