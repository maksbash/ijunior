//internal class Program
//{
//    private static void Main(string[] args)
//    {
//        string secretMessage = "Очень секретное сообщение!!";
//        string password = "123";

//        string userPassword;
//        int maxAttempts = 3;
//        int remainingAttempts;

//        for (int i = 0; i < maxAttempts; i++)
//        {

//            if (i > 0)
//            {
//                remainingAttempts = maxAttempts - i;
//                Console.WriteLine($"Пароль неверный. Осталось попыток - {remainingAttempts}: ");
//            }

//            Console.Write("Введите пароль, чтобы увидеть секретное сообщение: ");
//            userPassword = Console.ReadLine();

//            if (userPassword == password)
//            {
//                Console.WriteLine(secretMessage);
//                break;
//            }
//        }
//    }
//}