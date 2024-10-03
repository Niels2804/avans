// assignment 1
decimal calculateWaterPrice(Int16 kuub, decimal waterPrice, double tax) {
    if (kuub > 50) {
        Console.WriteLine($"Waarschuwing: u heeft meer dan 50 kuub water verbruikt, namelijk  {kuub} kuub.");
    } 

    return kuub * waterPrice * (1.00m + (decimal)tax);
}

// assignment 2
decimal calculateElectricityPrice(long totalkWh, decimal pricePerKwh) {
    if ((totalkWh - 100) > 0) {
        return (100 * pricePerKwh * 1.08m) + ((totalkWh - 100) * (pricePerKwh + 0.20m) * 1.04m);
    } else {
        return totalkWh * pricePerKwh * 1.08m;
    }
}

// assignment 3
void printValues() {
    Int16 kuub = (Int16)Random.Shared.Next(1, 100);
    decimal waterPrice = 1.37m;
    double tax = 0.08;
    Console.WriteLine($"De prijs van {kuub} kuub water is €{calculateWaterPrice(kuub, waterPrice, tax)} euro.");

    long totalkWh = (long)Random.Shared.Next(1, 100);
    decimal pricePerKwh = 0.23m;
    Console.WriteLine($"De prijs van {totalkWh}kWh is €{String.Format("{0:#,##0.000}", calculateElectricityPrice(totalkWh, pricePerKwh))}");
}

printValues();



