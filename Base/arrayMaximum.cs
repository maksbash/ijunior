//internal class Program
//{
//    private static void Main(string[] args)
//    {
//        int[,] array = new int[10, 10];
//        Random random = new Random();
//        int lowerBound = 1;
//        int upperBound = 6;
//        int maxNumber = int.MinValue;

//        for (int i = 0; i < array.GetLength(0); i++)
//        {
//            for (int j = 0; j < array.GetLength(1); j++)
//            {
//                array[i, j] = random.Next(lowerBound, upperBound);
//                Console.Write(array[i, j] + "\t");

//                if (maxNumber < array[i, j])
//                {
//                    maxNumber = array[i, j];
//                }
//            }

//            Console.WriteLine();
//        }

//        Console.WriteLine();
//        Console.WriteLine("Максимальное число - " + maxNumber);
//        Console.WriteLine();

//        for (int i = 0; i < array.GetLength(0); i++)
//        {
//            for (int j = 0; j < array.GetLength(1); j++)
//            {
//                if (maxNumber == array[i, j])
//                {
//                    array[i, j] = 0;
//                }
//                else 
//                {
//                    //этот else можно удалить если выводить как в условии задачи
//                    //показалось с -1 более наглядно выводить
//                    array[i, j] = -1;
//                }

//                Console.Write(array[i, j] + "\t");
//            }

//            Console.WriteLine();
//        }
        
//        Console.ReadKey();
//    }
//}