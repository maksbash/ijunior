//internal class Program
//{
//    private static void Main(string[] args)
//    {
//        const string CommandToSetFirstName = "setFirstName";
//        const string CommandToSetLastName = "setLastName";
//        const string CommandToSetAge = "setAge";
//        const string CommandToSetPlace = "setPlace";
//        const string CommandToSetPassword = "setPassword";
//        const string CommandToChangePassword = "changePassword";
//        const string CommandToShowFullInfo = "showFullInfo";
//        const string CommandToShowPassword = "showPassword";
//        const string CommandToExit = "exit";
//        string currentCommand = "";

//        string firstName = "";
//        string lastName = "";
//        string age = "";
//        string place = "";
//        string password = "";
//        string fullInfo;
//        bool isPasswordSet = false;

//        while (currentCommand != CommandToExit)
//        {
//            fullInfo = firstName;

//            if (lastName != "")
//            {
//                fullInfo += " " + lastName;
//            }

//            if (age != "")
//            {
//                fullInfo += ", возрас " + age;
//            }

//            if (place != "")
//            {
//                fullInfo += ", город " + place;
//            }

//            if (isPasswordSet)
//            {
//                fullInfo += " (пароль установлен)";
//            }

//            else
//            {
//                fullInfo += " (пароль не установлен)";
//            }

//            Console.Write("Меню:\n\t" +
//                $"{CommandToSetFirstName} - Ввести имя\n\t" +
//                $"{CommandToSetLastName} - Ввести фамилию\n\t" +
//                $"{CommandToSetAge} - Ввести возраст\n\t" +
//                $"{CommandToSetPlace} - Ввести город в котором проживаете\n\t" +
//                $"{CommandToSetPassword} - Установить пароль\n\t" +
//                $"{CommandToChangePassword} - Изменить пароль\n\t" +
//                $"{CommandToShowFullInfo} - Вывести информацию\n\t" +
//                $"{CommandToShowPassword} - Показать пароль\n\t" +
//                $"{CommandToExit} - Выход из программы\n" +
//                "Введите команду из меню: ");

//            currentCommand = Console.ReadLine();

//            switch (currentCommand)
//            {
//                case CommandToSetFirstName:
//                    Console.Write("Введите имя: ");
//                    firstName = Console.ReadLine();
//                    break;

//                case CommandToSetLastName:
//                    Console.Write("Введите фамилию: ");
//                    lastName = Console.ReadLine();
//                    break;

//                case CommandToSetAge:
//                    Console.Write("Введите возраст: ");
//                    age = Console.ReadLine();
//                    break;

//                case CommandToSetPlace:
//                    Console.Write("Введите город проживания: ");
//                    place = Console.ReadLine();
//                    break;

//                case CommandToSetPassword:
//                    if (isPasswordSet)
//                    {
//                        Console.WriteLine("Пароль уже установлен!");
//                    }
//                    else
//                    {
//                        Console.Write("Введите пароль: ");
//                        password = Console.ReadLine();
//                        Console.Write("Введите пароль ещё раз: ");
//                        string password2 = Console.ReadLine();

//                        if (password != password2)
//                        {
//                            Console.WriteLine("Пароли не совпадают! попробуйте ещё раз");
//                            password = "";
//                        }
//                        else
//                        {
//                            if (password != "")
//                            {
//                                isPasswordSet = true;
//                            }
//                        }
//                    }

//                    break;

//                case CommandToChangePassword:
//                    if (isPasswordSet)
//                    {
//                        Console.Write("Пароль уже установлен! Введите текущий пароль:");
//                        string password2 = Console.ReadLine();

//                        if (password != password2)
//                        {
//                            Console.WriteLine("Пароль не верный");
//                        }
//                        else
//                        {
//                            Console.Write("Введите новый пароль: ");
//                            string password1 = Console.ReadLine();
//                            Console.Write("Введите новый пароль ещё раз: ");
//                            password2 = Console.ReadLine();

//                            if (password1 != password2)
//                            {
//                                Console.WriteLine("Пароли не совпадают! попробуйте ещё раз");
//                            }
//                            else
//                            {
//                                password = password1;

//                                if (password != "")
//                                {
//                                    isPasswordSet = true;
//                                }
//                                else
//                                {
//                                    isPasswordSet = false;
//                                }
//                            }
//                        }
//                    }
//                    break;

//                case CommandToShowFullInfo:
//                    if (isPasswordSet)
//                    {
//                        Console.Write("Введите пароль: ");
//                        string password2 = Console.ReadLine();

//                        if (password != password2)
//                        {
//                            Console.WriteLine("Неверный пароль");
//                            break;
//                        }
//                    }

//                    Console.WriteLine(fullInfo);
//                    break;

//                case CommandToShowPassword:
//                    if (isPasswordSet)
//                    {
//                        Console.Write("Введите пароль: ");
//                        string password2 = Console.ReadLine();

//                        if (password != password2)
//                        {
//                            Console.WriteLine("Неверный пароль");
//                            break;
//                        }
//                    }

//                    Console.WriteLine(password);
//                    break;

//                case CommandToExit:
//                    Console.WriteLine("Пока");
//                    break;

//                default:
//                    Console.WriteLine("Неизвестная операция, попробуй ещё раз.");
//                    break;
//            }

//            Console.WriteLine();

//        }
//    }
//}