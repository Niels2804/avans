namespace WorkingProject;
public static class Lists {
    public static void Main() {
        runAssignment1();
        runAssignment2();
    }   

    // Assignment 1
    private static void runAssignment1() {
        List<string> namenLijst = [
            "Juliette", "Waldorf", "Eren", "Tristan", System.DateTime.Now.Second % 2 == 0 ? "Waldo" : "Marc" 
            ];
        Console.WriteLine(
            namenLijst.Contains("Waldo") ? 
            "De naam \"Waldo\" is gevonden in de namenlijst" : 
            "De naam \"Waldo\" is niet gevonden in de namenlijst!"
        );
    }

    // Assignment 2
    private static void runAssignment2() {
        List<string> boodschappenLijst = [
            "Avocado", "Choco chip cookies", "Broccoli", "Appels", "Chocoladecake", "Bananen", "Chocolade"
            ];
        List<string> gezondeBoodschappenLijst = boodschappenLijst.FindAll(product => !product.StartsWith("Choco"));
        Console.Write("Gezonde boodschappenlijst: ");
        foreach (string product in gezondeBoodschappenLijst) {
            Console.Write($"{product} ");
        }   
    }
}







