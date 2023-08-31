//internal class Program
//{
//    private static void Main(string[] args)
//    {
//        int percentLowerBound = 0;
//        int percentUpperBound = 100;
//        int barLength;
//        int percent;
//        int positionX;
//        int positionY;

//        Random random = new Random();

//        percent = random.Next(percentLowerBound, percentUpperBound);
//        positionX = 0;
//        positionY = 1;
//        barLength = 10;
//        Console.WriteLine("Bar закрашен на " + percent + " процентов.");
//        DrawHealthBar(percent, barLength, positionX, positionY);

//        percent = random.Next(percentLowerBound, percentUpperBound);
//        positionX = 2;
//        positionY = 3;
//        barLength = 14;
//        Console.WriteLine("Bar закрашен на " + percent + " процентов.");
//        DrawHealthBar(percent, barLength, positionX, positionY);

//        Console.WriteLine("\nНажмите любую клавишу...");
//        Console.ReadKey();
//    }

//    static void DrawHealthBar(int percent, int barLength, int positionX, int positionY)
//    {
//        char leftBoundBar = '[';
//        char rigthBoundBar = ']';
//        char cleanBar = '_';
//        char fillBar = '#';
//        float maxPercentValue = 100f;

//        string bar = "" + leftBoundBar;
//        float value = (barLength / maxPercentValue) * percent;

//        for (int i = 0; i < barLength; i++)
//        {
//            if (i < value)
//                bar += fillBar;
//            else
//                bar += cleanBar;
//        }
        
//        bar += rigthBoundBar;

//        Console.SetCursorPosition(positionX, positionY);
//        Console.WriteLine(bar);
//    }
//}