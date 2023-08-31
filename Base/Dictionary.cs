//internal class Program
//{
//    private static void Main(string[] args)
//    {
//        Dictionary<string, string> dictionary = FillDictionary();
//        bool isActive = true;
//        string wordToFind;
//        string wordDescription;
//        string commandToExit = "exit";

//        while (isActive)
//        {
//            Console.Clear();
//            Console.Write("Введите слово для поиска в словаре " +
//                $"или {commandToExit} для выхода : ");
//            wordToFind = Console.ReadLine();

//            if (wordToFind == commandToExit)
//            {
//                isActive = false;
//            }
//            else
//            {
//                wordDescription = FindInDictionary(dictionary, wordToFind);
//                Console.WriteLine(wordDescription);
//            }

//            Console.WriteLine("Нажмите любую клавишу....");
//            Console.ReadKey();
//        }
//    }

//    static string FindInDictionary(Dictionary<string, string> dictionary,
//        string searchWord)
//    {
//        string keyWord = searchWord.ToUpper();

//        if (dictionary.ContainsKey(keyWord))
//            return dictionary[keyWord];

//        return "Такое слово не найдено";
//    }

//    static Dictionary<string, string> FillDictionary()
//    {
//        Dictionary<string, string> dictionary = new Dictionary<string, string>();

//        dictionary.Add("АНТОНИМИЯ", "В языкознании: отношения, " +
//            "существующие междуантонимами. II прил. антонимический, -ая, -ое.");
//        dictionary.Add("АРЕОПАГ", "Собрание авторитетных лиц [первонач." +
//            "название верховного суда в Древних Афинах]. Ученый а.");
//        dictionary.Add("АРАБИСТ", "Ученый - специалист по арабистике");
//        dictionary.Add("АРФА", "Щипковый музыкальный инструмент в виде " +
//            "большой треугольнойрамы с натянутыми внутри нее струнами");
//        dictionary.Add("БAPTEP", "Товарообменная сделка, натуральный обмен." +
//            "Получить товар по бартеру");
//        dictionary.Add("БPAXMAH", "Член высшей жреческой касты в Индии");
//        dictionary.Add("ЕНДОВА", "В старину: большая открытая округлая " +
//            "посуда для вина,пива или браги, металлическая или деревянная, " +
//            "с широким рыльцем (в старомрусском флоте - сосуд такой формы, " +
//            "из к-рого раз-давалась водка). Медная е.");
//        dictionary.Add("КАБАРГА", "Сибирское и азиатское безрогое " +
//            "горноепарнокопытное животное, сходное с косулей. " +
//            "Семейство кабарог");
//        dictionary.Add("ЮРК", "ЮРК, в знач, сказ. (разг.). Юркнул. Ю. В норку.");
//        dictionary.Add("ЯЩУР", "Заразная болезнь парнокопытных " +
//            "животных (редко человека)");

//        return dictionary;
//    }
//}