internal class Program
{
    private static void Main(string[] args)
    {
        Random random = new Random();

        Console.WriteLine(random.Next(0, 2));

        Console.ReadKey();
    }
}