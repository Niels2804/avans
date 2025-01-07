using Avans.StatisticalRobot;
using Mqtt;
using RobotMotors;
using SensorLibrary;
using SoundLibrary;
using HiveMQtt.Service;
using HiveMQtt.MessageService;

public class RompiRobot : Sensors { 
    private string Name {get;}
    private DrivingController DrivingController {get;}
    private MessageService MessageSender {get;}
    private MessageService MessageReceiver {get;}
    private Task DrivingTask {get; set;}
    private Task CountDownAnimationTask {get; set;}  
    private Task MeasureTask {get; set;}
    private bool IsMeasuring {get; set;}
    private bool IsBusyWithCheckingBatteryState {get; set;}
    private bool IsBusyWithReceivingMessage {get; set;}
    private bool IsBusyWithDriving {get; set;}
    public RompiRobot()
    {
        Name = "Wall-E";
        DrivingController = new DrivingController();
        MessageSender = new MessageService("robot");
        MessageReceiver = new MessageService("web");
        IsMeasuring = false;
        IsBusyWithCheckingBatteryState = false;
        IsBusyWithReceivingMessage = false;
        IsBusyWithDriving = false;
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
        if(!IsBusyWithCheckingBatteryState)
        {
            IsBusyWithCheckingBatteryState = true;
            _ = CheckBatteryVoltage();
        }

        // Checking on received messages
        if(!IsBusyWithReceivingMessage) 
        {
            IsBusyWithReceivingMessage = true;
            _ = CheckForReceivedMessages();
        }
        
        // Checking or robot is already driving
        if(DrivingController.StatusPermissionToDrive() && !IsBusyWithDriving && !IsMeasuring && !lcdTextAnimation.StatusCountDownAnimation()) 
        {
            IsBusyWithDriving = true;
            led.SetOn();
            DrivingController.GrantPermissionToDrive();
            DrivingTask = Task.Run(DrivingController.Drive);
            MeasureTask = Task.Run(CountDownForMeasureMovement);
        }

        // Checking or the emergency stop button is pressed
        if (button.GetState() == "Pressed" && DrivingController.StatusPermissionToDrive() && IsBusyWithDriving && !IsMeasuring)
        {
            led.SetOff();
            DrivingController.RevokePermissionToDrive();
            IsBusyWithDriving = false;
            lcdTextAnimation.StartCountDownAnimation();
            await Task.WhenAll(DrivingTask, MeasureTask); // awaiting for currently running driving task before starting a new task
            await PlayAnnouncement("Robot paused", Mentions.Paused);
            
            CountDownAnimationTask = Task.Run(lcdTextAnimation.CountDown30);
            await Task.Delay(2000);
        }
        else if (button.GetState() == "Pressed" && !DrivingController.StatusPermissionToDrive() && !IsBusyWithDriving && !IsMeasuring)
        {
            if(lcdTextAnimation.StatusCountDownAnimation())
            {
                lcdTextAnimation.CancelCountDownAnimation();
            } 
            await CountDownAnimationTask; // awaiting for currently running countDownAnimation task before continuing
            led.SetOff();
        }    
    }

    private async Task CheckForReceivedMessages()
    {
        MessageData messageData;
        string? message = await MessageReceiver.StartReceivingMessages();
        if(message == null || !message.Contains('|'))
        {
            Console.WriteLine($"1: Ongeldige bericht formaat: {message}");
            IsBusyWithReceivingMessage = false;
            return;
        } 
   
        var messageParts = message.Split('|'); // The receiving messages are: "type|value"
        if (messageParts.Length == 2)
        {
            messageData = new MessageData(messageParts[0], messageParts[1]);
        } else {
            Console.WriteLine($"2: Ongeldige bericht formaat: {message}");
            IsBusyWithReceivingMessage = false;
            return;
        }

        switch (messageData.Type) {
            case "mention":
                if (Enum.TryParse(messageData.Value, out Mentions mention)) // Warning!! Is case-sensitive!!
                {
                    await PlayAnnouncement("Warning", Mentions.Warning);
                    DrivingController.RevokePermissionToDrive();
                    IsBusyWithDriving = false;
                    await PlayAnnouncement("Robot paused", Mentions.Paused);
                    await PlayAnnouncement("Reminder \nmessage!!", (Mentions)Enum.Parse(typeof(Mentions), messageData.Value));
                    DrivingController.GrantPermissionToDrive();
                } 
                else 
                {
                    Console.WriteLine($"Mention type {messageData.Value} bestaat niet.");
                }
                break;
            case "hasPermissionToDrive":
                try {
                    if (bool.Parse(messageData.Value) == true)
                    {
                        DrivingController.GrantPermissionToDrive();
                    }
                    else 
                    {
                        DrivingController.RevokePermissionToDrive();
                        IsBusyWithDriving = false;
                    }
                } 
                catch (Exception ex) 
                {
                    Console.WriteLine($"Error: Fout bij het parsen van een bool: {ex.Message}");
                }
                break;
            default:
                Console.WriteLine("Geen geldige datatype gevonden.");
                break;
        }
        IsBusyWithReceivingMessage = false;
    }

    private async Task CountDownForMeasureMovement()
    {
        int countdownTimer = new Random().Next(10, 15);
        while(DrivingController.StatusPermissionToDrive() && !IsMeasuring)
        {
            countdownTimer--;
            await Task.Delay(1000);

            if (countdownTimer <= 0)
            {
                IsMeasuring = true;
                motionSensor.StartMeasuringMovement();
                DrivingController.RevokePermissionToDrive();
                IsBusyWithDriving = false;
                await DrivingTask; // Robot needs to be stopped before start measuring for movement
                await PlayAnnouncement("Robot paused", Mentions.Paused);
                
                // Measuring for movement
                try
                {
                    Task measuring = Task.Run(motionSensor.MeasureMovement);
                    await Task.Delay(new Random().Next(10000, 15000));
                    motionSensor.StopMeasuringMovement();
                    await measuring;
                    IsMeasuring = false;
                    DrivingController.GrantPermissionToDrive();
                } catch (Exception ex)
                {
                    Console.WriteLine($"Error during measurement: {ex.Message}");
                }
                Console.WriteLine($"Data heeft {Data.motionDetectedData.Count()} item(s) en de eerste item is {Data.motionDetectedData[0]}.");
                return;
            }
        }
    }

    private async Task CheckBatteryVoltage()
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
            await Task.Delay(100);
            Robot.LEDs(0, 0, 0);
            await Task.Delay(3000);

            await MessageSender.SendMessage($"batteryVoltage|{batteryMillivolts}");
            IsBusyWithCheckingBatteryState = false;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while checking battery voltage: {ex.Message}");
        }
    }
}





