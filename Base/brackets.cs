//internal class Program
//{
//    private static void Main(string[] args)
//    {
//        const char OpenDepth = '(';
//        const char CloseDepth = ')';

//        string inputString;
//        int countDepth = 0;
//        int maxDepth = 0;

//        Console.Write($"Введи строку состоящую только из круглых " +
//            $"скобок \"{OpenDepth}\" или \"{CloseDepth}\": ");
//        inputString = Console.ReadLine();

//        foreach (char item in inputString)
//        {
//            switch (item)
//            {
//                case OpenDepth:
//                    countDepth++;
//                    break;

//                case CloseDepth:
//                    countDepth--;
//                    break;
//            }

//            if (countDepth < 0)
//            {
//                break;
//            }

//            if (maxDepth < countDepth)
//            {
//                maxDepth++;
//            }
//        }

//        if (countDepth != 0)
//        {
//            Console.WriteLine("Последовательность не верная!");
//        }
//        else
//        {
//            Console.WriteLine("Последовательность верная, " +
//                "максимум глубины = " + maxDepth);
//        }

//        Console.ReadKey();
//    }
//}