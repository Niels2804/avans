using Avans.StatisticalRobot;
using RobotMotors;
using SensorLibrary;

namespace RompiRobot
{
    public class Program { 
        private static Rompi _rompiRobot {get; set;}
        private static DrivingController _drivingController {get; set;}
        static Program()
        {
            _rompiRobot = new Rompi("Wall-E");
            _drivingController = new DrivingController();
        }

        public static async Task Main() {
            _drivingController.hasPermissionToDrive = true;
            Task backgroundJob = Task.Run(_drivingController.Drive);
            Robot.Wait(120000);
            _drivingController.hasPermissionToDrive = false;
            await backgroundJob;
        }    
    }
}




