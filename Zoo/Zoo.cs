using System.CodeDom.Compiler;

internal class Program
{
    private static void Main(string[] args)
    {
        Zoo zoo = new Zoo();
        zoo.ShowMenu();
    }
}

class Zoo
{
    private List<Aviary> _aviaries = new List<Aviary>();

    public Zoo() 
    {
        GenerateAviaries();
    }

    public int AviariesCount 
    { 
        get 
        { 
            return _aviaries.Count; 
        }

        private set { }
    }

    public void ShowMenu()
    {
        const string CommandToExit = "exit";

        bool isActive = true;
        int userNumber = -1;

        while (isActive)
        {
            Console.Clear();
            Console.WriteLine($"В зоопарке находится {AviariesCount} вольеров");
            Console.Write($"Введите номер вальера чтобы подойти или {CommandToExit} для выхода: ");
            string userCommand = Console.ReadLine();
            if (userCommand == CommandToExit)
            {
                isActive = false;
            }
            else
            {

                int.TryParse(userCommand, out userNumber);

                if (userNumber < 1 || userNumber > AviariesCount)
                {
                    Console.WriteLine("Вы ввели неверую команду, " +
                        "попробуйте ещё раз.");
                    Console.ReadKey();
                }
                else
                {
                    _aviaries[--userNumber].ShowInfo();
                }
            }
        }
    }

    private void GenerateAviaries()
    {
        int minAnimals = 2;
        int maxAnimals = 200;

        int giraffeCount = UserUtils.GenerateRandomNumber(minAnimals, maxAnimals);
        int zebraCount = UserUtils.GenerateRandomNumber(minAnimals, maxAnimals);
        int pantherCount = UserUtils.GenerateRandomNumber(minAnimals, maxAnimals);
        int lionCount = UserUtils.GenerateRandomNumber(minAnimals, maxAnimals);

        Aviary giraffeAviary = new Aviary(new Giraffe(Gender.Male), giraffeCount);
        Aviary zebraAviary = new Aviary(new Zebra(Gender.Male), zebraCount);
        Aviary pantherAviary = new Aviary(new Panther(Gender.Male), pantherCount);
        Aviary lionAviary = new Aviary(new Lion(Gender.Male), lionCount);

        _aviaries.Add(giraffeAviary);
        _aviaries.Add(zebraAviary);
        _aviaries.Add(pantherAviary);
        _aviaries.Add(lionAviary);
    }
}

class Aviary
{
    private List<Animal> _animals;

    public Aviary(Animal animal, int count)
    {
        _animals = new List<Animal>();

        for (int i = 0; i < count; i++) 
            _animals.Add(animal.Clone());
    }

    public void ShowInfo()
    {
        int maleCount = 0;
        int femaleCount = 0;

        foreach (Animal animal in _animals)
            if (animal.Gender == Gender.Male)
                maleCount++;
            else
                femaleCount++;

        Console.Clear();
        Console.WriteLine($"В вольере нажодится животное {_animals[0].Name}");
        Console.WriteLine($"Насчитывается {_animals.Count} осыбей");
        Console.WriteLine($"Среди них {maleCount} мужских осыбей " +
            $"и {femaleCount} женских");
        Console.WriteLine($"Обычно они издают звук похожий " +
            $"на \"{_animals[0].Sound}\"");
        Console.ReadKey();
    }
}

class Giraffe : Animal
{
    public Giraffe(Gender gender)
    {
        Gender = gender;
        Sound = "Уиххаа";
        Name = "Жираф";
    }

    public override Giraffe Clone()
    {
        return new Giraffe(UserUtils.GetRandomGender());
    }
}

class Zebra : Animal
{
    public Zebra(Gender gender)
    {
        Gender = gender;
        Sound = "Тыгыдык";
        Name = "Зебра";
    }

    public override Zebra Clone()
    {
        return new Zebra(UserUtils.GetRandomGender());
    }
}

class Panther : Animal
{
    public Panther(Gender gender)
    {
        Gender = gender;
        Sound = "Ауррр";
        Name = "Пантера";
    }

    public override Panther Clone()
    {
        return new Panther(UserUtils.GetRandomGender());
    }
}

class Lion : Animal
{
    public Lion(Gender gender)
    {
        Gender = gender;
        Sound = "Рррр";
        Name = "Лев";
    }

    public override Lion Clone()
    {
        return new Lion(UserUtils.GetRandomGender());
    }
}

abstract class Animal
{
    public Gender Gender { get; protected set; }
    public string Sound { get; protected set; }
    public string Name { get; protected set; }

    public abstract Animal Clone();
}

enum Gender
{
    Male,
    Female
}

class UserUtils
{
    private static Random _random = new Random();

    public static Gender GetRandomGender()
    {
        int minGender = 0;
        int maxGender = 1;
        int genderIndex = _random.Next(minGender, maxGender + 1);

        return (Gender)genderIndex;
    }

    public static int GenerateRandomNumber(int min, int max)
    {
        return _random.Next(min, max);
    }
}