//internal class Program
//{
//    private static void Main(string[] args)
//    {
//        const string CommandToExchangeRubbleToDollar = "rd";
//        const string CommandToExchangeDollarToRubble = "dr";
//        const string CommandToExchangeEuroToRubble = "er";
//        const string CommandToExchangeRubbleToEuro = "re";
//        const string CommandToExchangeDollarToEuro = "de";
//        const string CommandToExchangeEuroToDollar = "ed";
//        const string CommandToExit = "exit";

//        float euroToDollarRate = 0.8f;
//        float dollarToEuroRate = 1.2f;
//        float euroToRubbleRate = 81f;
//        float rubbleToEuroRate = 0.02f;
//        float dollarToRubleRate = 72f;
//        float rubbleToDollarRate = 0.03f;

//        float dollarBallance = 41f;
//        float rubbleBallance = 2189f;
//        float euroBallance = 121f;
//        float amountToExchange;

//        string currentExchageCode = "";
//        bool isWork = true;

//        while (isWork)
//        {
//            Console.WriteLine($"Ваш баланс:\n\tРубли = {rubbleBallance}\n\t" +
//                $"Доллары = {dollarBallance}\n\tЕвро = {euroBallance}");

//            Console.WriteLine($"Курсы валют:\n\t" +
//                $"Евро/Доллар - купить {euroToDollarRate}; продать {dollarToEuroRate}\n\t" +
//                $"Евро/Рубль - купить {euroToRubbleRate}; продать {rubbleToEuroRate}\n\t" +
//                $"Доллар/Рубль - купить {dollarToRubleRate}; продать {rubbleToDollarRate}");

//            Console.Write($"Чтобы конвертировать валюту наберите команду из " +
//                "следующих вариантов:\n\t" +
//                $"{CommandToExchangeRubbleToDollar} - рубли в доллары\n\t" +
//                $"{CommandToExchangeDollarToRubble} - доллоры в рубли\n\t" +
//                $"{CommandToExchangeRubbleToEuro} - рубли в евро\n\t" +
//                $"{CommandToExchangeEuroToRubble} - евро в рубли\n\t" +
//                $"{CommandToExchangeDollarToEuro} - доллары в евро\n\t" +
//                $"{CommandToExchangeEuroToDollar} - евро в доллары\n" +
//                $"Команда для перевода или {CommandToExit} для выхода: ");

//            currentExchageCode = Console.ReadLine();

//            switch (currentExchageCode)
//            {
//                case CommandToExchangeDollarToEuro:
//                    Console.Write("Введите количество долларов для перевода в евро: ");
//                    amountToExchange = Convert.ToSingle(Console.ReadLine());

//                    if (amountToExchange > dollarBallance)
//                    {
//                        Console.WriteLine("У вас недостаточно средств для совершения операции!");
//                        break;
//                    }

//                    dollarBallance -= amountToExchange;
//                    euroBallance += amountToExchange * dollarToEuroRate;
//                    break;

//                case CommandToExchangeEuroToDollar:
//                    Console.Write("Введите количество евро для перевода в доллары: ");
//                    amountToExchange = Convert.ToSingle(Console.ReadLine());

//                    if (amountToExchange > euroBallance)
//                    {
//                        Console.WriteLine("У вас недостаточно средств для совершения операции!");
//                        break;
//                    }

//                    euroBallance -= amountToExchange;
//                    dollarBallance += amountToExchange * euroToDollarRate;
//                    break;

//                case CommandToExchangeDollarToRubble:
//                    Console.Write("Введите количество долларов для перевода в рубли: ");
//                    amountToExchange = Convert.ToSingle(Console.ReadLine());

//                    if (amountToExchange > dollarBallance)
//                    {
//                        Console.WriteLine("У вас недостаточно средств для совершения операции!");
//                        break;
//                    }

//                    dollarBallance -= amountToExchange;
//                    rubbleBallance += amountToExchange * dollarToRubleRate;
//                    break;

//                case CommandToExchangeRubbleToDollar:
//                    Console.Write("Введите количество рублей для перевода в доллары: ");
//                    amountToExchange = Convert.ToSingle(Console.ReadLine());

//                    if (amountToExchange > rubbleBallance)
//                    {
//                        Console.WriteLine("У вас недостаточно средств для совершения операции!");
//                        break;
//                    }

//                    rubbleBallance -= amountToExchange;
//                    dollarBallance += amountToExchange * rubbleToDollarRate;
//                    break;

//                case CommandToExchangeRubbleToEuro:
//                    Console.Write("Введите количество рублей для перевода в евро: ");
//                    amountToExchange = Convert.ToSingle(Console.ReadLine());

//                    if (amountToExchange > rubbleBallance)
//                    {
//                        Console.WriteLine("У вас недостаточно средств для совершения операции!");
//                        break;
//                    }

//                    rubbleBallance -= amountToExchange;
//                    euroBallance += amountToExchange * rubbleToEuroRate;
//                    break;

//                case CommandToExchangeEuroToRubble:
//                    Console.Write("Введите количество евро для перевода в рубли: ");
//                    amountToExchange = Convert.ToSingle(Console.ReadLine());

//                    if (amountToExchange > rubbleBallance)
//                    {
//                        Console.WriteLine("У вас недостаточно средств для совершения операции!");
//                        break;
//                    }

//                    euroBallance -= amountToExchange;
//                    rubbleBallance += amountToExchange * euroToRubbleRate;
//                    break;

//                case CommandToExit:
//                    isWork = false;
//                    Console.WriteLine("Досвидания.");
//                    break;

//                default:
//                    Console.WriteLine("Неизвестная операция, попробуй ещё раз.");
//                    break;
//            }

//        }
//    }
//}