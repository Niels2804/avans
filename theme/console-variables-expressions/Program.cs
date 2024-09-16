// assignment 1
float temperatuur = 12.5f;
if  (temperatuur < 0) {
    Console.WriteLine("Momenteel vriest het");
} else {
    Console.WriteLine("Momenteel is het niet aan het vriezen");
}

// assignment 2
int randomNumber = new Random().Next(0, 999);
if ((randomNumber % 2) == 0) {
    Console.WriteLine($"Het getal {randomNumber} is even");
} else {
    Console.WriteLine($"Het getal {randomNumber} is oneven");
}

// assingment 3
Console.Write("Wat is uw geboortejaar?: ");
int yearOfBirth = Convert.ToInt16(Console.ReadLine());
int currentAge = DateTime.Now.Year - yearOfBirth;
Console.WriteLine($"Volgens onze berekening ben je {currentAge} jaar oud");

