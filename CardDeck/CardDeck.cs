internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Добро пожаловать, представьтесь пожалуйста: ");
        string name = Console.ReadLine();

        Player player = new Player(name);
        Game game = new Game(player);

        game.Play();
    }
}

class Game
{
    private Deck _deck = new Deck();
    private Player _player;

    public Game(Player player)
    {
        _player = player;
    }

    public void Play()
    {
        const string CommandToTakeCard = "1";
        const string CommandToTakeCards = "2";
        const string CommandToShowCards = "3";
        const string CommandToExit = "9";

        bool isActive = true;
        string currentCommand;

        while (isActive)
        {
            Console.Clear();
            Console.WriteLine("Меню игры: ");
            Console.WriteLine($"{CommandToTakeCard} - взять одну карту");
            Console.WriteLine($"{CommandToTakeCards} - взять несколько карт");
            Console.WriteLine($"{CommandToShowCards} - закончить игру и показать карты");
            Console.WriteLine($"{CommandToExit} - выход из игры");
            Console.Write($"{_player.Name} твой выбор: ");
            currentCommand = Console.ReadLine();

            switch (currentCommand)
            {
                case CommandToExit:
                    isActive = false;
                    break;

                case CommandToTakeCard:
                    _player.AddCard(_deck.GiveCard());
                    break;

                case CommandToTakeCards:
                    DealCards();
                    break;

                case CommandToShowCards:
                    isActive = End();
                    break;

                default:
                    Console.WriteLine("Такой команды не существует");
                    break;
            }

            if (_deck.Count < 1)
            {
                Console.WriteLine("\nВ колоде не осталось больше карт!");
                isActive = End();
            }
        }
    }

    private bool End()
    {
        const string CommandToNew = "1";
        const string CommandToExit = "9";

        string currentCommand;
        bool isNew = true;
        bool isActive = true;

        Console.WriteLine("\nИгра окончена.");
        Console.WriteLine("Ваши карты: ");
        _player.ShowCards();

        Console.WriteLine("Нажмите любую клавишу.");
        Console.ReadKey();

        while (isActive)
        {
            isActive = false;

            Console.Clear();
            Console.WriteLine("Меню:");
            Console.WriteLine($"{CommandToNew} - начать новую игру");
            Console.WriteLine($"{CommandToExit} - выход из игры");
            Console.Write($"{_player.Name} твой выбор: ");
            currentCommand = Console.ReadLine();

            switch (currentCommand)
            {
                case CommandToNew:
                    StartNew();
                    break;

                case CommandToExit:
                    isNew = false;
                    break;

                default:
                    isActive = true;
                    break;
            }
        }

        Console.Clear();

        return isNew;
    }

    private void StartNew()
    {
        _deck = new Deck();
        _player.ResetCards();
    }

    private void DealCards()
    {
        int countCards;
        string userInput;

        Console.Write("Введите количество карт: ");
        userInput = Console.ReadLine();

        if (int.TryParse(userInput, out countCards))
        {
            if (countCards <= _deck.Count)
            {
                for (int i = 0; i < countCards; i++)
                    _player.AddCard(_deck.GiveCard());
            }
            else
            {
                Console.WriteLine("\nВ колоде осталось меньше карт " +
                    "чем вам требуется");
            }
        }
        else
        {
            Console.WriteLine("\nОшибка при вводе. Необходимо ввести число.");
        }

        Console.WriteLine("\nНажмите любую клавишу...");
        Console.ReadKey();
    }

}

class Player
{
    private List<Card> _cards = new List<Card>();

    public Player(string name)
    {
        Name = name;
    }

    public string Name { get; private set; }

    public void ResetCards()
    {
        _cards.Clear();
    }

    public void ShowCards()
    {
        foreach (Card card in _cards)
            card.Draw();
    }

    public void AddCard(Card card)
    {
        if (card is not null)
            _cards.Add(card);
    }
}

class Deck
{
    private Queue<Card> _mixedCards = new Queue<Card>();

    public Deck()
    {
        Create();
    }

    public int Count {
        get
        {
            return _mixedCards.Count;
        }

        private set { }
    }

    public Card GiveCard()
    {
        if (Count > 0)
            return _mixedCards.Dequeue();
        else
        {
            Console.WriteLine("Закончились карты в колоде!");
            return null;
        }
    }

    private void Create()
    {
        List<Card> cards = new List<Card>();

        List<string> suits = new List<string>
        {
            "Cubes",
            "Diamonds",
            "Hearts",
            "Spades"
        };

        List<string> values = new List<string>
        {
            "6", "7", "8", "9", "10", "J", "D", "K", "A"
        };

        foreach (string suit in suits)
        {
            foreach (string value in values)
                cards.Add(new Card(value, suit));
        }

        Random random = new Random();

        do
        {
            int index = random.Next(cards.Count);
            _mixedCards.Enqueue(cards[index]);
            cards.RemoveAt(index);
        } while (cards.Count > 0);
    }
}

class Card
{
    public Card(string value, string suit)
    {
        Value = value;
        Suit = suit;
    }

    public string Value { get; private set; }
    public string Suit { get; private set; }

    public void Draw()
    {
        Console.Write($"|\t{Value}({Suit})\t|\n");
    }
}
