//internal class Program
//{
//    private static void Main(string[] args)
//    {
//        Random rand = new Random();
//        int randomNum = rand.Next(0, 101);
//        int resultSum = 0;

//        Console.WriteLine("Число - " + randomNum);
//        Console.Write("Числа делящиеся на 3 или на 5: ");

//        for (int i = 1; i <= randomNum; i++)
//        {
//            if (i % 3 == 0 || i % 5 == 0)
//            {
//                Console.Write(i + " ");
//                resultSum += i;
//            }
//        }
//        Console.WriteLine();
//        Console.WriteLine("Сумма чисел делящиеся на 3 или на 5 = " + resultSum);
//        Console.ReadKey();
//    }
//}