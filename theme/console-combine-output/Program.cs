using System.Runtime.CompilerServices;
using System; 

public class ConsoleCombineOutput {
    private static string? symbol;
    private static void Main() {
        Console.Write("Enter the symbol you want to use: ");
        string? symbolValue = Console.ReadLine();
        symbol = string.IsNullOrWhiteSpace(symbolValue) ? "*" : symbolValue;

        Console.Write("Which assignment do you like to run? (1 or 2): ");
        switch(ValidateInput(Console.ReadLine())) {
            case 1:
                AssignmentOne();
                break;
            case 2:
                AssignmentTwo();
                break;  
            default:
                Console.WriteLine("Invalid input, everything will run now.");
                AssignmentOne();
                AssignmentTwo();
                break;
        }
    }

    // Creates a cube with the given height and width - assignment 1
    private static void AssignmentOne() {
        Console.Write("Enter the height with a number: ");
        int height = ValidateInput(Console.ReadLine());
        Console.Write("Enter the width with a number: ");
        int width = ValidateInput(Console.ReadLine());

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                Console.Write(symbol);
            }
            Console.WriteLine();
        }
    }

    private static void AssignmentTwo() {
        // Creates a pyramid with the given height - assignment 2
        Console.Write("Enter the pyramid height with a number: ");
        int height = ValidateInput(Console.ReadLine());

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < height - i; j++)
            {
                Console.Write(" ");
            }
            for (int j = 0; j < 2 * i + 1; j++)
            {
                Console.Write(symbol);
            }
            Console.WriteLine();
        }
    }

    private static int ValidateInput(string? value) {
        return string.IsNullOrWhiteSpace(value) ? 0 : int.Parse(value);
    }
}

