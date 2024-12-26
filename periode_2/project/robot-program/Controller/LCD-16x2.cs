using System.Text;
using SensorLibrary;
using SoundLibrary;

namespace LCDScreen 
{
    public class TextAnimation : Sensors
    {
        public static bool isActive {get; set;}
        public static bool countDownIsCanceled {get; set;}
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
            Task countDownMention = Task.Run(() => speaker.PlayMusic(Mentions.Remaining30));
            await countDownMention;
            _ = Task.Run(() => speaker.PlayMusic(Mentions.Portal));
            
            // 30 seconds countdown loop
            for(int i = 30; i > 0; i--) 
            {
                if(!countDownIsCanceled) 
                {
                    // Starts 3, 2, 1 countdown
                    if(i == 3) 
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
                } else {
                    break;
                }
            }

            // Clean-up
            speaker.StopMusic();
            if(countDownIsCanceled)
            {
                lcd.SetText("Robot is \ngeheractiveerd");
                await speaker.PlayMusic(Mentions.RobotActive);
            } else {
                lcd.SetText("Robot is \ngedeactiveerd");
                await speaker.PlayMusic(Mentions.Warning);
                await speaker.PlayMusic(Mentions.Shutdown);
            }
        }
    }
}