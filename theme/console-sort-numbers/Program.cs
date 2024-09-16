namespace ConsoleSortNumbers {
    interface IFunctions {
        void RunGame(); // This function will startup and run the game
        int SortingFunction(); // Sort the list with integers ascending and returns the middle number of the list
    }
    
    public class Functions : IFunctions {
        private int _totalNumberListLength = 0;
        private List<int> _numberList = [];
        private int ValidateInput(string? value) {
            return string.IsNullOrWhiteSpace(value) ? 0 : Int32.Parse(value);
        }

        public void RunGame() {
            Console.Write("How many numbers you want to sort?: ");
            _totalNumberListLength = ValidateInput(Console.ReadLine());

            for (int i = 0; i < _totalNumberListLength; i++) {
                Console.Write($"Enter number {i + 1}: ");
                _numberList.Add(ValidateInput(Console.ReadLine()));
            }

            Console.WriteLine($"So, you entered {_numberList.Count()} numbers: {String.Join(", ", _numberList)}");
        }

        public int SortingFunction() {
            _numberList.Sort();
            return _numberList[_numberList.Count() / 2];
        }
    }

    public class Numbers {
        public static void Main() {
            Functions func = new(); 
            Console.WriteLine("Welcome to the sorting game! Enter random numbers and this tool will show you which number is the middle number from the 3 numbers you enter");
            func.RunGame();
            Console.WriteLine("Let's sort the numbers ascending and pick out the middle one!");
            Console.WriteLine("And the middle number is...");
            Console.WriteLine($"{func.SortingFunction}");
        }
    }
}