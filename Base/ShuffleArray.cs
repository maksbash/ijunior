//internal class Program
//{
//    private static void Main(string[] args)
//    {
//        int[] numbers = { 1, 2, 3, 4, 5, 6 };

//        Console.Write("Исходный массив: ");
//        PrintArray(numbers);

//        ShuffleArray(numbers);

//        Console.Write("\nПеремешаный массив: ");
//        PrintArray(numbers);

//        Console.ReadKey();
//    }

//    static void PrintArray(int[] numbers)
//    {
//        foreach (int number in numbers)
//        {
//            Console.Write(number + " ");
//        }
//    }

//    static void ShuffleArray(int[] numbers)
//    {
//        Random random = new Random();

//        for (int i = 0; i < numbers.Length; i++)
//        {
//            int randomCellNumber;
//            int randomCellValue;

//            randomCellNumber = random.Next(0, numbers.Length - 1);
//            randomCellValue = numbers[randomCellNumber];
//            numbers[randomCellNumber] = numbers[i];
//            numbers[i] = randomCellValue;
//        }
//    }
//}