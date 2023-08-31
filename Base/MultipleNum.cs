//internal class Program
//{
//    private static void Main(string[] args)
//    {
//        Random random = new Random();
//        int lowerBound = 1;
//        int upperBound = 27;
//        int randomNumber = random.Next(lowerBound, upperBound + 1);
//        int currentNumber = randomNumber;
//        int numberOfMultiples = 0;

//        int lowerBoundDividend = 100;
//        int upperBoundDividend = 999;

//        for (int i = currentNumber; i <= upperBoundDividend; i += randomNumber)
//        {
//            if (i >= lowerBoundDividend)
//            {
//                numberOfMultiples++;
//            }
//        }

//        Console.WriteLine($"Количество трёхзначных чисел кратных {randomNumber} = {numberOfMultiples}");
//        Console.ReadKey();
//    }
//}