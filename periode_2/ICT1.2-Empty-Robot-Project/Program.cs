using System.Device.Gpio;
using Avans.StatisticalRobot;
using System;
using System.Threading;

internal class Program {
    private static readonly short ForwardSpeed = 100;
    private static readonly short ReverseSpeed = -50;
    private static readonly short SafeDistance = 20;
    private static void Main(string[] args) {
        Ultrasonic distanceSensor = new Ultrasonic(18);
        Led led = new Led(5);

        while (true) {
            int currentDistance = distanceSensor.GetUltrasoneDistance();
            Console.WriteLine($"currentDistance = {currentDistance}");

            if (currentDistance < SafeDistance) {
                led.SetOn();
                Robot.PlayNotes("! O5 L16 agafaae dac+adaea fac<a bac#a dac#adaea f O6");
                Robot.Motors(ForwardSpeed, ReverseSpeed);
            } else {
                led.SetOff();
                Robot.Motors(ForwardSpeed, ForwardSpeed);
            }

            Robot.Wait(1000);
        }
    }
}
