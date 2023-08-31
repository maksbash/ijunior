//using System;

//internal class Program
//{
//    private static void Main(string[] args)
//    {
//        int[] numbers = new int[30];
//        Random random = new Random();
//        int lowerBound = 1;
//        int upperBound = 23;

//        if (numbers.Length <= 1)
//        {
//            Console.WriteLine("Массимв слишком мал или не существует.");
//            return;
//        }

//        Console.Write("Массив - ");

//        for (int i = 0; i < numbers.Length; i++)
//        {
//            numbers[i] = random.Next(lowerBound, upperBound);
//            Console.Write(numbers[i] + " ");
//        }

//        Console.WriteLine();
//        Console.Write("Локальные максимумы (индекс) - ");

//        if (numbers[0] > numbers[1])
//        {
//            Console.Write(numbers[0] + "(1) ");
//        }

//        for (int i = 1; i < numbers.Length - 1; i++)
//        {
            
//            if (numbers[i] > numbers[i - 1] && numbers[i] > numbers[i + 1])
//            {
//                Console.Write(numbers[i] + "(" + (i + 1) + ") ");
//            }
//        }

//        if (numbers[numbers.Length - 1] > numbers[numbers.Length - 1 - 1])
//        {
//            Console.Write(numbers[numbers.Length - 1] + "(" + numbers.Length + ") ");
//        }

//        Console.ReadKey();
//    }
//}