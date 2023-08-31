//internal class Program
//{
//    private static void Main(string[] args)
//    {
//        Random random = new Random();
//        int lowerBound = 0;
//        int upperBound = 1000;
//        int randomNumber = random.Next(lowerBound, upperBound + 1);
//        int currentPower = 0;
//        int currentPowerOfNumber = 1;
//        int number = 2;

//        while (currentPowerOfNumber < randomNumber && randomNumber > 0)
//        {
//            currentPower++;
//            currentPowerOfNumber *= number;
//        }

//        Console.WriteLine($"Число - {randomNumber}");
//        Console.WriteLine($"Минимальная степень двойки = {currentPower}");
//        Console.WriteLine($"2 в степени {currentPower} = {currentPowerOfNumber}");
//        Console.ReadKey();
//    }
//}