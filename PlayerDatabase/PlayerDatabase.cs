internal class Program
{
    private static void Main(string[] args)
    {
        const string CommandToAddPlayer = "1";
        const string CommandToDeletePlayer = "2";
        const string CommandToBanPlayer = "3";
        const string CommandToUnbanPlayer = "4";
        const string CommandToShowDatabase = "5";
        const string CommandToExit = "6";

        Database playersDataBase = new Database();

        bool isActive = true;
        string currentCommand;

        while (isActive)
        {
            Console.Clear();
            Console.WriteLine("Меню:");
            Console.WriteLine($"{CommandToAddPlayer} Добавить игрока");
            Console.WriteLine($"{CommandToDeletePlayer} Удалить игрока");
            Console.WriteLine($"{CommandToBanPlayer} Забанить игрока");
            Console.WriteLine($"{CommandToUnbanPlayer} Разбанить игрока");
            Console.WriteLine($"{CommandToShowDatabase} Вывести базу данных игроков");
            Console.WriteLine($"{CommandToExit} Выход");
            Console.Write("Введите команду: ");

            currentCommand = Console.ReadLine();

            Console.WriteLine();

            switch (currentCommand)
            {
                case CommandToAddPlayer:
                    playersDataBase.AddPlayer();
                    break;

                case CommandToDeletePlayer:
                    playersDataBase.RemovePlayer();
                    break;

                case CommandToBanPlayer:
                    playersDataBase.BanPlayer();
                    break;

                case CommandToUnbanPlayer:
                    playersDataBase.UnbanPlayer();
                    break;

                case CommandToShowDatabase:
                    playersDataBase.ShowAllPlayers();
                    break;

                case CommandToExit:
                    isActive = false;
                    break;

                default:
                    Console.WriteLine("Такой команды не существует");
                    break;
            }

            Console.WriteLine("Нажмителю любую клавишу для продолжения.");
            Console.ReadKey();
        }
    }
}

class Database
{
    static private int _lastPlayerId = -1;
    private List<Player> _players = new List<Player>();

    public void AddPlayer()
    {
        string nickName;
        Console.Write("Введите имя игрока: ");
        nickName = Console.ReadLine();

        Player player = new Player(++_lastPlayerId, nickName, 0, true);
        _players.Add(player);
    }

    public void RemovePlayer()
    {
        Console.Write("Введите id игрока для удаления: ");

        if (TryGetPlayer(Console.ReadLine(), out Player player))
            _players.Remove(player);
    }

    public void BanPlayer()
    {
        Console.Write("Введите id игрока чтобы забанить: ");

        if (TryGetPlayer(Console.ReadLine(), out Player player))
            player.Ban();
    }

    public void UnbanPlayer()
    {
        Console.Write("Введите id игрока чтобы разбанить: ");

        if (TryGetPlayer(Console.ReadLine(), out Player player))
            player.Unban();
    }

    public void ShowAllPlayers()
    {
        foreach (Player player in _players)
            player.ShowInfo();
    }

    private bool TryGetPlayer(string userInput, out Player player)
    {
        if (int.TryParse(userInput, out int playerId))
        {
            foreach (Player playerInDatabase in _players)
            {
                if (playerInDatabase.Id == playerId)
                {
                    player = playerInDatabase;

                    return true;
                }
            }
        }

        player = null;

        return false;
    }
}

class Player
{
    public Player(int id, string nickName, int lavel, bool isActive = true)
    {
        Id = id;
        NikName = nickName;
        Lavel = lavel;
        IsActive = isActive;
    }

    public int Id { get; private set; }
    public string NikName { get; private set; }
    public int Lavel { get; private set; }
    public bool IsActive { get; private set; }

    public void ShowInfo()
    {
        Console.WriteLine($"{Id}, ник {NikName}, уровень {Lavel}, " +
            $"активный {IsActive}");
    }

    public void Ban()
    {
        IsActive = false;
    }

    public void Unban()
    {
        IsActive = true;
    }
}
