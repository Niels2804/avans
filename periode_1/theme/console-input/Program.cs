// Introduction - assignment 1
Console.Write("Hello there! What is your name?: ");
string? name = Console.ReadLine();
Console.Write($"Hello, {name}! One more question. In which year were you born?: ");

// Current age calculation - assignment 2
string? year = Console.ReadLine(); 
int bornYear = string.IsNullOrWhiteSpace(year) ? 0 : int.Parse(year);
int age = DateTime.Now.Year - bornYear;

// Output - result
Console.WriteLine($"So, your name is {name} and you are {age} years old. Nice to meet you! =)");

