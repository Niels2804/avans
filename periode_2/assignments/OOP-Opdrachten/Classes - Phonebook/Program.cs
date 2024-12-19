PhoneBook phoneBook = new();

phoneBook.Add("Jan", "Jansen", "0612345678");
phoneBook.Add("Piet", "Pietersen", "0687654321");
phoneBook.Add("Klaas", "Klaassen", "0623456789");
phoneBook.Add("Anna", "De Vries", "0645678912");
phoneBook.Add("Sophie", "Bakker", "0611223344");
phoneBook.Add("Anna", "Van Dijk", "0678901234");
phoneBook.Add("Emma", "Hendriks", "0654321987");
phoneBook.Add("Finn", "Kuiper", "0612347890");
phoneBook.Add("Noah", "Visser", "0623456712");
phoneBook.Add("Liam", "Smit", "0634567891");


Console.WriteLine(phoneBook.PhoneNumber("Klaas Klaassen")); // 0623456789
Console.WriteLine(phoneBook.PhoneNumber("Noah Visser")); // 0623456712
Console.WriteLine(phoneBook.PhoneNumber("Piet Puk")); // 

// Console.WriteLine("Phone numbers: " + string.Join(", ", phoneBook.PhoneNumbers()));
// Console.WriteLine("First Names: " + string.Join(", ", phoneBook.UniqueFirstNames()));

// var entries = phoneBook.EntriesWithFirstNameStarting("J");
// foreach(var entry in entries)
// {
//     Console.WriteLine(entry.Name);
// }
