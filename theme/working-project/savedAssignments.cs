// // assignment 1
// List<int> numbers = new List<int> {};
// int avgNumber = 0;

// Console.WriteLine("Met hoeveel getallen wil je het gemiddelde berekenen?");
// int index = Convert.ToInt32(Console.ReadLine());

// for (int i = 0; i < index; i++) {
//     Console.WriteLine($"Voer getal {i + 1} in:");
//     int value = Convert.ToInt32(Console.ReadLine());

//     if (value > 0) {
//         numbers.Add(value);
//     } else {
//         Console.WriteLine("Negatieve getallen worden niet meegenomen in het gemiddelde.");
//     }

//     Console.WriteLine(numbers.Sum());
//     Console.WriteLine(numbers.Count);

//     avgNumber = numbers.Sum() / numbers.Count;
//     Console.WriteLine($"Het gemiddelde van de ingevoerde getallen is: {avgNumber}");
// }

// // assignment 1
// string[,] grid = new string[5, 5]
//         {
//             { "", "red", "yellow", "", "" },
//             { "", "", "yellow", "", "" },
//             { "", "", "red", "yellow", "" },
//             { "", "red", "yellow", "yellow", "red" },
//             { "yellow", "red", "red", "yellow", "yellow" }
//         };
// int redCount = 0;
// int yellowCount = 0;

// for (int row = 0; row < grid.GetLength(0); row++) {
//     for (int col = 0; col < grid.GetLength(1); col++) {
//         if (grid[row, col] == "red") {
//             redCount++;
//         } else if (grid[row, col] == "yellow") {
//             yellowCount++;
//         }
//     }
// }

// Console.WriteLine(
//     $"In totaal zijn er {redCount} rode en {yellowCount} gele muntjes, " +
//     $"dus de winnaar is {(redCount > yellowCount ? "rood" : "geel")}"
// );

// ﻿Console.Clear();

// // assignment 1
// int randomNumber = new Random().Next(0, 100);
// int number = (int)randomNumber;
// int totalSteps = 0;

// while (number > 1) {
//     if (number % 2 == 0) { 
//         number /= 2;
//     } else {
//         number *= 3;
//         number++;
//     }
//     totalSteps++;
//     Console.WriteLine($"{totalSteps}. {number}");
// }
// Console.WriteLine(
//     $"Bij het getal {randomNumber} ware er in totaal {totalSteps} " +
//     "stappen nodig om bij het getal 1 uit te komen."
// );


// // assignment 2
// int a = new Random().Next(0, 100);
// int b = new Random().Next(0, 100);

// if (a < b) {
//     int temp = a; 
//     a = b; 
//     b = temp;
// }

// while (b != 0) {
//     int r = a % b; 
//     a = b;         
//     b = r; 
// }

// Console.WriteLine($"De grootste gemeenschappelijke deler van de getallen is: {a}");

// // assignment 3
// number = new Random().Next(0, 100);
// int som = 0;

// while (number != 0)
// {
//     int grade = number % 10;
//     som += grade;         
//     number /= 10;            
// }

// Console.WriteLine($"De som van de cijfers is: {som}");

// // assignment 4
// int low  = 1;
// int high = 100;
// int gamble = 0;
// int totalAttempts = 0;
// bool active = true;

// while (active)
// {
//     gamble = (low + high) / 2;
//     totalAttempts++;

//     Console.WriteLine($"Is jouw getal hoger, lager of gelijk aan {gamble}?");
//     string inputValue = Console.ReadLine().ToLower();

//     switch(inputValue)
//     {
//         case "hoger":
//             low = gamble + 1;
//             break;
//         case "lager":
//             high = gamble - 1;
//             break;
//         case "gelijk":
//             Console.WriteLine($"Het getal is {gamble}! Het aantal pogingen: {totalAttempts}");
//             active = false;
//             break;
//         default:
//             Console.WriteLine("Ongeldige invoer. Typ 'hoger', 'lager' of 'gelijk'.");
//             break;
//     }
// }

// Energy calculator

// // assignment 1
// decimal calculateWaterPrice(Int16 kuub, decimal waterPrice, double tax) {
//     if (kuub > 50) {
//         Console.WriteLine($"Waarschuwing: u heeft meer dan 50 kuub water verbruikt, namelijk  {kuub} kuub.");
//     } 

//     return kuub * waterPrice * (1.00m + (decimal)tax);
// }

// // assignment 2
// decimal calculateElectricityPrice(long totalkWh, decimal pricePerKwh) {
//     if ((totalkWh - 100) > 0) {
//         return (100 * pricePerKwh * 1.08m) + ((totalkWh - 100) * (pricePerKwh + 0.20m) * 1.04m);
//     } else {
//         return totalkWh * pricePerKwh * 1.08m;
//     }
// }

// // assignment 3
// void printValues() {
//     Int16 kuub = (Int16)Random.Shared.Next(1, 100);
//     decimal waterPrice = 1.37m;
//     double tax = 0.08;
//     Console.WriteLine($"De prijs van {kuub} kuub water is €{calculateWaterPrice(kuub, waterPrice, tax)} euro.");

//     long totalkWh = (long)Random.Shared.Next(1, 100);
//     decimal pricePerKwh = 0.23m;
//     Console.WriteLine($"De prijs van {totalkWh}kWh is €{String.Format("{0:#,##0.000}", calculateElectricityPrice(totalkWh, pricePerKwh))}");
// }

// printValues();


// Cum Laude calculater

// using System.Formats.Asn1;

// namespace Grades {
//     public class CumLaude {
//         private static List<double> grades = new List<double>();
//         private static double averageGrade = 0.0;
//         public static void Main() {
//             Console.Clear();
//             if (grades.Count > 0) {
//                 GenerateSummery();
//             }
//             AskForGrade();
//         }

//         private static void AskForGrade() {
//             Console.WriteLine("What is the grade you get? (Write like \"7,0\", decimal divided by a comma)");
//             Validator(Console.ReadLine());
//         }
        
//         private static void Validator(string? value) {            
//             if (string.IsNullOrEmpty(value)) {
//                 Console.WriteLine("Enter a valid value between \"0,0\" and \"10,0\", decimal divided by a comma");
//                 System.Threading.Thread.Sleep(1500);
//             } 
//             double grade = double.Parse(value);
//             if (grade <= 0) {
//                 Console.Clear();
//                 GenerateSummery();
//                 Environment.Exit(1);
//             } else if (grade > 10.0 || grade < 0.0) {
//                 Console.WriteLine("Grade value must be between \"0,0\" and \"10,0\", decimal divided by a comma");
//                 System.Threading.Thread.Sleep(1500);
//             } else {
//                 grades.Add(grade);  
//                 averageGrade = grades.Sum() / grades.Count;
//             }
//             Main();
//         }

//          private static void GenerateSummery() {
//             Console.WriteLine($"Average grade: {averageGrade}");
//             Console.Write($"Filled grades: ");
//             foreach(double grade in grades) {
//                 Console.Write($"{grade} ");
//             }
//             Console.WriteLine();
//             Console.WriteLine(averageGrade >= 8 ? "Je bent cum laude geslaagd!!" : "Helaas... je bent niet cum laude geslaagd.");
//         }
//     }
// }
