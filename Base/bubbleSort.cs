//internal class Program
//{
//    private static void Main(string[] args)
//    {
//        Random random = new Random();
//        int lowerBoundNumber = 0;
//        int upperBoundNumber = 10000;
//        int lowerBoundNumbersLength = 10;
//        int upperBoundNumbersLength = 17;
//        int numbersLength = random.Next(lowerBoundNumbersLength, upperBoundNumbersLength);
//        int[] numbers = new int[numbersLength];

//        Console.Write("Исходный массив: ");

//        for (int i = 0; i < numbers.Length; i++)
//        {
//            numbers[i] = random.Next(lowerBoundNumber, upperBoundNumber);
//            Console.Write(numbers[i] + " ");
//        }

//        Console.WriteLine();

//        bool isSortActive = true;

//        while (isSortActive)
//        {
//            isSortActive = false;

//            for (int i = 1; i < numbers.Length; i++)
//            {
//                if (numbers[i] < numbers[i - 1])
//                {
//                    int tempNumber = numbers[i - 1];
//                    numbers[i - 1] = numbers[i];
//                    numbers[i] = tempNumber;
//                    isSortActive = true;
//                }
//            }
//        }

//        Console.Write("Отсортированный массив: ");

//        foreach (int number in numbers)
//        {
//            Console.Write(number + " ");
//        }

//        Console.ReadKey();
//    }
//}