using Avans.StatisticalRobot;

public class Rompi
{
    public string name {get; set;}
    public Rompi(string name)
    {
        this.name = name;
    }

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