using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading;

namespace Checkbox {
    public class Program : Games {
        private static readonly string _checkboxHeadline = "Select one of the following options:";            
        private static readonly string[] _options = ["Galgje", "Mastermind", "Boter, kaas en eieren"];

        // Main Game menu
        private static void Main() {

            // Initialize checkboxes 
            Checkbox checkbox = new Checkbox(_checkboxHeadline, _options); // In this case, max 1 option can be selected
            CheckboxReturn[] response = checkbox.Select();
            Console.Clear();
            
            foreach (CheckboxReturn checkboxReturn in response)
            {
                SelectedGameOption = checkboxReturn.Index;
                Console.WriteLine($"U heeft de game optie {checkboxReturn.Option} geselecteerd. De game wordt nu ingeladen...");
                System.Threading.Thread.Sleep(1500);
                Console.Clear();
            }
            Games.Initialize(); // initializing game
        }
    }

    public class Games
    {
        protected static int SelectedGameOption {get; set;}

        // Constructor
        protected static void Initialize() {
            switch(SelectedGameOption) {
                case 0:
                    Galgje.Initialize();
                    break;
                case 1:
                    break;
                case 2: 
                    break;
                default: 
                    Console.WriteLine("No game options are selected, the game will ending now");
                    System.Threading.Thread.Sleep(3000);
                    Environment.Exit(0);
                    break;
            }
        }

        // Game 1: Galgje
        protected class Galgje {
            protected static List<string> words { get; set; }

            public static void Initialize()
            {
                try {
                    using (StreamReader File = new StreamReader("randomWords.json")) {   
                        string json = File.ReadToEnd();
                        var jsonData = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(json);

                        if (jsonData != null && jsonData.ContainsKey("words")){
                            words = jsonData["words"];
                            foreach (string word in words)
                            {
                                Console.WriteLine(word);
                            }
                        } else {
                            Console.WriteLine("No words for the game \"Galgje\" found. The game will be ended...");
                            System.Threading.Thread.Sleep(3000);
                            Environment.Exit(0);
                        }     
                    }
                } catch (Exception e) {
                    Console.WriteLine($"An error occurred while initializing Galgje game: {e.Message}");
                }
            }
        }        
    }
}

// Mastermind

// Boter, kaas en eieren
