//internal class Program
//{
//    private static void Main(string[] args)
//    {

//        int[] numbers = new int[30];
//        int lowerBound = 1;
//        int upperBound = 6;
//        Random random = new Random();

//        int mostOftenNumber;
//        int countMostOftenNumber = 0;
//        int anotherMostOftenNumber;
//        int countAnotherMostOftenNumber = 0;

//        Console.Write("Массив: ");

//        for (int i = 0; i < numbers.Length; i++)
//        {
//            numbers[i] = random.Next(lowerBound, upperBound);
//            Console.Write(numbers[i] + " ");
//        }

//        int index = 1;
//        mostOftenNumber = numbers[index - 1];
//        anotherMostOftenNumber = mostOftenNumber;

//        while (index < numbers.Length)
//        {
//            if (numbers[index] == numbers[index - 1])
//            {
//                countAnotherMostOftenNumber++;
//            }
//            else if (countAnotherMostOftenNumber > 0)
//            {
//                anotherMostOftenNumber = numbers[index - 1];

//                if (countAnotherMostOftenNumber > countMostOftenNumber)
//                {
//                    countMostOftenNumber = countAnotherMostOftenNumber;
//                    mostOftenNumber = anotherMostOftenNumber;
//                }

//                countAnotherMostOftenNumber = 0;
//            }

//            index++;  
//        }

//        Console.Write($"- число {mostOftenNumber} повторяется наибольшее " +
//            $"число раз - {countMostOftenNumber + 1}");

//        Console.ReadKey();
//    }
//}