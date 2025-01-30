using System.Text;
using SensorLibrary;
using SimpleMqtt;
using SoundLibrary;

namespace LCDScreen 
{
    // This class has different type of text animation what will show on the LCD display
    public class TextAnimation : Sensors
    {
        private bool DrivingAnimationIsActive {get; set;}
        private bool CountDownAnimationIsActive {get; set;}
        public TextAnimation()
        {
            DrivingAnimationIsActive = false;
            CountDownAnimationIsActive = false;
        }
        public void StartCountDownAnimation() => CountDownAnimationIsActive = true;
        public void CancelCountDownAnimation() => CountDownAnimationIsActive = false;
        public bool StatusCountDownAnimation() => CountDownAnimationIsActive;
        public void StartDrivingAnimation() => DrivingAnimationIsActive = true;
        public void CancelDrivingAnimation() => DrivingAnimationIsActive = false;
        public async Task DrivingAnimation()
        {
            int countingDots = 0;
            // This loop stills running while the robot is driving
            while(DrivingAnimationIsActive) 
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

        public async Task CountDown30(SimpleMqttClient mqttClient)
        {
            await speaker.PlayMusic(Mentions.Remaining30); // Announcement
            _ = Task.Run(() => speaker.PlayMusic(Mentions.Portal)); // Playing background music while the timer is running
            
            // 30 seconds countdown loop animation
            for(int i = 30; i > 0; i--) 
            {
                if(!CountDownAnimationIsActive) 
                {
                    break;
                } 

                // Starts 3, 2, 1 countdown announcement
                if(i == 3) 
                {
                    speaker.StopMusic();
                    _ = Task.Run(() => speaker.PlayMusic(Mentions.CountDown321));
                } 

                // Prints current countdown timer on the LCD screen
                _ = Task.Run(led.Blink);
                lcd.SetText(i.ToString());
                await Task.Delay(750);

                // Clean-up LCD screen
                lcd.SetText("");
                await Task.Delay(250);
            }

            // Clean-up
            speaker.StopMusic();
            if(!CountDownAnimationIsActive)
            {
                lcd.SetText("Robot is \ngeheractiveerd");
                await speaker.PlayMusic(Mentions.RobotActive);
            } 
            else 
            {
                lcd.SetText("Robot is \ngedeactiveerd");
                await mqttClient.PublishMessage($"robotDeactivated|true", "robot");
                await speaker.PlayMusic(Mentions.Warning);
                await speaker.PlayMusic(Mentions.Shutdown);
            }
            lcdTextAnimation.CancelCountDownAnimation();
        }
    }
}