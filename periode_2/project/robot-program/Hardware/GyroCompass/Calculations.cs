using GyroscopeCompass.Compass;
using GyroscopeCompass.Gyroscope;
using GyroscopeCompass.GyroscopeCompass;
using Avans.StatisticalRobot;

namespace GyroscopeCompass.Calculations
{
    public class Acceleration {
        private GyroCompass _gyro {get; set;}
        public Acceleration()
        {
            _gyro = new GyroCompass();
        }
        public void PrintAcceleration() 
        {
            _gyro.GetGyroAcceleration(out float x, out float y, out float z); 
            Console.WriteLine($"{x} - {y} - {z}");
            Robot.Wait(500);
        }

        public void PrintoAngularVelocity() 
        {
            _gyro.GetGyroAngularVelocity(out float x, out float y, out float z);   
            Console.WriteLine($"{x} - {y} - {z}");
            Robot.Wait(500);
        }
    }
}