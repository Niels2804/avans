using Avans.StatisticalRobot;
using SensorLibrary;
using UltrasonicLibrary;
using LCDScreen;
using SoundLibrary;

namespace RobotMotors
{
    public class DrivingController : Sensors
    {
        public bool hasPermissionToDrive {get; set;}
        private bool _robotIsCurrentlyDriving;
        public DrivingController()
        {
            hasPermissionToDrive = true;
            _robotIsCurrentlyDriving = false;
        }

        public async Task Drive()
        {   
            while(hasPermissionToDrive)
            {
                Task warnMessage = Task.Run(() => speaker.PlayMusic(Mentions.Warning));
                await warnMessage;
                Task startMessage = Task.Run(() => speaker.PlayMusic(Mentions.Start));
                await startMessage;
                while (!ultrasonicSensors.IsObstacleDetected() && hasPermissionToDrive) 
                {

                    if(!_robotIsCurrentlyDriving)
                    {
                        Robot.Motors(100, 106
                        );
                        _robotIsCurrentlyDriving = true;
                        TextAnimation.isActive = true;
                        _ = Task.Run(TextAnimation.DrivingAnimation);                    
                    }
                    Robot.Wait(50); // Prevents CPU-overload
                }

                if (!hasPermissionToDrive)
                {
                    break;
                }

                Robot.Motors(0, 0);
                _robotIsCurrentlyDriving = false;
                TextAnimation.isActive = false;

                Console.WriteLine($"Obstacle detected on the {ultrasonicSensors.triggeredEmergencySensor}");
                Task obstacleMessage = Task.Run(() => speaker.PlayMusic(Mentions.ObstacleDetected));
                lcd.SetText("Obstacle \ndetected");
                await obstacleMessage;

                // Robot always turns right preventing for driving circles
                switch (ultrasonicSensors.triggeredEmergencySensor)
                {
                    case SensorPosition.FrontCenter:
                    case SensorPosition.BackCenter:
                        Robot.Motors(90, -90);
                        Robot.Wait(650);
                        break;
                    case SensorPosition.FrontRight:
                    case SensorPosition.FrontLeft:
                        Robot.Motors(90, -90);
                        Robot.Wait(325);
                        break;
                    default:
                        throw new InvalidOperationException("No driving direction is set!");
                }        
                Robot.Motors(0, 0);
                lcd.SetText("Continuing \ndriving...");
                Robot.Wait(500);
            }

            Robot.Motors(0, 0);
            _robotIsCurrentlyDriving = false;
            TextAnimation.isActive = false;

            Task finalMention = Task.Run(() => speaker.PlayMusic(Mentions.Stop));
            Console.WriteLine($"Robot stopped driving");
            lcd.SetText("Robot stopped \ndriving");
            await finalMention;
        }
    }
}