
internal class Program
{
    private static void Main(string[] args)
    {
        List<string> uniqueNumbers = new List<string>();
        string[] numbersOne = FillArray();
        string[] numbersTwo = FillArray();

        Console.Write("Первый массив: ");
        PrintArray(numbersOne);
        Console.Write("\nВторой массив: ");
        PrintArray(numbersTwo);

        AddUniqueElements(numbersOne, uniqueNumbers);
        AddUniqueElements(numbersTwo, uniqueNumbers);
        Console.Write("\nОбъединённый массив: ");
        PrintArray(uniqueNumbers.ToArray());
        Console.ReadKey();
    }

    static void AddUniqueElements(string[] array, List<string> uniqueArray)
    {
        foreach (string item in array)
            if (uniqueArray.Contains(item) == false)
                uniqueArray.Add(item);
    }

    static string[] FillArray()
    {
        int lowerBoundValue = 0;
        int upperBoundValue = 9;
        int lowerBoundLength = 2;
        int upperBoundLength = 10;
        string[] array;

        Random random = new Random();
        int length = random.Next(lowerBoundLength, upperBoundLength);
        array = new string[length];

        for (int i = 0; i < length; i++)
        {
            int randomNumber = random.Next(lowerBoundValue, upperBoundValue);
            array[i] = Convert.ToString(randomNumber);
        }

        return array;
    }

    static void PrintArray(string[] array)
    {
        if (array.Length > 0)
            foreach (string item in array)
                Console.Write(item + " ");
    }
}