using Avans.StatisticalRobot;
using SensorLibrary;
using UltrasonicLibrary;
using LCDScreen;

namespace RobotMotors
{
    public class DrivingController : Sensors
    {
        public bool hasPermissionToDrive {get; set;}
        private bool _robotIsCurrentlyDriving;
        public DrivingController()
        {
            _robotIsCurrentlyDriving = false;
        }

        public async Task Drive()
        {   
            while(hasPermissionToDrive)
            {
                while (!ultrasonicSensors.IsObstacleDetected() && hasPermissionToDrive) 
                {
                    if(!_robotIsCurrentlyDriving)
                    {
                        Robot.Motors(100, 100);
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
                lcd.SetText("Obstacle \ndetected");

                // Robot always turns right preventing for driving circles
                switch (ultrasonicSensors.triggeredEmergencySensor)
                {
                    case SensorPosition.FrontCenter:
                    case SensorPosition.BackCenter:
                        Robot.Motors(90, -90);
                        Robot.Wait(600);
                        break;
                    case SensorPosition.FrontRight:
                    case SensorPosition.FrontLeft:
                        Robot.Motors(90, -90);
                        Robot.Wait(300);
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

            Console.WriteLine($"Robot stopped driving");
            lcd.SetText("Robot stopped \ndriving");
        }
    }
}