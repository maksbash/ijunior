//internal class Program
//{
//    private static void Main(string[] args)
//    {
//        const int CommandToAddFile = 1;
//        const int CommandToShowFile = 2;
//        const int CommandToDeleteFile = 3;
//        const int CommandToSerchBySecondName = 4;
//        const int CommandToExit = 5;

//        string[] fullNames = null;
//        string[] positions = null;
//        int command;
//        bool isActive = true;

//        while (isActive)
//        {
//            Console.Clear();
//            Console.WriteLine("Кадровый учет!");
//            Console.WriteLine($"{CommandToAddFile}) добавить досье");
//            Console.WriteLine($"{CommandToShowFile}) вывести все досье");
//            Console.WriteLine($"{CommandToDeleteFile}) удалить досье");
//            Console.WriteLine($"{CommandToSerchBySecondName}) поиск по фамилии");
//            Console.WriteLine($"{CommandToExit}) выход");

//            Console.Write("\nВведите команду: ");
//            command = Convert.ToInt32(Console.ReadLine());

//            switch (command)
//            {
//                case CommandToAddFile:
//                    AddFile(ref fullNames, ref positions);
//                    break;
//                case CommandToShowFile:
//                    ShowAllFiles(fullNames, positions);
//                    Console.Write("Нажмите любую клавижу для выхода в меню...");
//                    Console.ReadKey();
//                    break;
//                case CommandToDeleteFile:
//                    DeleteFile(ref fullNames, ref positions);
//                    break;
//                case CommandToSerchBySecondName:
//                    FindBySurname(fullNames, positions);
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

//    static void AddFile(ref string[] fullNames, ref string[] positions)
//    {
//        string fullName;
//        string position;
//        int currentCountOfPersons;

//        Console.Clear();
//        Console.Write("Введите ФИО полностью: ");
//        fullName = Console.ReadLine();

//        Console.Write("Введите должность: ");
//        position = Console.ReadLine();

//        if (fullName.Length > 0 && position.Length > 0)
//        {
//            fullNames = AddToArray(fullNames, fullName);
//            positions = AddToArray(positions, position);
//        }
//    }

//    static void DeleteFile(ref string[] fullNames, ref string[] positions)
//    {
//        int numberForDelete;
//        ShowAllFiles(fullNames, positions);
//        Console.Write("Введите номер для удаления: ");
//        numberForDelete = Convert.ToInt32(Console.ReadLine()) - 1;

//        if (numberForDelete < 0 || numberForDelete >= fullNames.Length)
//        {
//            Console.WriteLine("Такого номера не существует, " +
//                "нажмите любую клавишу");
//            Console.ReadKey();
//        }
//        else
//        {
//            fullNames = DeleteFromArray(fullNames, numberForDelete);
//            positions = DeleteFromArray(positions, numberForDelete);
//        }
//    }

//    static string[] AddToArray(string[] array, string value)
//    {
//        int currentLength;

//        if (array == null)
//            currentLength = 0;
//        else
//            currentLength = array.Length;

//        string[] tempArray = new string[currentLength + 1];

//        for (int i = 0; i < currentLength; i++)
//            tempArray[i] = array[i];

//        tempArray[currentLength] = value;

//        return tempArray;
//    }

//    static string[] DeleteFromArray(string[] array, int numberForDelete)
//    {
//        int currentLength = array.Length;
//        int newIndex = 0;
//        string[] tempArray = new string[currentLength - 1];

//        for (int i = 0; i < currentLength; i++)
//            if (i != numberForDelete)
//            {
//                tempArray[newIndex] = array[i];
//                newIndex++;
//            }

//        return tempArray;
//    }

//    static void ShowAllFiles(string[] fullNames, string[] positions)
//    {
//        Console.Clear();

//        if (IsCatalogClean(fullNames, positions))
//        {
//            Console.WriteLine("Нет ни одного досье!");
//            return;
//        }

//        Console.WriteLine("Каталог досье:");

//        for (int i = 0; i < fullNames.Length; i++)
//            PrintFile(fullNames, positions, i);

//    }

//    static void PrintFile(string[] fullNames, string[] positions,
//        int index)
//    {
//        Console.Write(index + 1 + ". ");
//        Console.WriteLine(fullNames[index] + " - " + positions[index]);
//    }

//    static bool IsCatalogClean(string[] fullNames, string[] positions)
//    {
//        if (fullNames != null && positions != null)
//            if (fullNames.Length > 0 && positions.Length > 0)
//                return false;

//        return true;
//    }

//    static void FindBySurname(string[] fullNames, string[] positions)
//    {
//        string surname;
//        char nameSeparator = ' ';
//        int surnamePosition = 0;

//        Console.Clear();

//        if (IsCatalogClean(fullNames, positions))
//        {
//            Console.WriteLine("Нет ни одного досье!\nНажмите любую клавишу...");
//            Console.ReadKey();
//            return;
//        }

//        Console.Write("Введите фамилию для поиска: ");
//        surname = Console.ReadLine();

//        for (int i = 0; i < fullNames.Length; i++)
//        {
//            string surnameInFile = fullNames[i]
//                .Split(nameSeparator)[surnamePosition];

//            if (surnameInFile.ToLower() == surname.ToLower())
//                PrintFile(fullNames, positions, i);
//        }

//        Console.WriteLine("Нажмите любую клавишу...");
//        Console.ReadKey();
//    }
//}