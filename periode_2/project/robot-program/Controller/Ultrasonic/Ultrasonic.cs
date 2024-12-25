using Avans.StatisticalRobot;

namespace UltrasonicLibrary 
{
    public enum SensorPosition
    {
        FrontLeft,
        FrontCenter,
        FrontRight,
        BackCenter
    }

    public class UltrasonicDistance 
    {
        private readonly Dictionary<SensorPosition, Ultrasonic> _sensors = new();
        public SensorPosition triggeredEmergencySensor {get; set;}
        public UltrasonicDistance(int frontLeftPin, int frontCenterPin, int frontRightPin, int backCenterPin)
        {
            _sensors.Add(SensorPosition.FrontLeft, new Ultrasonic(frontLeftPin));            
            _sensors.Add(SensorPosition.FrontCenter, new Ultrasonic(frontCenterPin));            
            _sensors.Add(SensorPosition.FrontRight, new Ultrasonic(frontRightPin));            
            _sensors.Add(SensorPosition.BackCenter, new Ultrasonic(backCenterPin));            
        }
        
        // Checks the distance between the robot and an object of every Ultrasonic before returning true of false
        public bool IsObstacleDetected()
        {
            bool emergencyStop = false;
            int minimumDistance;
            foreach (var sensor in _sensors)
            {
                if(sensor.Key == SensorPosition.FrontLeft || sensor.Key == SensorPosition.FrontRight || sensor.Key == SensorPosition.BackCenter) {
                    minimumDistance = 2;
                } else {
                    minimumDistance = 5;
                }

                if (sensor.Value.GetUltrasoneDistance() <= minimumDistance)
                {
                    triggeredEmergencySensor = sensor.Key;
                    emergencyStop = true;
                } 
            }
            return emergencyStop;
        }
    }
}
