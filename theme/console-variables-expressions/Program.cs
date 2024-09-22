// assignment 1
List<string> tableItems = new List<string>{ "DIN formaat", "Lengte (mm)", "Breedte (mm)", "Oppervlakte (mm2)"};

int DIN = 0;
int lengte = 1189;
int breedte = 841;

foreach(string tableItem in tableItems)
{
    Console.Write(tableItem + "\t");
}
Console.WriteLine();

for(int i = 0; i < 14; i++) {
    Console.Write($"A{DIN}\t\t");
    Console.Write($"{lengte}mm\t\t");
    Console.Write($"{breedte}mm\t\t");
    Console.WriteLine($"{lengte * breedte}mm2\t\t");

    lengte = breedte;
    breedte = lengte / 2;
    DIN++;
}

// assignment 2
List<string> tableItems2 = new List<string>{ "Invoer", "Uitvoer (aantal klinkers)"};
List<string> randomZinnen = new List<string>{ 
    "De kat zit op de mat te slapen", 
    "De hond rent door het park", 
    "De vogel vliegt in de lucht", 
    "De vis zwemt in het water", 
    "De muis kruipt door het huis"
};

foreach(string tableItem in tableItems2)
{
    Console.Write(tableItem + "\t\t\t\t\t");
}
Console.WriteLine();

foreach(string zin in randomZinnen) {
    int index = 0;
    foreach(char c in zin) {
        if(c == 'a' || c == 'o' || c == 'u' || c == 'e' || c == 'i') {
            index++;
        }
    }
    Console.WriteLine($"{zin}\t\t\t {index}");
}


