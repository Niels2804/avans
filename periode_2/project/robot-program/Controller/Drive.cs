using Avans.StatisticalRobot;
using SensorLibrary;
using UltrasonicLibrary;
using SoundLibrary;

namespace RobotMotors
{
    public class DrivingController : Sensors
    {
        private bool HasPermissionToDrive {get; set;}
        private bool RobotIsCurrentlyDriving {get; set;}
        public DrivingController()
        {
            HasPermissionToDrive = false;
            RobotIsCurrentlyDriving = false;
        }
        public void GrantPermissionToDrive() => HasPermissionToDrive = true;
        public void RevokePermissionToDrive() => HasPermissionToDrive = false;
        public bool StatusPermissionToDrive() => HasPermissionToDrive;

        public async Task Drive()
        {   
            while(HasPermissionToDrive)
            {
                await PlayAnnouncement($"Warning", Mentions.Warning);
                await PlayAnnouncement($"Robot starts \ndriving", Mentions.Start);

                while (!ultrasonicSensors.IsObstacleDetected() && HasPermissionToDrive) 
                {
                    if(!RobotIsCurrentlyDriving)
                    {
                        Robot.Motors(100, 106); // Right motor needs more power to drive straight forward
                        RobotIsCurrentlyDriving = true;

                        lcdTextAnimation.StartDrivingAnimation();
                        _ = Task.Run(lcdTextAnimation.DrivingAnimation);                    
                    }
                    await Task.Delay(50); // Prevents CPU-overload
                }

                if (!HasPermissionToDrive)
                {
                    break;
                }

                await ObstacleDetectedHandler();
            }

            // Clean-up and stops the robot driving
            DrivingReset();
            await PlayAnnouncement($"Robot stopped \ndriving", Mentions.Stop);
        }

        private async Task ObstacleDetectedHandler()
        {
            DrivingReset();
            await PlayAnnouncement("Obstacle \ndetected", Mentions.ObstacleDetected);

            int rotationTime = ultrasonicSensors.triggeredEmergencySensor switch
            {
                SensorPosition.FrontCenter or SensorPosition.BackCenter => 650,
                SensorPosition.FrontRight or SensorPosition.FrontLeft => 325,
                _ => throw new InvalidOperationException("No driving direction is set!")
            };
            
            // Robot always turns right preventing for driving circles
            Robot.Motors(90, -90);
            Robot.Wait(rotationTime);
            Robot.Motors(0, 0);
            
            await PlayAnnouncement("Continuing driving...");
            Robot.Wait(500);   
        }

        private async Task PlayAnnouncement(string lcdMessage, Mentions? mention = null)
        {
            lcd.SetText(lcdMessage);
            if(mention.HasValue)
            {
                await Task.Run(() => speaker.PlayMusic((Mentions)mention));
            }
        }

        // Cleans up the driving functionality
        private void DrivingReset()
        {
            Robot.Motors(0, 0);
            RobotIsCurrentlyDriving = false;
            lcdTextAnimation.CancelDrivingAnimation();
        }
    }
}