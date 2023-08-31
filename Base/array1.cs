//internal class Program
//{
//    private static void Main(string[] args)
//    {
//        int[,] array = new int[2, 4] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 } };

//        for (int i = 0; i < array.GetLength(0); i++)
//        {
//            for (int j = 0; j < array.GetLength(1); j++)
//            {
//                Console.Write(array[i, j] + " ");
//            }
//            Console.WriteLine();
//        }

//        int column = 0;
//        int row = 1;
//        int producrtOfTheFirstColumn = 1;
//        int sumOfTheSecondLine = 0;

//        for (int i = 0; i < array.GetLength(1); i++)
//        {
//            sumOfTheSecondLine += array[row, i];
//        }

//        for (int i = 0; i < array.GetLength(0); i++)
//        {
//            producrtOfTheFirstColumn *= array[i, column];
//        }

//        Console.WriteLine("Произведение чисел первого столбца = " + producrtOfTheFirstColumn);
//        Console.WriteLine("Сумма чисел второй строки = " + sumOfTheSecondLine);

//        Console.ReadKey();
//    }
//}