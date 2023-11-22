internal class Program
{
    private static void Main(string[] args)
    {
        List<Player> players = new List<Player>
        {
            new Player("Иванов Иван Иванович", 55, 100),
            new Player("Максимов Максим Максимович", 44, 200),
            new Player("Петров Петр Петрович", 88, 130),
            new Player("Сидоров Федор Григорьевич", 61, 330),
            new Player("Егорова Анастасия Максимовна", 24, 450),
            new Player("Шапкин Алексей Дмитриевич", 33, 90),
            new Player("Чувак Ядрён Болеющий", 33, 99),
            new Player("Круглова Алёна Антоновна", 25, 201),
            new Player("Плющ Артём Колбасович", 24, 206),
            new Player("Герасимов Герась Герасьевич", 99, 677),
        };

        int countTop = 3;

        Console.WriteLine($"ТОП {countTop} по уровню:");

        foreach (var player in players.OrderByDescending(players => players.Lavel).Take(countTop))
            player.Print();


        Console.WriteLine($"\nТОП {countTop} по силе:");

        foreach (var player in players.OrderByDescending(players => players.Force).Take(countTop))
            player.Print();

        Console.ReadKey();
    }
}

class Player
{
    public Player(string name, int lavel, int force)
    {
        Name = name;
        Lavel = lavel;
        Force = force;
    }

    public string Name { get; private set; }
    public int Lavel { get; private set; }
    public int Force { get; private set; }

    public void Print()
    {
        Console.WriteLine($"{Name}, уровень - {Lavel}, сила - {Force}");
    }
}