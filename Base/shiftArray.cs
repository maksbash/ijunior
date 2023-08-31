//internal class Program
//{
//    private static void Main(string[] args)
//    {
//        int[] numbers = { 1, 2, 3, 4, 5, 6 };
//        int numbersLength = numbers.Length;
//        int shiftNumber;
//        int shiftCorrected;

//        Console.Write("Исходный массив: ");

//        foreach (int number in numbers)
//        {
//            Console.Write(number + " ");
//        }

//        Console.WriteLine();
//        Console.Write("Введити число на которое нужно сдвинуть массив: ");

//        shiftNumber = Convert.ToInt32(Console.ReadLine());
//        shiftCorrected = shiftNumber % numbersLength;

//        if (shiftCorrected < 0)
//        {
//            shiftCorrected += numbersLength;
//        }

//        for (int i = 0; i < shiftCorrected; i++)
//        {
//            int number = numbers[0];

//            for (int j = 1; j < numbersLength; j++)
//            {
//                numbers[j - 1] = numbers[j];
//            }

//            numbers[numbersLength - 1] = number;
//        }

//        Console.Write("Сдвинутый массив: ");

//        foreach (int number in numbers)
//        {
//            Console.Write(number + " ");
//        }

//        Console.ReadKey();
//    }
//}