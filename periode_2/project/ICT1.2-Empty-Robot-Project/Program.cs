using System.Device.Gpio;
using Avans.StatisticalRobot;
using System;
using System.Threading;

internal class Program {
    private static readonly short ForwardSpeed = 100;
    private static readonly short ReverseSpeed = -50;
    private static readonly short SafeDistance = 20;
    private static void Main(string[] args) {
        Ultrasonic distanceSensor = new Ultrasonic(24);
        Led led = new Led(5);

        while (true) {
            int currentDistance = distanceSensor.GetUltrasoneDistance();
            Console.WriteLine($"currentDistance = {currentDistance}");
            Robot.Motors(0, 0);

            if (currentDistance < SafeDistance) {
                led.SetOn();
                Robot.PlayNotes("! O5 L16 agafaae dac+adaea fac<a bac#a dac#adaea f O6");
            } else {
                led.SetOff();
            }

            Robot.Wait(1000);
        }
    }
}
