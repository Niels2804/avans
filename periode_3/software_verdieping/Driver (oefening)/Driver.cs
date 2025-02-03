using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers
{
    public class Driver
    {
        private string _name;
        private DateTime _dateTime;
        private long _driverLicenceNumber;
        private DateTime _driverLicenceValidUntil;

        public Driver(string name, DateTime dateTime, long driverLicenceNumber, DateTime driverLicenceValidUntil)
        {
            if (driverLicenceNumber > 1000000)
            {
                _name = name;
                _dateTime = dateTime;
                _driverLicenceNumber = driverLicenceNumber;
                _driverLicenceValidUntil = driverLicenceValidUntil;
            }
            else
            {
                throw new Exception($"{driverLicenceNumber} is invalid");
            }
        }
        public void UpdateDriverLicence(long driverLicenceNumber, DateTime driverLicenceValidUntil)
        {
            if (driverLicenceNumber > 1000000)
            {
                _driverLicenceNumber = driverLicenceNumber;
                _driverLicenceValidUntil = driverLicenceValidUntil;
            }
            else
            {
                throw new Exception($"{driverLicenceNumber} is invalid");
            }
        }

        public void PrintDriverInformation()
        {
            Console.WriteLine($"De naam van de bestuurder is {_name} en is {_dateTime.ToShortDateString()} oud. Het rijbewijsnummer is: {_driverLicenceNumber} en is geldig tot {_driverLicenceValidUntil.ToShortDateString()}");
        }
    }
}
