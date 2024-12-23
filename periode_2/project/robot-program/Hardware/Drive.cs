using Avans.StatisticalRobot;
using SensorLibrary;
using UltrasonicLibrary;
using LCDScreen;

namespace RobotMotors
{
    public class DrivingController
    {
        public bool hasPermissionToDrive {get; set;}
        private bool _robotIsCurrentlyDriving;
        private readonly UltrasonicDistance _ultrasonicSensors;

        public DrivingController()
        {
            _robotIsCurrentlyDriving = false;
            _ultrasonicSensors = Sensors.ultrasonicSensors;
        }

        public async Task Drive()
        {   
            while(hasPermissionToDrive)
            {
                while (!_ultrasonicSensors.IsObstacleDetected() && hasPermissionToDrive) 
                {
                    if(!_robotIsCurrentlyDriving)
                    {
                        Robot.Motors(100, 100);
                        _robotIsCurrentlyDriving = true;
                        DrivingTextAnimation.isActive = true;
                        _ = Task.Run(DrivingTextAnimation.Play);                    
                    }
                    Robot.Wait(50); // Prevents CPU-overload
                }

                if (!hasPermissionToDrive)
                {
                    break;
                }

                Console.WriteLine($"Obstacle detected on the {_ultrasonicSensors.triggeredEmergencySensor}");
                DrivingTextAnimation.isActive = false;
                Robot.Motors(0, 0);
                Sensors.lcd.SetText("Obstacle \ndetected");
                _robotIsCurrentlyDriving = false;


                // Robot always turns right preventing for driving circles
                switch (_ultrasonicSensors.triggeredEmergencySensor)
                {
                    case SensorPosition.FrontCenter:
                    case SensorPosition.BackCenter:
                        Robot.Motors(90, -90);
                        Robot.Wait(650);
                        break;
                    case SensorPosition.FrontRight:
                    case SensorPosition.FrontLeft:
                        Robot.Motors(90, -90);
                        Robot.Wait(350);
                        break;
                    default:
                        throw new InvalidOperationException("No driving direction is set!");
                }        
                Robot.Motors(0, 0);
                Sensors.lcd.SetText("Continuing driving...");
                Robot.Wait(500);
            }

            Console.WriteLine($"Robot stopped driving");
            DrivingTextAnimation.isActive = false;
            Robot.Motors(0, 0);
            Sensors.lcd.SetText("Robot stopped \ndriving");
            _robotIsCurrentlyDriving = false;
        }
    }
}