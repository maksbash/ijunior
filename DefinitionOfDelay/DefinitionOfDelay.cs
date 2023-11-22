internal class Program
{
    private static void Main(string[] args)
    {
        List<Stew> stews = new List<Stew>
        {
            new Stew("Тушенка мясо", 1990, 10),
            new Stew("Тушенка индейки", 2021, 3),
            new Stew("Тушенка говядины", 2022, 3),
            new Stew("Тушенка курицы", 2011, 3),
            new Stew("Тушенка без мяса", 2018, 3),
            new Stew("Тушенка без индейки", 2019, 5),
            new Stew("Тушенка всё в одном", 2019, 2),
            new Stew("Тушенка не прогадаешь", 2021, 1),
            new Stew("Тушенка лучшая", 2022, 1),
            new Stew("Тушенка свежая", 1999, 30),
        };

        int currentYear = DateTime.Now.Year;

        Console.WriteLine("Просроченная тушенка");

        foreach (var stew in stews.Where(stews => stews.Year + stews.YearsOfStorage < currentYear))
            stew.Print();

        Console.ReadKey();
    }
}

class Stew
{
    public Stew(string name, int year, int yearsOfStorage)
    {
        Name = name;
        Year = year;
        YearsOfStorage = yearsOfStorage;
    }

    public string Name { get; private set; }
    public int Year { get; private set; }
    public int YearsOfStorage { get; private set; }

    public void Print()
    {
        Console.WriteLine($"{Name}, год изготовления - {Year}, лет хранения - {YearsOfStorage}");
    }
}