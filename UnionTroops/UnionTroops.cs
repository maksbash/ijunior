using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        List<Solder> troopFirst = new List<Solder>
        {
            new Solder("Иванов Иван Иванович", "Автомат", "Солдат", 55),
            new Solder("Бирюков Максим Максимович", "Пистолет", "Полковник", 440),
            new Solder("Петров Петр Петрович", "Пулемет", "Генерал", 321),
            new Solder("Бодров Федор Григорьевич", "Граната", "Подполковник", 61),
            new Solder("Егорова Анастасия Максимовна", "Нож", "Майор", 788),
        };

        List<Solder> troopSecond = new List<Solder>
        {
            new Solder("Шапкин Алексей Дмитриевич", "Гранатомет", "Полковник", 129),
            new Solder("Чувак Ядрён Болеющий", "Нож", "Солдат", 33),
            new Solder("Круглова Алёна Антоновна", "Автомат", "Генерал", 200),
            new Solder("Плющ Артём Колбасович", "Пистолет", "Солдат", 24),
            new Solder("Герасимов Герась Герасьевич", "Автомат", "Солдат", 99),
        };

        char latter = 'Б';

        troopSecond =
            troopSecond.Union(troopFirst.Where(troopFirst =>
            troopFirst.Name.ToUpper().StartsWith(latter))).ToList();

        troopFirst = troopFirst.Where(troopFirst =>
            !troopFirst.Name.ToUpper().StartsWith(latter)).ToList();

        Console.WriteLine("Первый отряд:");

        foreach (var solder in troopFirst)
            Console.WriteLine($"{solder.Name} - {solder.Rank}");

        Console.WriteLine("Второй отряд:");

        foreach (var solder in troopSecond)
            Console.WriteLine($"{solder.Name} - {solder.Rank}");

        Console.ReadKey();
    }
}

class Solder
{
    public Solder(string name, string weapons, string rank, int lifeTime)
    {
        Name = name;
        Weapons = weapons;
        Rank = rank;
        LifeTime = lifeTime;

    }

    public string Name { get; private set; }
    public string Weapons { get; private set; }
    public string Rank { get; private set; }
    public int LifeTime { get; private set; }
}