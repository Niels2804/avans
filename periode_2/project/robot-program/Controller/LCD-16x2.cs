using System.Text;
using SensorLibrary;
using SoundLibrary;

namespace LCDScreen 
{
    public class TextAnimation : Sensors
    {
        public static bool isActive {get; set;}
        public async static Task DrivingAnimation()
        {
            int countingDots = 0;
            // Loop is running while robot is driving
            while(isActive) 
            {
                // Building a "Driving..." animation
                StringBuilder textBuilder = new StringBuilder("Driving");
                int maxDots = 3;
                countingDots = (countingDots % maxDots) + 1;

                for (int i = 0; i < countingDots; i++)
                {
                    textBuilder.Append('.');
                }
                await Task.Delay(1000);
                lcd.SetText(textBuilder.ToString());
            }
        }

        public async static Task CountDown60()
        {
            _ = Task.Run(() => speaker.PlayMusic(Mentions.Portal));

            // 1 minute countdown loop
            for(int i = 0; i < 60; i++) 
            {
                // Starts 3, 2, 1 countdown
                if(i == 4) 
                {
                    speaker.StopMusic();
                    _ = Task.Run(() => speaker.PlayMusic(Mentions.CountDown321));
                } 

                // Prints current countdown on LCD screen
                lcd.SetText(i.ToString());
                await Task.Delay(750);

                // Clean-up LCD screen
                lcd.SetText("");
                await Task.Delay(250);
            }

            // Clean-up
            speaker.StopMusic();
            lcd.SetText("Robot is \ngedeactiveerd");
        }
    }
}