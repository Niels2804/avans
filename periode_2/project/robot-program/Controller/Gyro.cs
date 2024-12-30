using GyroscopeCompass.Compass;
using GyroscopeCompass.Gyroscope;
using GyroscopeCompass.GyroscopeCompass;
using Avans.StatisticalRobot;

namespace GyroscopeCompass.Calculations
{
    public class Acceleration {
        private GyroCompass Gyro {get; set;}
        public Acceleration()
        {
            Gyro = new GyroCompass();
        }
        public void PrintAcceleration() 
        {
            Gyro.GetGyroAcceleration(out float x, out float y, out float z); 
            Console.WriteLine($"{x} - {y} - {z}");
            Robot.Wait(500);
        }

        public void PrintoAngularVelocity() 
        {
            Gyro.GetGyroAngularVelocity(out float x, out float y, out float z);   
            Console.WriteLine($"{x} - {y} - {z}");
            Robot.Wait(500);
        }
    }
}