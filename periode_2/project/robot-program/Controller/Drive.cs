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
        private void DriveForward() => Robot.Motors(100, 100);
        private void TurnRight() => Robot.Motors(100, -100);
        private void TurnLeft() => Robot.Motors(-100, 100);
        private void DriveBackward() => Robot.Motors(-100, -100);

        public async Task Drive()
        {   
            await PlayAnnouncement($"Warning", Mentions.Warning);
            await PlayAnnouncement($"Robot starts \ndriving", Mentions.Start);
            while(HasPermissionToDrive)
            {
                while (!ultrasonicSensors.IsObstacleDetected() && HasPermissionToDrive) 
                {
                    if(!RobotIsCurrentlyDriving)
                    {
                        DriveForward();
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
            // await PlayAnnouncement("Obstacle \ndetected", Mentions.ObstacleDetected);
            int rotationTime;

            switch(ultrasonicSensors.triggeredEmergencySensor)
            {
                case SensorPosition.FrontCenter:
                    await DriveReverse(1000);
                    TurnRight();
                    rotationTime = 625;
                    break;
                case SensorPosition.FrontLeft:
                    await DriveReverse(250);
                    TurnRight();
                    rotationTime = 325;
                    break;
                case SensorPosition.FrontRight:
                    await DriveReverse(250);
                    TurnLeft();
                    rotationTime = 325;
                    break;
                default:
                    rotationTime = 0;
                    Console.WriteLine("No driving direction is set!");
                    break;
            }
            
            // Robot always turns right preventing for driving circles
            Robot.Wait(rotationTime);
            Robot.Motors(0, 0);
            
            await PlayAnnouncement("Continuing driving...");
            Robot.Wait(500);   
        }

        private async Task DriveReverse(int driveTime) {
            bool isDriving = false;
            using var cts = new CancellationTokenSource();
            Task drivingTask = Task.Run(async () =>
            {
                while (!cts.Token.IsCancellationRequested && !ultrasonicSensors.IsObstacleDetectedInReverse())
                {   
                    if(!isDriving)
                    {
                        DriveBackward();
                        isDriving = true;
                    }
                    await Task.Delay(50);
                }
                Robot.Motors(0, 0);
            }, cts.Token);

            await Task.Delay(driveTime);
            await cts.CancelAsync();
            await drivingTask;
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