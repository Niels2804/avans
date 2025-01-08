List<Pokemon> pokedex = [
    new Pokemon { Id = 1, Name = "Pikachoo", MaxHp = 100, Attack = 50 },
    new Pokemon { Id = 2, Name = "Charflame", MaxHp = 90, Attack = 55 },
    new Pokemon { Id = 3, Name = "Bulbataur", MaxHp = 95, Attack = 45 },
    new Pokemon { Id = 4, Name = "Squirry", MaxHp = 85, Attack = 40 },
    new Pokemon { Id = 5, Name = "Jigglipop", MaxHp = 110, Attack = 30 },
    new Pokemon { Id = 6, Name = "Meowthar", MaxHp = 80, Attack = 35 },
    new Pokemon { Id = 7, Name = "Psydock", MaxHp = 90, Attack = 40 },
    new Pokemon { Id = 8, Name = "Machump", MaxHp = 100, Attack = 60 },
    new Pokemon { Id = 9, Name = "Gengrim", MaxHp = 105, Attack = 70 },
    new Pokemon { Id = 10, Name = "Snorlox", MaxHp = 160, Attack = 65 },
    new Pokemon { Id = 11, Name = "Eevola", MaxHp = 85, Attack = 50 },
    new Pokemon { Id = 12, Name = "Mewtan", MaxHp = 150, Attack = 90 },
    new Pokemon { Id = 13, Name = "Moltira", MaxHp = 120, Attack = 85 },
    new Pokemon { Id = 14, Name = "Zaprus", MaxHp = 120, Attack = 85 },
    new Pokemon { Id = 15, Name = "Artican", MaxHp = 120, Attack = 85 },
];

// maak de trainers aan en geef ze ieder 3 willekeurige pokemon
var trainer1 = new Trainer() { Name = "Ashen Catcher" };
for (int i = 0; i < 3; i++)
{
    trainer1.AddPokemon(pokedex[Random.Shared.Next(pokedex.Count)]);
}
var trainer2 = new Trainer() { Name = "Josie and Jace" };
for (int i = 0; i < 3; i++)
{
    trainer2.AddPokemon(pokedex[Random.Shared.Next(pokedex.Count)]);
}

//we maken de battle aan en simuleren totdat de battle klaar is
Battle battle = new Battle(trainer1, trainer2);
while(!battle.Done)
{
    battle.Step();
}

//en dan is er een winnaar
Console.WriteLine("The battle is over!");
Console.WriteLine($"{battle.Winner.Name} has won!");
