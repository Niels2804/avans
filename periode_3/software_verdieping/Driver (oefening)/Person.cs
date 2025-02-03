using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons
{
    public class Person
    {
        private string _name;
        private DateTime? _dateOfBirth;

        public string GetName() => _name;
        public DateTime? GetDateOfBirth() => _dateOfBirth == null ? new DateTime(0, 0, 0) : _dateOfBirth;

        public Person(string name)
        {
            _name = name;
        }

        public Person(string name, DateTime dateOfBirth)
        {
            _name = name;
            _dateOfBirth = dateOfBirth;
        }

        public void UpdateDateOfBirth(DateTime dateOfBirth)
        {
            _dateOfBirth = dateOfBirth;
        }

        public void UpdateDateOfBirth(int year, int month, int day)
        {
            _dateOfBirth = new DateTime(year, month, day);
        }

        public void UpdateDateOfBirth(string dateOfBirth)
        {
            _dateOfBirth = DateTime.Parse(dateOfBirth);
        }

        public static Person OldestPerson(Person person1, Person person2)
        {
            return person1.GetDateOfBirth() > person2.GetDateOfBirth() ? person1 : person2;
        }

        public void PrintPersonData()
        {
            Console.WriteLine($"Naam: {_name}");
            Console.WriteLine($"Leeftijd: {_dateOfBirth}");
        }
    }
}
