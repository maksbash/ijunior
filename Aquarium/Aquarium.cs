internal class Program
{
    private static void Main(string[] args)
    {
        Aquarium aquarium = new Aquarium();
        aquarium.ShowMenu();
    }
}

class Aquarium
{
    private int _minimumFishes = 2;
    private int _maximumFishes = 10;
    private Fish[] _availebleFishes =
        {
            new Fish("Данио леопардовый"),
            new Fish("Барбус вишневый"),
            new Fish("Кардинал золотой"),
            new Fish("Боция мраморная"),
            new Fish("Хомалоптера Стефенсона"),
            new Fish("Рэнчу красная"),
        };
    private List<Fish> _fishes;

    public Aquarium()
    {
        _fishes = new List<Fish>();
        FillRandom();
    }

    public void ShowMenu()
    {
        const string CommandToNextIteration = "1";
        const string CommandToAddFish = "2";
        const string CommandToRemoveFish = "3";
        const string CommandToExit = "9";

        bool isActive = true;

        while (isActive)
        {
            Console.Clear();
            Console.WriteLine("Рыбки в аквариуме:");
            ShowFishes();

            Console.WriteLine();
            Console.WriteLine($"{CommandToNextIteration}. Следующая итерация");
            Console.WriteLine($"{CommandToAddFish}. Добавить рыбку");
            Console.WriteLine($"{CommandToRemoveFish}. Достать рыбку");
            Console.WriteLine($"{CommandToExit}. Выход");

            string currentCommand = Console.ReadLine();

            switch (currentCommand)
            {
                case CommandToNextIteration:
                    NextIteration();
                    break;

                case CommandToAddFish:
                    AddFish();
                    break;

                case CommandToRemoveFish:
                    RemoveFish();
                    break;

                case CommandToExit:
                    isActive = false;
                    break;

                default:
                    Console.WriteLine("Введена недопустимая команда!");
                    break;
            }
        }
    }

    private void ShowFishes()
    {
        int index = 1;

        foreach (Fish fish in _fishes)
        {
            Console.WriteLine($"{index}. {fish.Type}, здоровье {fish.Helth}");
            index++;
        }
    }

    private void NextIteration()
    {
        for (int i = _fishes.Count - 1; i >= 0; i--)
        {
            _fishes[i].GrowOld();

            if (_fishes[i].Helth == 0)
                _fishes.RemoveAt(i);
        }
    }

    private void AddFish()
    {
        Console.Clear();

        if (_fishes.Count >= _maximumFishes)
        {
            Console.WriteLine($"В аквариуме максимальное количество рыб - " +
                $"{_maximumFishes}");
            Console.ReadKey();

            return;
        }

        ShowAvailibleFishes();

        Console.Write("Введите номер рыбки для добавления: ");
        int.TryParse(Console.ReadLine(), out int fishIndex);
        fishIndex--;

        if (fishIndex >= 0 && fishIndex < _availebleFishes.Length)
            _fishes.Add((Fish)_availebleFishes[fishIndex].Clone());
        else
            Console.WriteLine("Ошибка при вводе");
    }

    private void RemoveFish()
    {
        Console.Clear();
        ShowFishes();

        Console.Write("Введите номер рыбки для удаления: ");
        int.TryParse(Console.ReadLine(), out int fishIndex);
        fishIndex--;

        if (fishIndex >= 0 && fishIndex < _fishes.Count)
            _fishes.RemoveAt(fishIndex);
        else
            Console.WriteLine("Ошибка при вводе");
    }

    private void ShowAvailibleFishes()
    {
        Console.WriteLine("Рыбки: ");

        for (int i = 0; i < _availebleFishes.Length; i++)
            Console.WriteLine($"{i + 1} - {_availebleFishes[i].Type}");
    }

    private void FillRandom()
    {
        Random random = new Random();
        int countFishes = random.Next(_minimumFishes, _maximumFishes + 1);

        for (int i = 0; i < countFishes; i++)
        {
            int indexOfFish = random.Next(0, _availebleFishes.Length);
            Fish fish = (Fish)_availebleFishes[indexOfFish].Clone();
            _fishes.Add(fish);
        }
    }
}

class Fish : ICloneable
{
    private Random _random = new Random();

    public Fish(string type)
    {
        int minimumHelth = 3;
        int maximumHelth = 10;
        
        Helth = _random.Next(minimumHelth, maximumHelth + 1);
        Type = type;
    }

    public string Type { get; private set; }
    public int Helth { get; private set; }

    public void GrowOld()
    {
        Helth--;
    }

    public object Clone()
    {
        return new Fish(Type);
    }
}