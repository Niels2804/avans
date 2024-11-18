namespace WorkingProject;
public static class Lists {
    private static readonly List<List<double>> verbruikLijsten = [
        [6.4, 5.4, 7.2, 6.8, 8.1 ], // Gasverbruik
        [0.4, 0.6, 0.5, 0.7, 0.8 ], // Waterverbruik
        [10.8, 11.8, 12.5, 13.2, 14.0] // Elektriciteitsverbruik
    ];

    public static void Main() {
        runAssignment1();
    }   

    // Assignment 1
    private static void runAssignment1() {
        for(int i = 0; i < verbruikLijsten.First().Count; i++) {   
            Console.WriteLine($"dag {i}:");
            Console.WriteLine($"Gasverbruik {verbruikLijsten[0][i]}");
            Console.WriteLine($"Waterverbruik {verbruikLijsten[1][i]}");
            Console.WriteLine($"Elektriciteitsverbruik {verbruikLijsten[2][i]}");
        }   
    }
}




