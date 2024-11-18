// disco color loop (just for fun lol)
public class ConsoleColors
{
    private static Random random = new Random();

    public static void Main()
    {
        Console.Write("Hi there! How many rules you want the disco loop will print?: ");
        string? rules = Console.ReadLine();
        PrintRules(string.IsNullOrWhiteSpace(rules) ? 10 : int.Parse(rules));
    }

    private static void PrintRules(int rules)
    {
        for (int i = 0; i < rules; i++)
        {
            Console.ForegroundColor = (ConsoleColor)random.Next(0, 16);
            Console.BackgroundColor = (ConsoleColor)random.Next(0, 16);
            Console.WriteLine("Lorem ipsum dolor sit amet, consectetur adipiscing elit.");
            Console.ResetColor();
            Thread.Sleep(500);
        }
        Console.WriteLine();
        Console.WriteLine("Finished! Do you like the colors? Let's do it again!");
    }
}