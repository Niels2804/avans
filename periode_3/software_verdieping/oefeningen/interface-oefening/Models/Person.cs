namespace interface_oefening.Models
{
    internal class Person
    {
        protected string _naam;
        public Person(string naam)
        { 
            _naam = naam; 
        }
        public virtual string PrintInfo() => _naam;
    }
}
