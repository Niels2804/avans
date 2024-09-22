// assignment 1
List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
foreach(int number in numbers) {
    Console.WriteLine(number);
}
// assignment 2
List<double> energiePerDag = new List<double> { 20.1, 18.4, 23.4, 16.5, 19.2, 21.3, 22.1};
double totaalEnergie = 0;
foreach(double energie in energiePerDag) {
    totaalEnergie += energie;
}
Console.WriteLine($"Totaal opgewekte energie: {totaalEnergie}kWh");

// assignment 3
List<int> numbers2 = new List<int>
{
    32, 99, 7, 58, 95, 100, 63, 57, 33, 39, 24, 87, 38, 25, 48,
    54, 63, 71, 9, 9, 32, 13, 1, 55, 29, 31, 77, 93, 30, 34
};

float highestNumber = 0f;
foreach(int number in numbers2) {
    if(number > highestNumber) {
        highestNumber = number;
    }
}
Console.WriteLine($"Het hoogste getal is: {highestNumber}");

