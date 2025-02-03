using Drivers;
using Persons;
public class Program
{
    static public void Main()
    {
        RunDriverTests();
        RunPersonTests();
    }

    static private void RunDriverTests()
    {
        Driver driver = new("Niels", new DateTime(2005, 4, 28), 1_000_001, new DateTime(2029, 10, 3));
        driver.PrintDriverInformation();
        driver.UpdateDriverLicence(1_000_002, new DateTime(2034, 10, 3));
        driver.PrintDriverInformation();
    }

    static private void RunPersonTests()
    {
        Person person1 = new("Niels", new DateTime(2005, 4, 28));
        Person person2 = new("Ruben", new DateTime(1972, 4, 7));
        
        person1.PrintPersonData();
        person2.PrintPersonData();

        Person oldestPerson = Person.OldestPerson(person1, person2);
        Console.WriteLine($"{oldestPerson.GetName()} is het oudst");
        
        person1.UpdateDateOfBirth("2004, 7, 19");
        person1.PrintPersonData();
        person1.UpdateDateOfBirth(2006, 11, 23);
        person1.PrintPersonData();
        person1.UpdateDateOfBirth(new DateTime(2007, 8, 27));
        person1.PrintPersonData();
    }
}