//using System.Security.Principal;

//internal class Program
//{
//    private static void Main(string[] args)
//    {
//        const int CommandToAddFile = 1;
//        const int CommandToShowFile = 2;
//        const int CommandToDeleteFile = 3;
//        const int CommandToExit = 4;

//        Dictionary<string, string> accounts = new Dictionary<string, string>();
//        int command;
//        bool isActive = true;

//        while (isActive)
//        {
//            Console.Clear();
//            Console.WriteLine("Кадровый учет!");
//            Console.WriteLine($"{CommandToAddFile}) добавить досье");
//            Console.WriteLine($"{CommandToShowFile}) вывести все досье");
//            Console.WriteLine($"{CommandToDeleteFile}) удалить досье");
//            Console.WriteLine($"{CommandToExit}) выход");

//            Console.Write("\nВведите команду: ");

//            string stringCommand = Console.ReadLine();

//            if (int.TryParse(stringCommand, out command) == false)
//            {
//                Console.WriteLine("Команда введена неверно, попробуйте ещё раз");
//                continue;
//            }

//            switch (command)
//            {
//                case CommandToAddFile:
//                    AddFile(accounts);
//                    break;

//                case CommandToShowFile:
//                    ShowAllFiles(accounts);
//                    Console.Write("Нажмите любую клавижу для выхода в меню...");
//                    Console.ReadKey();
//                    break;

//                case CommandToDeleteFile:
//                    DeleteFile(accounts);
//                    break;

//                case CommandToExit:
//                    isActive = false;
//                    break;

//                default:
//                    Console.WriteLine("Неизвестная команда!");
//                    break;
//            }
//        }
//    }

//    static void AddFile(Dictionary<string, string> account)
//    {
//        string fullName;
//        string position;

//        Console.Clear();
//        Console.Write("Введите ФИО полностью: ");
//        fullName = Console.ReadLine();

//        if (account.ContainsKey(fullName))
//        {
//            Console.WriteLine("\nТакой сотрудник уже существует!");
//            Console.ReadKey();
//            return;
//        }

//        Console.Write("Введите должность: ");
//        position = Console.ReadLine();

//        if (fullName.Length > 0 && position.Length > 0)
//            account.Add(fullName, position);
//    }

//    static void DeleteFile(Dictionary<string, string> accounts)
//    {
//        string fullName;
//        ShowAllFiles(accounts);
//        Console.Write("Введите ФИО для удаления: ");
//        fullName = Console.ReadLine();

//        if (accounts.ContainsKey(fullName))
//        {
//            accounts.Remove(fullName);
//        }
//        else
//        {
//            Console.WriteLine("Такого сотрудника не существует, " +
//                "нажмите любую клавишу");
//            Console.ReadKey();
//        }
//    }

//    static void ShowAllFiles(Dictionary<string, string> accounts)
//    {
//        Console.Clear();

//        if (accounts.Count > 0)
//        {
//            Console.WriteLine("Каталог досье:");

//            foreach (var account in accounts)
//                Console.WriteLine(account.Key + " - " + account.Value);
//        }
//        else
//        {
//            Console.WriteLine("Нет ни одного досье!");
//        }
//    }
//}