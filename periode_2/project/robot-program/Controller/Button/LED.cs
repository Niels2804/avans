using System.Device.Gpio;
namespace Avans.StatisticalRobot;

public class Led
{
    private readonly int _pin;

    /// <summary>
    /// This is a digital device
    /// 3.3V/5V
    /// </summary>
    /// <param name="pin">Pin number on grove board</param>
    public Led(int pin)
    {
        Robot.SetDigitalPinMode(pin, PinMode.Output);
        _pin = pin;
    }

    public void SetOn()
    {
        Robot.WriteDigitalPin(_pin, PinValue.High);
    }
    public void SetOff()
    {
        Robot.WriteDigitalPin(_pin, PinValue.Low);
    }
}