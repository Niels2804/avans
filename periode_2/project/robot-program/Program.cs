using System.Device.Gpio;
using Avans.StatisticalRobot;
using RobotMotors;
using SensorLibrary;
using SoundLibrary;

namespace RompiRobot
{
    public class Program : Sensors { 
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
            // Task backgroundJob = Task.Run(() => speaker.PlayMusic(Mentions.ObstacleDetected));
            // Robot.Wait(5000);
            // _drivingController.hasPermissionToDrive = false;
            // await backgroundJob;
            while (true) {
                led.SetOn();
                Robot.Wait(1000);
                led.SetOff();
                Robot.Wait(1000);
            }
        }    
    }
}




