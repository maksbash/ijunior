//using System.Security.Principal;

//internal class Program
//{
//    private static void Main(string[] args)
//    {
//        int account = 0;
//        Queue<int> shopQueue = new Queue<int>();

//        FillPurchasesQueue(shopQueue);
//        ServiceCustomers(shopQueue, account);

//        Console.WriteLine("\nВсе клиенты обслужены. " +
//            "Нажмите любую клавишу для выхода.");
//        Console.ReadKey();
//    }

//    static void ServiceCustomers(Queue<int> shopQueue, int account)
//    {
//        while (shopQueue.Count > 0)
//        {
//            int purchase = shopQueue.Dequeue();
//            Console.Clear();
//            Console.WriteLine("Сумма покупки клиента: " + purchase);
//            account += purchase;
//            Console.WriteLine("Состояние счета: " + account);
//            Console.WriteLine("\nНажмите любую клавишу для обслуживания " +
//                "следующего клиента.");
//            Console.ReadKey();
//        }
//    }

//    static void FillPurchasesQueue(Queue<int> shopQueue)
//    {
//        int lowerPurchase = 1;
//        int upperPurchase = 100;
//        int lowerQueueLength = 3;
//        int upperQueueLength = 12;
//        Random random = new Random();

//        int queueLength = random.Next(lowerQueueLength, upperQueueLength);

//        for (int i = 0; i < queueLength; i++)
//        {
//            shopQueue.Enqueue(random.Next(lowerPurchase, upperPurchase));
//        }
//    }
//}