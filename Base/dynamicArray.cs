//internal class Program
//{
//    private static void Main(string[] args)
//    {
//        const string CommandToExit = "exit";
//        const string CommandToSum = "sum";

//        int[] numbers = new int[0];
//        string currentCommand;
//        bool isWork = true;

//        while (isWork)
//        {
//            if (numbers.Length > 0)
//            {
//                Console.Write("Текущий массив: ");

//                foreach (int number in numbers)
//                {
//                    Console.Write(number + " ");
//                }

//                Console.WriteLine();
//            }

//            Console.Write($"Введите число или {CommandToSum} для расчета суммы " +
//                $"или {CommandToExit} для выхода: ");
//            currentCommand = Console.ReadLine();

//            switch (currentCommand)
//            {
//                case CommandToExit:
//                    isWork = false;
//                    break;

//                case CommandToSum:
//                    int sum = 0;
//                    foreach (int number in numbers)
//                    {
//                        sum += number;
//                    }

//                    Console.WriteLine("Сумма чисел в массиве = " + sum);
//                    Console.WriteLine("Нажмите любую клавижу...");
//                    Console.ReadKey();
//                    break;

//                default:
//                    int currentNumber = Convert.ToInt32(currentCommand);
//                    int[] tempArray = new int[numbers.Length + 1];

//                    for (int i = 0; i < numbers.Length; i++)
//                    {
//                        tempArray[i] = numbers[i];
//                    }

//                    tempArray[tempArray.Length - 1] = currentNumber;
//                    numbers = tempArray;
//                    break;
//            }

//            Console.Clear();
//        }
//    }
//}