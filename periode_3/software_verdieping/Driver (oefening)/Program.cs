using System.Xml.Linq;
using System;

public class Driver
{
    private string _name;
    private DateTime _dateTime;
    private long _driverLicenceNumber;
    private DateTime _driverLicenceValidUntil;

    public Driver(string name, DateTime dateTime, long driverLicenceNumber, DateTime driverLicenceValidUntil)
    {
        if(driverLicenceNumber > 1000000)
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

public class Program
{
    static public void Main()
    {
        Driver driver = new("Niels", new DateTime(2005, 4, 28), 1_000_001, new DateTime(2029, 10, 3));
        driver.PrintDriverInformation();
        driver.UpdateDriverLicence(1_000_002, new DateTime(2034, 10, 3));
        driver.PrintDriverInformation();
    }
}