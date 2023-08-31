internal class Program
{
    private static void Main(string[] args)
    {
        string name;
        Player player;
        Game game;

        Console.Write("Добро пожаловать, представьтесь пожалуйста: ");
        name = Console.ReadLine();

        player = new Player(name);
        game = new Game(player);

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
            if (_deck.Count() < 1)
            {
                isActive = GoToEnd();

                if (isActive == false)
                    break;
            }

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
                    isActive = FinishGame();
                    break;

                default:
                    break;
            }
        }
    }

    private bool GoToEnd()
    {
        Console.WriteLine("\nВ колоде не осталось больше карт.");
        return FinishGame();
    }

    private bool FinishGame()
    {
        const string CommandToNewGame = "1";
        const string CommandToExit = "9";

        string currentCommand;
        bool isNewGame = true;
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
            Console.WriteLine($"{CommandToNewGame} - начать новую игру");
            Console.WriteLine($"{CommandToExit} - выход из игры");
            Console.Write($"{_player.Name} твой выбор: ");
            currentCommand = Console.ReadLine();

            switch (currentCommand)
            {
                case CommandToNewGame:
                    StartNewGame();
                    break;

                case CommandToExit:
                    isNewGame = false;
                    break;

                default:
                    isActive = true;
                    break;
            }
        }

        Console.Clear();

        return isNewGame;
    }

    private void StartNewGame()
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
            if (countCards <= _deck.Count())
                for (int i = 0; i < countCards; i++)
                    _player.AddCard(_deck.GiveCard());
            else
                Console.WriteLine("\nВ колоде осталось меньше карт " +
                    "чем вам требуется");
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
        _cards = new List<Card>();
    }

    public void ShowCards()
    {
        foreach (Card card in _cards)
            card.Draw();
    }

    public void AddCard(Card card)
    {
        _cards.Add(card);
    }
}

class Deck
{
    private List<Card> _cards = new List<Card>();
    private Queue<Card> _mixedCards = new Queue<Card>();

    public Deck()
    {
        GenerateDeck36For21();
        MixDeck();
    }

    public Card GiveCard()
    {
        return _mixedCards.Dequeue();
    }

    public int Count()
    {
        return _mixedCards.Count;
    }

    private void MixDeck()
    {
        int lowerBoundIndex = 0;
        int upperBoundIndex;
        Random random = new Random();

        List<Card> copyDeck = new List<Card>(_cards);

        do
        {
            upperBoundIndex = copyDeck.Count;
            int index = random.Next(lowerBoundIndex, upperBoundIndex);
            _mixedCards.Enqueue(copyDeck[index]);
            copyDeck.RemoveAt(index);
        } while (copyDeck.Count > 0);

    }

    private void GenerateDeck36For21()
    {
        _cards = new List<Card>();

        Suit[] suits = (Suit[])Enum.GetValues(typeof(Suit));

        foreach (Suit suit in suits)
        {
            Value[] values = (Value[])Enum.GetValues(typeof(Value));

            foreach (Value value in values)
                _cards.Add(new Card(value, suit));
        }
    }
}

enum Suit
{
    Clubs = '\x05',
    Diamonds = '\x04',
    Hearts = '\x03',
    Spades = '\x06'
}

enum Value
{
    N6 = 6,
    N7 = 7,
    N8 = 8,
    N9 = 9,
    N10 = 10,
    J = 2,
    D = 3,
    K = 4,
    A = 11
}

class Card
{
    public Card(Value value, Suit suit)
    {
        Value = value;
        Suit = suit;
    }

    public Value Value { get; private set; }
    public Suit Suit { get; private set; }

    public void Draw()
    {
        Console.Write($"|\t{Value}({Suit})\t|\n");
    }
}
