namespace Grades {
    public class CumLaude {
        private static List<double> grades = new List<double>();
        private static double averageGrade = 0.0;
        public static void Main() {
            Console.Clear();
            if (grades.Count > 0) {
                GenerateSummery();
            }
            AskForGrade();
        }

        private static void AskForGrade() {
            Console.WriteLine("What is the grade you get? (Write like \"7,0\", decimal divided by a comma)");
            Validator(Console.ReadLine());
        }

        private static void GenerateSummery() {
            Console.WriteLine($"Average grade: {averageGrade}");
            Console.Write($"Filled grades: ");
            foreach(double grade in grades) {
                Console.Write($"{grade} ");
            }
            Console.WriteLine();
        }
        
        private static void Validator(string? value) {            
            if (string.IsNullOrEmpty(value)) {
                Console.WriteLine("Enter a valid value between \"0,0\" and \"10,0\", decimal divided by a comma");
                return;
            } 
            double grade = double.Parse(value);
            if (grade > 10 || grade < 0.0) {
                Console.WriteLine("Grade value must be between \"0,0\" and \"10,0\", decimal divided by a comma");
                return;
            } else {
                grades.Add(grade);  
                averageGrade = grades.Sum() / grades.Count;
            }
            Main();
        }
    }
}