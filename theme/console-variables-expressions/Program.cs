// assignment 1
Console.WriteLine(Random.Shared.Next(28));

// assignment 2
Console.WriteLine(Random.Shared.Next(0, 4));

// assignment 3
Console.WriteLine(Random.Shared.Next(105, 109));

// assignment 4
Console.WriteLine(40 + Random.Shared.NextDouble() * 5);

// assignment 5
double[] numbers = [0.0, 0.5, 1.0, 1.5, 2.0];
Random.Shared.Shuffle(numbers);
Console.WriteLine($"{numbers[0]} {numbers[1]} {numbers[2]} {numbers[3]} {numbers[4]}");

