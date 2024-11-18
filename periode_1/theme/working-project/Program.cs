namespace WorkingProject;
public static class Lists {
    public static void Main() {
        Console.WriteLine(findTargetLinear(2));
        Console.WriteLine(findFirstTargetBinear("Cherry"));
    }   

    // Assignment 1
    private static int findTargetLinear(int target) {
        List<int> numbers = [4, 5, 2, 8, 9, 10, 45, 2, 7, 6];
        int IndexOfTargetNumber = 0;
        for(int i = 0; i < numbers.Count; i++) {
            if(numbers[i] == target) {
                IndexOfTargetNumber = i;
            }
        }
        return IndexOfTargetNumber;
    }

    // Assignment 2
    private static int findFirstTargetBinear(string target) {
        List<string> fruits = [
            "Apple", "Apple", "Banana", "Cherry", "Cherry", 
            "Cherry", "Grape", "Kiwi", "Lemon", "Mango", "Orange", 
            "Orange", "Orange", "Peach", "Pear", "Pear", "Strawberry", 
            "Watermelon"
        ];
        int left = 0;
        int right = fruits.Count - 1;
        int result = -1;

        while(left <= right){
            int mid = left + (right - left) / 2;
            if (fruits[mid] == target){
                result = mid; 
                right = mid - 1;
            } else if (string.Compare(fruits[mid], target) < 0) {
                left = mid + 1; 
            } else{
                right = mid - 1; 
            }
        }
        return result;
    }
}







