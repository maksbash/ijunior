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

        game.Start();
    }
}

class Game
{
    private Deck _deck = new Deck();
    private Queue<Card> _playingDeck;

    public Game(Player player)
    {
        _playingDeck = _deck.MixDeck();
        this.Player = player;
    }

    public Player Player { get; private set; }

    public void Start()
    {
        const string CommandToTakeCard = "1";
        const string CommandToTakeCards = "2";
        const string CommandToShowCards = "3";
        const string CommandToExit = "9";

        bool isActive = true;
        string currentCommand;

        while (isActive)
        {
            if (_playingDeck.Count < 1)
            {
                isActive = FinishIfDeckIsFree();

                if (isActive == false)
                    break;
            }

            Console.Clear();
            Console.WriteLine("Меню игры: ");
            Console.WriteLine($"{CommandToTakeCard} - взять одну карту");
            Console.WriteLine($"{CommandToTakeCards} - взять несколько карт");
            Console.WriteLine($"{CommandToShowCards} - закончить игру и показать карты");
            Console.WriteLine($"{CommandToExit} - выход из игры");
            Console.Write($"{Player.Name} твой выбор: ");
            currentCommand = Console.ReadLine();

            switch (currentCommand)
            {
                case CommandToExit:
                    isActive = false;
                    break;

                case CommandToTakeCard:
                    Player.AddCard(_playingDeck.Dequeue());
                    break;

                case CommandToTakeCards:
                    TakeCards();
                    break;

                case CommandToShowCards:
                    isActive = FinishGame();
                    break;

                default:
                    break;
            }
        }
    }

    private bool FinishIfDeckIsFree()
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
        Player.ShowCards();

        Console.WriteLine("Нажмите любую клавишу.");
        Console.ReadKey();

        while (isActive)
        {
            isActive = false;

            Console.Clear();
            Console.WriteLine("Меню:");
            Console.WriteLine($"{CommandToNewGame} - начать новую игру");
            Console.WriteLine($"{CommandToExit} - выход из игры");
            Console.Write($"{Player.Name} твой выбор: ");
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
        _playingDeck = _deck.MixDeck();
        Player.ResetCards();
    }

    private void TakeCards()
    {
        int countCards;
        string userInput;

        Console.Write("Введите количество карт: ");
        userInput = Console.ReadLine();

        if (int.TryParse(userInput, out countCards))
            if (countCards <= _playingDeck.Count)
                for (int i = 0; i < countCards; i++)
                    Player.AddCard(_playingDeck.Dequeue());
            else
                Console.WriteLine("\nВ колоде осталось меньше карт " +
                    "чем вам требуется");
        else
            Console.WriteLine("\nОшибка при вводе. Необходимо ввести число.");

        Console.WriteLine("\nНажмите любую клавишу...");
        Console.ReadKey();
    }

}

class Player
{
    private List<Card> _cards = new List<Card>();

    public Player(string name, bool isAI = false)
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

    public Deck()
    {
        GenerateDeck36For21();
    }

    public Queue<Card> MixDeck()
    {
        int lowerBoundIndex = 0;
        int upperBoundIndex;
        Random random = new Random();

        Queue<Card> mixedDeck = new Queue<Card>();
        List<Card> copyDeck = new List<Card>(_cards);

        do
        {
            upperBoundIndex = copyDeck.Count;
            int index = random.Next(lowerBoundIndex, upperBoundIndex);
            mixedDeck.Enqueue(copyDeck[index]);
            copyDeck.RemoveAt(index);
        } while (copyDeck.Count > 0);

        return mixedDeck;
    }

    public void PrintDeck()
    {
        foreach (Card card in _cards)
        {
            card.Draw();
            Console.WriteLine();
        }
    }

    private void GenerateDeck36For21()
    {
        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            foreach (CardValue cardValue in Enum.GetValues(typeof(CardValue)))
                _cards.Add(new Card(cardValue, suit));
    }
}

enum Suit
{
    clubs = '\x05',
    diamonds = '\x04',
    hearts = '\x03',
    spades = '\x06'
}

enum CardValue
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
    public Card(CardValue cardValue, Suit suit)
    {
        CardValue = cardValue;
        Suit = suit;
    }

    public CardValue CardValue { get; private set; }
    public Suit Suit { get; private set; }

    public void Draw()
    {
        Console.Write($"|\t{CardValue}({Suit})\t|\n");
    }
}
