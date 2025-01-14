using System.Device.Gpio;
using Avans.StatisticalRobot;
using SensorLibrary;
using Mqtt;
using SoundLibrary;
using SimpleMqtt;

namespace PIRmotion
{
    public class MotionDetection : Sensors
    {
        private int PinNumber {get; set;}
         private bool IsMeasuring {get; set;}
        // private MessageService MessageSender {get;}
        public void StartMeasuringMovement() => IsMeasuring = true;
        public void StopMeasuringMovement() => IsMeasuring = false;
        public bool StatusMeasuringMovement() => IsMeasuring;
        public MotionDetection(int PinNumber)
        {
            this.PinNumber = PinNumber;
            IsMeasuring = false;
            // MessageSender = new MessageService("robot");
        }

        public async Task MeasureMovement(SimpleMqttClient client) 
        {
            Robot.SetDigitalPinMode(16, PinMode.Input);
            await PlayAnnouncement("Measuring \nenvironment", Mentions.Active);
            
            // Gets Europe/Amsterdam timezone
            TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time");
            double detectedMovement = 0;
            double detectedNoMovement = 0;

            while(IsMeasuring) 
            {
                if (await IsMovementDetected())
                {
                    detectedMovement++;
                    Console.WriteLine("Beweging gedetecteerd!");
                }
                else
                {
                    detectedNoMovement++;
                    Console.WriteLine("Geen beweging gedetecteerd!");
                }
                await Task.Delay(200); // Prevents CPU-overload
            }

            await PlayAnnouncement("Stopped \nmeasuring", Mentions.Stopped);
            double movementPercentage = detectedMovement / (detectedMovement + detectedNoMovement) * 100; // Calculates percentage
            if(movementPercentage >= 40) // Better calculation to decide or there was some movement
            {
                // Getting the current time from Europe/Amsterdam
                DateTime amsterdamTime = TimeZoneInfo.ConvertTime(DateTime.UtcNow, timeZone); // UtcNow grabs the correct summer- or wintertime
                Data.motionDetectedData.Add(amsterdamTime.TimeOfDay.ToString(@"hh\:mm\:ss"));

                // Sending message to HiveMQ
                try {
                    await client.PublishMessage("motionDetection|true", "robot");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error while sending measurement message: {ex}");
                }
            } 
            else 
            {
                // Sending message to HiveMQ
                try {
                    await client.PublishMessage("motionDetection|false", "robot");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error while sending measurement message: {ex}");
                }
                await PlayAnnouncement("No movement \ndetected", Mentions.NothingDetected);
            }
        }

        private async Task<bool> IsMovementDetected()
        {
            if (Robot.ReadDigitalPin(PinNumber) == PinValue.High)
            {
                await Task.Delay(200);
                if (Robot.ReadDigitalPin(PinNumber) == PinValue.High)  // Checks again after awaiting time for preventing debouncing
                {
                    return true;
                }
            }
            return false; 
        }
    }
}