using Avans.StatisticalRobot;
using RobotMotors;
using SensorLibrary;
using SoundLibrary;

public class RompiRobot : Sensors { 
    private string _name {get; set;}
    private DrivingController _drivingController {get; set;}
    private bool _emergencyButtonWasPressed {get; set;}
    public RompiRobot()
    {
        _name = "Wall-E";
        _drivingController = new DrivingController();
        _emergencyButtonWasPressed = false;
    }
    public async Task Init() {
        Robot.Wait(20000);
        await speaker.PlayMusic(Mentions.Welcome);
        await speaker.PlayMusic(Mentions.TutorialMention);
        await speaker.PlayMusic(Mentions.TutorialStep1);
        await speaker.PlayMusic(Mentions.TutorialStep2);
        await speaker.PlayMusic(Mentions.TutorialStep3);
        await speaker.PlayMusic(Mentions.TutorialStep4);
        await speaker.PlayMusic(Mentions.Bye_1);
    }    

    public async Task Update()
    {
        await CheckBatteryVoltage();
         _drivingController.hasPermissionToDrive = true;
        Task backgroundJob = Task.Run(_drivingController.Drive);
        Robot.Wait(120000);
        _drivingController.hasPermissionToDrive = false;
        await backgroundJob;



        // if (button.GetState() == "Pressed" && !_emergencyButtonWasPressed)
        // {
        //     Console.WriteLine("DEBUG: Emergency stop button pressed");
        //     led.SetOn();
        //     _emergencyButtonWasPressed = true;
        // }
        // else if (button.GetState() == "Released" && _emergencyButtonWasPressed)
        // {
        //     Console.WriteLine("DEBUG: Emergency stop button released");
        //     led.SetOff();
        //     _emergencyButtonWasPressed = false;
        // }
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





