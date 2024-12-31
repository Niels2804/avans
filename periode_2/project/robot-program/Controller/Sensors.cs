using Speaker.Sound;
using GyroscopeCompass.Calculations;
using UltrasonicLibrary;
using Avans.StatisticalRobot;
using LCDScreen;
using PIRmotion;
using SoundLibrary;

// All sensors what are used for the robot
namespace SensorLibrary
{
    public class Sensors {
        public static UltrasonicDistance ultrasonicSensors {get; set;}
        public static LCD16x2 lcd {get; set;}
        public static TextAnimation lcdTextAnimation {get; set;} // Only this property is not a sensor!
        public static Music speaker {get; set;}
        public static Led led {get; set;}
        public static Button button {get; set;}
        public static MotionDetection motionSensor {get; set;}
        public static Acceleration gyro {get; set;}

        // This constructor needs to be static for a good initializing process
        static Sensors()
        {
            ultrasonicSensors = new UltrasonicDistance(22, 24, 26, 18);
            lcd = new LCD16x2(0x3E);
            lcdTextAnimation = new TextAnimation();
            speaker = new Music();
            led = new Led(5);
            button = new Button(6);
            motionSensor = new MotionDetection(16);
            gyro = new Acceleration();
        }

        public async Task PlayAnnouncement(string lcdMessage, Mentions? mention = null)
        {
            lcd.SetText(lcdMessage);
            if(mention.HasValue)
            {
                speaker.StopMusic();
                await Task.Run(() => speaker.PlayMusic((Mentions)mention));
            }
        }
    }
}

