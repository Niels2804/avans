using Avans.StatisticalRobot;
using LCDScreen;
using RobotMotors;
using SensorLibrary;
using SoundLibrary;

public class RompiRobot : Sensors { 
    private string _name {get; set;}
    private DrivingController _drivingController {get; set;}
    private bool _robotIsDriving {get; set;}
    private Task _drivingRobot {get; set;}
    private Task _countDownAnimation {get; set;}    
    public RompiRobot()
    {
        _name = "Wall-E";
        _drivingController = new DrivingController();
        _robotIsDriving = false;
    }
    public async Task Init() 
    {
        Robot.Wait(20000);
        led.SetOff();
        lcd.SetText("Welkom! Mijn \nnaam is Wall-E");
        await speaker.PlayMusic(Mentions.Welcome);
        // await speaker.PlayMusic(Mentions.TutorialMention);
        // await speaker.PlayMusic(Mentions.TutorialStep1);
        // await speaker.PlayMusic(Mentions.TutorialStep2);
        // await speaker.PlayMusic(Mentions.TutorialStep3);
        // await speaker.PlayMusic(Mentions.TutorialStep4);
        // await speaker.PlayMusic(Mentions.Bye_1);
    }    

    public async Task Update()
    {
        await CheckBatteryVoltage();
        
        if(!_robotIsDriving && _drivingController.hasPermissionToDrive) 
        {
            _robotIsDriving = true;
            _drivingRobot = Task.Run(_drivingController.Drive);
        }

        if (button.GetState() == "Pressed" && _drivingController.hasPermissionToDrive)
        {
            TextAnimation.countDownIsCanceled = false;
            _drivingController.hasPermissionToDrive = false;
            _robotIsDriving = false;
            led.SetOn();
            await _drivingRobot;
            _countDownAnimation = Task.Run(TextAnimation.CountDown60);
            Robot.Wait(2000);
        }
        else if (button.GetState() == "Pressed" && !_drivingController.hasPermissionToDrive)
        {
            if(!TextAnimation.countDownIsCanceled)
            {
                TextAnimation.countDownIsCanceled = true;
                _drivingController.hasPermissionToDrive = true;
            }
            await _countDownAnimation;
            led.SetOff();
        }
    }

    private async Task CheckBatteryVoltage() 
    {
        int batteryMillivolts = Robot.ReadBatteryMillivolts();
        
        if (batteryMillivolts >= 7500) 
        {
            Robot.LEDs(0, 0, 255);
        }
        else if (batteryMillivolts >= 6000)
        {
            Robot.LEDs(0, 255, 0);
        }
        else
        {
            Robot.LEDs(255, 0, 0);
        }

        Robot.Wait(100);
        Robot.LEDs(0, 0, 0);
        Robot.Wait(3000);
    }
}





