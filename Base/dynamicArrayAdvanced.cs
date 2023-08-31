//internal class Program
//{
//    private static void Main(string[] args)
//    {
//        const string CommandToExit = "exit";
//        const string CommandToSum = "sum";

//        List<int> numbers = new List<int>();
//        string currentCommand;
//        bool isWork = true;

//        while (isWork)
//        {
//            ShowCurrentList(numbers);

//            Console.Write($"Введите число или {CommandToSum} для расчета суммы " +
//                $"или {CommandToExit} для выхода: ");
//            currentCommand = Console.ReadLine();

//            switch (currentCommand)
//            {
//                case CommandToExit:
//                    isWork = false;
//                    break;

//                case CommandToSum:
//                    CalculateSum(numbers);
//                    break;

//                default:
//                    AddNumber(numbers, currentCommand);
//                    break;
//            }

//            Console.Clear();
//        }
//    }

//    static void ShowCurrentList(List<int> numbers)
//    {
//        if (numbers.Count > 0)
//        {
//            Console.Write("Текущий массив: ");

//            foreach (int number in numbers)
//            {
//                Console.Write(number + " ");
//            }

//            Console.WriteLine();
//        }
//    }

//    static void CalculateSum(List<int> numbers)
//    {
//        int sum = 0;

//        foreach (int number in numbers)
//        {
//            sum += number;
//        }

//        Console.WriteLine("Сумма чисел в массиве = " + sum);
//        Console.WriteLine("Нажмите любую клавижу...");
//        Console.ReadKey();
//    }

//    static void AddNumber(List<int> numbers, string stringNumber)
//    {
//        int number;

//        if (int.TryParse(stringNumber, out number))
//            numbers.Add(number);
//    }
//}