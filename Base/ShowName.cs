//internal class Program
//{
//    private static void Main(string[] args)
//    {
//        string name;
//        string lineWithName;
//        char symbolForFrame;
//        int nameLength;

//        Console.Write("Введите имя: ");
//        name = Console.ReadLine();
//        Console.Write("Введите символ для рамки: ");

//        symbolForFrame = Convert.ToChar(Console.ReadLine());

//        lineWithName = $"{symbolForFrame} {name} {symbolForFrame}";
//        nameLength = lineWithName.Length;

//        string lineUpperOrLowerFrame = "";

//        for (int i = 0; i < nameLength; i++)
//        {
//            lineUpperOrLowerFrame += symbolForFrame;
//        }

//        Console.WriteLine(lineUpperOrLowerFrame);
//        Console.WriteLine(name);
//        Console.WriteLine(lineUpperOrLowerFrame);
//        Console.ReadKey();
//    }
//}