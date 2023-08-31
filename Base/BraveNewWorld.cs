//using System.Numerics;

//internal class Program
//{
//    private static void Main(string[] args)
//    {
//        char[,] map = GenerateMap();
//        int xPlayerPosition = 1;
//        int yPlayerPosition = 1;

//        DrawMap(map);
//        Console.SetCursorPosition(xPlayerPosition, yPlayerPosition);

//        Play(ref xPlayerPosition, ref yPlayerPosition, ref map);
//    }

//    static void Draw(char inPlace, int xPlayerPosition, int yPlayerPosition)
//    {
//        Console.Write(inPlace);
//        Console.SetCursorPosition(xPlayerPosition, yPlayerPosition);
//    }

//    static bool GetPosition(ref int xPlayerPosition, ref int yPlayerPosition)
//    {
//        ConsoleKeyInfo keyInfo;
//        bool isPlay = true;

//        keyInfo = Console.ReadKey();

//        if (keyInfo.Key == ConsoleKey.UpArrow)
//            yPlayerPosition--;
//        else if (keyInfo.Key == ConsoleKey.DownArrow)
//            yPlayerPosition++;
//        else if (keyInfo.Key == ConsoleKey.LeftArrow)
//            xPlayerPosition--;
//        else if (keyInfo.Key == ConsoleKey.RightArrow)
//            xPlayerPosition++;
//        else if (keyInfo.Key == ConsoleKey.Q)
//            isPlay = false;

//        return isPlay;
//    }

//    static void Play(ref int xPlayerPosition, ref int yPlayerPosition, ref char[,] map)
//    {
//        bool isPlay = true;
//        char player = 'Q';
//        char cleanPlace = ' ';
//        Console.CursorVisible = false;

//        Draw(player, xPlayerPosition, yPlayerPosition);

//        while (isPlay)
//        {
//            isPlay = GetPosition(ref xPlayerPosition, ref yPlayerPosition);

//            if (map[xPlayerPosition, yPlayerPosition] == cleanPlace)
//            {
//                Draw(cleanPlace, xPlayerPosition, yPlayerPosition);
//                Draw(player, xPlayerPosition, yPlayerPosition);
//            }
//            else
//            {
//                (xPlayerPosition, yPlayerPosition) = Console.GetCursorPosition();
//            }
//        }
//    }

//    static void DrawMap(char[,] map)
//    {
//        Console.Clear();
//        int v1 = map.GetLength(1);

//        for (int y = 0; y < map.GetLength(1); y++)
//        {
//            for (int x = 0; x < map.GetLength(0); x++)
//                Console.Write(map[x, y]);

//            Console.Write("\n");
//        }
//    }

//    static char[,] GenerateMap()
//    {
//        int width = 30;
//        int heigth = 15;

//        char[,] map = new char[width, heigth];
//        string[] prepareMap =
//            {
//            "##############################",
//            "#                            #",
//            "#                            #",
//            "#                            #",
//            "#     #                      #",
//            "#     #                      #",
//            "#     #                      #",
//            "#                            #",
//            "#             ######         #",
//            "#                            #",
//            "#                            #",
//            "#                            #",
//            "#                            #",
//            "#                            #",
//            "##############################"
//        };

//        int yLength = prepareMap[0].Length;

//        for (int x = 0; x < prepareMap[0].Length; x++)
//            for (int y = 0; y < prepareMap.Length; y++)
//                map[x, y] = prepareMap[y][x];

//        return map;
//    }
//}