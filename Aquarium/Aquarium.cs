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
    private Fish[] _fishes =
        {
            new Fish("Данио леопардовый"),
            new Fish("Барбус вишневый"),
            new Fish("Кардинал золотой"),
            new Fish("Боция мраморная"),
            new Fish("Хомалоптера Стефенсона"),
            new Fish("Рэнчу красная"),
        };

    public Aquarium()
    {
        Fishes = new List<Fish>();
        RandomFill();
    }

    public List<Fish> Fishes { get; private set; }

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

    public void ShowFishes()
    {
        int index = 1;

        foreach (Fish fish in Fishes)
        {
            Console.WriteLine($"{index}. {fish.Type}, здоровье {fish.Helth}");
            index++;
        }
    }

    public void NextIteration()
    {
        for (int i = 0; i < Fishes.Count; i++)
        {
            Fishes[i].GrowOld();

            if (Fishes[i].Helth == 0)
                Fishes.RemoveAt(i);
        }
    }

    public void AddFish()
    {
        Console.Clear();

        if (Fishes.Count >= 10)
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

        if (fishIndex >= 0 && fishIndex < _fishes.Length)
            Fishes.Add((Fish)_fishes[fishIndex].Clone());
        else
            Console.WriteLine("Ошибка при вводе");
    }

    public void RemoveFish()
    {
        Console.Clear();
        ShowFishes();

        Console.Write("Введите номер рыбки для удаления: ");
        int.TryParse(Console.ReadLine(), out int fishIndex);
        fishIndex--;

        if (fishIndex >= 0 && fishIndex < Fishes.Count)
            Fishes.RemoveAt(fishIndex);
        else
            Console.WriteLine("Ошибка при вводе");
    }

    private void ShowAvailibleFishes()
    {
        Console.WriteLine("Рыбки: ");

        for (int i = 0; i < _fishes.Length; i++)
            Console.WriteLine($"{i + 1} - {_fishes[i].Type}");
    }

    private void RandomFill()
    {
        Random random = new Random();
        int countFishes = random.Next(_minimumFishes, _maximumFishes + 1);

        for (int i = 0; i < countFishes; i++)
        {
            int indexOfFish = random.Next(0, _fishes.Length);
            Fish fish = (Fish)_fishes[indexOfFish].Clone();
            Fishes.Add(fish);
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