Console.WriteLine("Hobby Menu!");

//BEGINREMOVE
List<Person> people = new List<Person>();

while(true)
{
    Console.WriteLine();
    Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
    Console.WriteLine("| What would you like to do? |");
    Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
    Console.WriteLine();
    Console.WriteLine("1) Add Person");
    Console.WriteLine("2) Print all people");
    Console.WriteLine("3) Search for hobby");
    Console.WriteLine("x) Stop Application");
    string input = Console.ReadLine();

    if(input == "1")
    {
        Console.Write("Please input the person's name: ");
        var name = Console.ReadLine();
        Console.Write("Please input the person's hobby: ");
        var hobby = Console.ReadLine();
        people.Add(new Person()
        {
            Name = name,
            Hobby = hobby
        });
    }
    else if(input == "2")
    {
        foreach(var person in people)
        {
            Console.WriteLine(person);
        }
    }
    else if (input == "3")
    {
        Console.Write("Please input hobby: ");
        var hobby = Console.ReadLine();
        foreach (var person in people)
        {
            if (person.Hobby.ToLower() == hobby.ToLower())
            {
                Console.WriteLine(person.Name);
            }
        }

    }
    else if(input == "x")
    {
        break;
    }
    else
    {
        Console.WriteLine("Invalid input, please try again");
    }
}
//ENDREMOVE
