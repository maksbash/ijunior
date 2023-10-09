internal class Zoo
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}

class Aviary
{
    private List<Animal> _animals;

    public Aviary(Animal animal, int count)
    {
        _animals = new List<Animal>();

        for (int i = 0; i < count; i++) 
        { 
            _animals.Add(animal);
        }
    }

    public int Count
    {
        get
        {
            return _animals.Count;
        }
    }
}

class Giraffe : Animal
{
    public Giraffe(Gender gender)
    {
        Gender = gender;
        Sound = "Уиххаа";
    }
}

class Zebra : Animal
{
    public Zebra(Gender gender)
    {
        Gender = gender;
        Sound = "Тыгыдык";
    }
}

class Panther : Animal
{
    public Panther(Gender gender)
    {
        Gender = gender;
        Sound = "Ауррр";
    }
}

class Lion : Animal
{
    public Lion(Gender gender)
    {
        Gender = gender;
        Sound = "Рррр";
    }
}

abstract class Animal
{
    public Gender Gender { get; protected set; }
    public string Sound { get; protected set; }
}

enum Gender
{
    Male,
    Female
}