internal class Program
{
    private static void Main(string[] args)
    {
        List<Criminal> criminals = new List<Criminal>
        {
            new Criminal("Антон", "Убивец"),
            new Criminal("Максим", "Грабитель"),
            new Criminal("Кирил", "Антиправительственное"),
            new Criminal("Данила", "Душитель"),
            new Criminal("Артём", "Антиправительственное"),
        };

        Console.WriteLine("До амнистии:");

        foreach (var criminal in criminals)
            Console.WriteLine(criminal.Name + " - " + criminal.Crime);

        var filteredCriminals = criminals.Where(criminals => criminals.Crime != "Антиправительственное");

        Console.WriteLine("\nПосле амнистии:");

        foreach (var criminal in filteredCriminals)
            Console.WriteLine(criminal.Name + " - " + criminal.Crime);

        Console.ReadKey();
    }
}

class Criminal
{
    public Criminal(string name, string crime)
    {
        Name = name;
        Crime = crime;
    }

    public string Name { get; private set; }
    public string Crime { get; private set; }
}