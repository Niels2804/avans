using Avans.StatisticalRobot;

public class Walle { 
    public void CheckBatteryVoltage() 
    {
        if (Robot.ReadBatteryMillivolts() <= 3000) 
        {
            Robot.LEDs(0, 0, 255);
        } else 
        {
            for(int i = 0; i < 255; i++) {
                Robot.LEDs((byte)i, 0, 0);
            }
            
            for(int i = 255; i < 1; i--) {
                Robot.LEDs((byte)i, 0, 0);
            }
        }
    }
}
public class Drive
{
    private Ultrasonic? _distanceSensor;
    private Led? _led;
    private readonly short _ForwardSpeed = 100;
    private readonly short _ReverseSpeed = -50;
    private readonly short _SafeDistance = 20;
    private void Main() 
    {
        this._distanceSensor= new Ultrasonic(24);
        this._led = new Led(5);
    }

    public void Forward() 
    {
    }

    public void Reverse() 
    {
    }

    public void TurnRight() 
    {

    }

    public void TurnLeft() 
    {
        
    }

    public void Rotate() {

    }
} 

public class MotionSensor 
{
    public bool DetectMotionSensor() 
    {
        return true;
    }
}

// public class UltrasonicDistance {
//     public double ForwardCenterDistance() {

//     }
// }
