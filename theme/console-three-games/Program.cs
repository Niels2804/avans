using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading;

namespace Checkbox {
    public class Program : Games {
        private static readonly string _checkboxHeadline = "Select one of the following options:";            
        private static readonly string[] _options = ["Hangman", "Mastermind", "Butter, cheese and eggs"];

        // Main Game menu
        private static void Main() {

            // Initialize checkboxes 
            Checkbox checkbox = new Checkbox(_checkboxHeadline, _options); // In this case, max 1 option can be selected
            CheckboxReturn[] response = checkbox.Select();
            Console.Clear();
            
            foreach (CheckboxReturn checkboxReturn in response)
            {
                SelectedGameOption = checkboxReturn.Index;
                Console.WriteLine($"You have selected the game option {checkboxReturn.Option}. The game is loading...");
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
                    Hangman.Initialize();
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

        // Game 1: Hangman
        protected class Hangman {
            protected static List<string> words = new List<string>();
            protected static List<string> currentGamble = new List<string>();
            protected static string toGambleWord {get; set;}
            protected static int totalAttempts {get; set;}

            // Reading json file with words
            public static void Initialize()
            {
                try {
                    if (words == null || words.Count == 0) {
                        Console.WriteLine("Initializing Hangman game...");
                        using (StreamReader File = new StreamReader("randomWords.json"))
                        {
                            string json = File.ReadToEnd();
                            var jsonData = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(json);
                            if (jsonData != null && jsonData.ContainsKey("words")){
                                foreach(string word in jsonData["words"]) {
                                    words.Add(word.Trim().ToLower());
                                }
                            } else {
                                Console.WriteLine("No words for the game \"Hangman\" found. The game will be ended...");
                                Thread.Sleep(3000);
                                throw new Exception("No words found in the JSON file."); // Throw exception instead of Environment.Exit(0)
                            }
                        }
                    }

                    // Reset properties
                    toGambleWord = words[Random.Shared.Next(words.Count)].Trim().ToLower();
                    currentGamble.Clear();
                    for (int i = 0; i < toGambleWord.Length; i++)
                    {
                        currentGamble.Add("_");
                    }
                    totalAttempts = 10;
                    runGame();
                } catch (Exception e) {
                    Console.WriteLine($"An error occurred while initializing Hangman game: {e.Message}");
                }
            }

            // Start-up Hangman game
            protected static void runGame() {
                try {
                    showCurrentGamble();
                    newAttempt();
                } catch (Exception e) {
                    Console.WriteLine($"An error occurred while initializing Hangman game: {e.Message}");
                }
            }

            protected static bool newAttempt() {
                Console.WriteLine("Type one letter: ");
                string? input = Console.ReadLine();
                if (string.IsNullOrEmpty(input)) {
                    Console.WriteLine("Pleas, enter a valid value with a length of 1 character");
                } else if (input.Count() < 1) {
                    Console.WriteLine("Pleas, make sure the length is max 1 character");
                } else {
                    return checkCurrentAttempt(input);
                }
            }

            protected static bool checkCurrentAttempt(string input) {
                foreach (char character in toGambleWord)
                {
                    return toGambleWord.Contains(character);
                }
            }

            protected static void showCurrentGamble() {
                Console.Write("Current gamble: ");
                foreach (string c in currentGamble) { 
                    Console.Write($"{c} ");
                }
                Console.WriteLine();
                Console.WriteLine($"You have in total {totalAttempts} attempts left!");
            }
        }        
    }
}

// Mastermind

// Boter, kaas en eieren
