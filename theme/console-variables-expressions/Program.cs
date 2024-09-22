// assignment 1
for(int i = 1; i <= 100; i++) {
    Console.WriteLine(i);
}

// assignment 2
for(int i = 100; 1 <= i; i--) {
    Console.WriteLine(i);
}

// assingment 3
for(int i = 1; i <= 100; i++) {
    if((i % 2) == 0) {
        Console.WriteLine(i);
    }
}

// assignment 4
for(int i = 1; i <= 5; i++) {
    for(int a = 1; a <= 5; a++) {
        Console.Write("*");
    }
    Console.WriteLine();
}

// assignment 5
int som = 0;
for(int i = 0; i <= 100; i++) {
    som += i;
}
Console.WriteLine("De som van alle getallen tussen 0 en 100 is: " + som);

// assignment 6
int number = 28;
int faculteit = 1;
for(int i = 1; i <= number; i++) {
    faculteit *= i;
}
Console.WriteLine("De faculteit van " + number + " is: " + faculteit);

// assignment 7
int number1 = 1;
int number2 = 1;

Console.WriteLine("1. 1");
Console.WriteLine("2. 1");

for(int i = 3; i <= 40; i++) {
    int total = number1 + number2;
    Console.WriteLine($"{i}. {total} ({number1} + {number2})");
    number1 = number2;
    number2 = total;
}