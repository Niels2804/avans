using System.Device.Gpio;
using Avans.StatisticalRobot;

namespace PIRmotion
{
    public class MotionDetection 
    {
        public void DetectMovement() 
        {
            Robot.SetDigitalPinMode(16, PinMode.Input);

            if(Robot.ReadDigitalPin(16) == PinValue.High)
            {
                Console.WriteLine("Beweging gedetecteerd!");
            } else {
                Console.WriteLine("Geen beweging");
            }

            Robot.Wait(50);
        }
    }
}