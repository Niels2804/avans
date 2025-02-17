using interface_oefening.Models;
internal class Program
{
    public static void Main()
    {
        Person persoon1 = new Person("Niels");
        Person persoon2 = new Docent("Niels", 12321);

        Console.WriteLine(persoon1.PrintInfo());
        Console.WriteLine(persoon2.PrintInfo());
    }
}
