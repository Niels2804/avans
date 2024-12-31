using Avans.StatisticalRobot;
using Mqtt;
using RobotMotors;
using SensorLibrary;
using SoundLibrary;

public class RompiRobot : Sensors { 
    private string Name {get;}
    private DrivingController DrivingController {get;}
    private Task DrivingTask {get; set;}
    private Task CountDownAnimationTask {get; set;}  
    private Task MeasureTask {get; set;}
    private bool isMeasuring {get; set;}
    public RompiRobot()
    {
        Name = "Wall-E";
        DrivingController = new DrivingController();
    }

    // On start-up initializing
    public async Task Init() 
    {
        // Resetting robot to default settings
        led.SetOff();
        lcd.SetText($"Welkom! Mijn \nnaam is {Name}");
        await speaker.PlayMusic(Mentions.Welcome);

        // Announcing a tutorial how to use the robot
        // await speaker.PlayMusic(Mentions.TutorialMention);
        // await speaker.PlayMusic(Mentions.TutorialStep1);
        // await speaker.PlayMusic(Mentions.TutorialStep2);
        // await speaker.PlayMusic(Mentions.TutorialStep3);
        // await speaker.PlayMusic(Mentions.TutorialStep4);
        // await speaker.PlayMusic(Mentions.Bye_1);
    }    

    // Every 200 milliseconds this Update() method will run
    public async Task Update()
    {    
        // Updating battery status
        CheckBatteryVoltage();
        
        // Checking or robot is already driving
        if(!DrivingController.StatusPermissionToDrive() && !lcdTextAnimation.StatusCountDownAnimation() && !isMeasuring) 
        {
            led.SetOn();
            DrivingController.GrantPermissionToDrive();
            DrivingTask = Task.Run(DrivingController.Drive);
            MeasureTask = Task.Run(CountDownForMeasureMovement);
        }

        // Checking or the emergency stop button is pressed
        if (button.GetState() == "Pressed" && DrivingController.StatusPermissionToDrive() && !isMeasuring)
        {
            led.SetOff();
            DrivingController.RevokePermissionToDrive();
            lcdTextAnimation.StartCountDownAnimation();
            await Task.WhenAll(DrivingTask, MeasureTask); // awaiting for currently running driving task before starting a new task
            await PlayAnnouncement("Robot paused", Mentions.Paused);
            
            CountDownAnimationTask = Task.Run(lcdTextAnimation.CountDown30);
            await Task.Delay(2000);
        }
        else if (button.GetState() == "Pressed" && !DrivingController.StatusPermissionToDrive() && !isMeasuring)
        {
            Console.WriteLine(lcdTextAnimation.StatusCountDownAnimation());
            if(lcdTextAnimation.StatusCountDownAnimation())
            {
                lcdTextAnimation.CancelCountDownAnimation();
            } 
            await CountDownAnimationTask; // awaiting for currently running countDownAnimation task before continuing
            led.SetOff();
        }    
    }

    private async Task CountDownForMeasureMovement()
    {
        int countdownTimer = new Random().Next(10, 40);
        while(DrivingController.StatusPermissionToDrive() && !isMeasuring)
        {
            countdownTimer--;
            await Task.Delay(1000);

            if (countdownTimer <= 0)
            {
                isMeasuring = true;
                motionSensor.StartMeasuringMovement();
                DrivingController.RevokePermissionToDrive();
                await DrivingTask; // Robot needs to be stopped before start measuring for movement
                await PlayAnnouncement("Robot paused", Mentions.Paused);
                
                // Measuring for movement
                try
                {
                    Task measuring = Task.Run(motionSensor.MeasureMovement);
                    await Task.Delay(new Random().Next(10000, 15000));
                    motionSensor.StopMeasuringMovement();
                    await measuring;
                    isMeasuring = false;
                } catch (Exception ex)
                {
                    Console.WriteLine($"Error during measurement: {ex.Message}");
                }
                Console.WriteLine($"Data heeft {Data.motionDetectedData.Count()} item(s) en de eerste item is {Data.motionDetectedData[0]}.");
                return;
            }
        }
    }

    private void CheckBatteryVoltage()
    {
        try
        {
            int batteryMillivolts = Robot.ReadBatteryMillivolts();

            if (batteryMillivolts >= 7500) // Full battery
            {
                Robot.LEDs(0, 0, 255);
            }
            else if (batteryMillivolts >= 6000) // Stable battery
            {
                Robot.LEDs(0, 255, 0);
            }
            else // Battery is low and needs to recharge
            {
                Robot.LEDs(255, 0, 0);
            }

            // Flickering animation
            Robot.Wait(100);
            Robot.LEDs(0, 0, 0);
            Robot.Wait(3000);

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while checking battery voltage: {ex.Message}");
        }
    }
}





