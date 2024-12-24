using Avans.StatisticalRobot;
using RobotMotors;
using SensorLibrary;
using Speaker.Sound;

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
            // _drivingController.hasPermissionToDrive = true;
            // Task backgroundJob = Task.Run(_drivingController.Drive);
            await new Music().PlayMusic();
            // Robot.Wait(5000);
            // _drivingController.hasPermissionToDrive = false;
            // await backgroundJob;
        }    
    }
}




