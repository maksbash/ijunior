internal class Program
{
    private static void Main(string[] args)
    {
        List<Sick> sicks = new List<Sick>
        {
            new Sick("Иванов Иван Иванович", 55, "Диабет"),
            new Sick("Максимов Максим Максимович", 44, "Астма"),
            new Sick("Петров Петр Петрович", 88, "Амнезия"),
            new Sick("Сидоров Федор Григорьевич", 61, "Грипп"),
            new Sick("Егорова Анастасия Максимовна", 24, "КОВИД"),
            new Sick("Шапкин Алексей Дмитриевич", 33, "Грипп"),
            new Sick("Чувак Ядрён Болеющий", 33, "ОРВИ"),
            new Sick("Круглова Алёна Антоновна", 25, "КОВИД"),
            new Sick("Плющ Артём Колбасович", 24, "ОРВИ"),
            new Sick("Герасимов Герась Герасьевич", 99, "ВСЁ БОЛИТ"),
        };

        Console.WriteLine("Больные по алфавиту:");

        foreach (var sick in sicks.OrderBy(sicks => sicks.Name))
            sick.Print();


        Console.WriteLine("\nБольные по возрасту:");

        foreach (var sick in sicks.OrderBy(sicks => sicks.Age))
            sick.Print();

        Console.Write("\nВведите диагноз:");
        string disease = Console.ReadLine();

        foreach (var sick in sicks.Where(sicks => sicks.Disease.ToLower() == disease.ToLower()))
            sick.Print();

        Console.ReadKey();
    }
}

class Sick
{
    public Sick(string name, int age, string disease)
    {
        Name = name;
        Age = age;
        Disease = disease;
    }

    public string Name { get; private set; }
    public int Age { get; private set;  }
    public string Disease { get; private set;  }

    public void Print()
    {
        Console.WriteLine($"{Name}, возраст - {Age}, диагноз - {Disease}");
    }
}