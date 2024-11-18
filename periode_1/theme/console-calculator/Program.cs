namespace Calculator {
    public class Setup : Calc {
        private readonly static int a = 3;
        private readonly static int b = 4;
        public static void Main() {
            Console.Clear();
            Console.WriteLine(Calc.Sum(a, b));
            Console.WriteLine(Calc.Minus(a, b));
            Console.WriteLine(Calc.Divide(a, b));
            Console.WriteLine(Calc.Times(a, b));
        }
    }

    public class Calc {
        protected static int Sum(int a, int b) {
            return a + b;
        }
        protected static int Minus(int a, int b) {
            return a + b;
        }
        protected static int Divide(int a, int b) {
            return a / b;
        }
         protected static int Times(int a, int b) {
            return a * b;
        }
    }
}
   