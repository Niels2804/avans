using System.Device.Gpio;
using Avans.StatisticalRobot;
using System;
using System.Threading;

internal class Program {
    private static Walle _walle = new();
    private static void Main() {
        while (true) {
            Console.WriteLine($"Current voltage is {Robot.ReadBatteryMillivolts()}");
            _walle.CheckBatteryVoltage();
            Robot.Wait(2000);
        }
    }
}
