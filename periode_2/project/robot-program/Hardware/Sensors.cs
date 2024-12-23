using Speaker.Sound;
using GyroscopeCompass.Calculations;
using UltrasonicLibrary;
using PIRmotion;
using Avans.StatisticalRobot;
using GyroscopeCompass.GyroscopeCompass;

namespace SensorLibrary
{
    public class Sensors {
        public static UltrasonicDistance ultrasonicSensors {get; set;}
        public static LCD16x2 lcd {get; set;}
        public static Acceleration gyro {get; set;}
        static Sensors()
        {
            ultrasonicSensors = new UltrasonicDistance(22, 24, 26, 18);
            lcd = new LCD16x2(0x3E);
            gyro = new Acceleration();
        }
    }
}

