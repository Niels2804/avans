using System.Diagnostics;
using System.Reflection;
using Avans.StatisticalRobot;

// display version and build timestamp
FileVersionInfo vi = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
FileInfo fileInfo = new FileInfo(vi.FileName);
DateTime createTime = fileInfo.CreationTime;
Console.WriteLine($"RompiRobot (Wall-E) started (v{vi.FileVersion} @ {createTime}) ");
Robot.PlayNotes("g>g"); // Start-up sound

// Checking battery voltage
int batteryMillivolts = Robot.ReadBatteryMillivolts();
if (batteryMillivolts >= 7500) 
{
    Console.WriteLine($"Current batterylevel is FULL: {batteryMillivolts}mV");
} 
else if (batteryMillivolts >= 6000)  
{
    Console.WriteLine($"Current batterylevel is STABLE: {batteryMillivolts}mV");
} 
else 
{
    Console.WriteLine($"WARNING: Current batterylevel is LOW: {batteryMillivolts}mV");   
}

RompiRobot robot = new RompiRobot();
await robot.Init();

while (true) 
{
    await robot.Update();
    Robot.Wait(200);
}
    