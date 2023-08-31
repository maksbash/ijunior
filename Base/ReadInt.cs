//internal class Program
//{
//    private static void Main(string[] args)
//    {
//        int number = ReadInt();

//        Console.Write("Введенное число = " + number);
//        Console.ReadKey();
//    }

//    static int ReadInt()
//    {
//        int number = 0;
//        string stringNumber;
//        bool isNumber = false;

//        while (isNumber == false)
//        {
//            Console.Write("Введите чилсо: ");
//            stringNumber = Console.ReadLine();

//            isNumber = int.TryParse(stringNumber, out number);
//        }

//        return number;
//    }
//}