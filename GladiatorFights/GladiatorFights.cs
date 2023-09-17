using System;

internal class Program
{
    private static void Main(string[] args)
    {
        int GladiatorOneXPosition = 0;
        int GladiatorOneYPosition = 2;
        int GladiatorTwoXPosition = 50;
        int GladiatorTwoYPosition = 2;
        int GladiatorsYPosition = 2;

        Gladiator[] gladiators = {
            new Gaal("Гал"),
            new Andabat("Анабат"),
            new Bestiary("Bestiariy"),
            new Lekveary("Лекверарий"),
            new Retiary("Ретарий")
        };

        Gladiator gladiatorOne;
        Gladiator gladiatorTwo;
        bool isActive = true;

        while (isActive)
        {
            Console.WriteLine("Гладиаторы: ");
            int index = 1;

            foreach (Gladiator gladiator in gladiators)
                Console.WriteLine(index++ + ". " + gladiator.GetDescription());

            Console.Write("Введите номер 1-го гладиатора: ");
            if (TryGetGladiator(Console.ReadLine(), out gladiatorOne) == false)
                continue;
            Console.Write("Введите номер 2-го гладиатора: ");
            if (TryGetGladiator(Console.ReadLine(), out gladiatorTwo) == false)
                continue;

            isActive = false;

            Console.Clear();
            Console.WriteLine("Дерутся следующие гладиаторы: ");
            Console.WriteLine(gladiatorOne.GetDescription());
            Console.WriteLine(gladiatorTwo.GetDescription());
            GladiatorsYPosition += 2;

            Console.SetCursorPosition(GladiatorOneXPosition, GladiatorsYPosition);
            Console.Write($"{gladiatorOne.Name}");
            Console.SetCursorPosition(GladiatorTwoXPosition, GladiatorsYPosition++);
            Console.Write($"{gladiatorTwo.Name}");

            float defaultHelthOne = gladiatorOne.Health / 10;
            float defaultHelthTwo = gladiatorTwo.Health / 10;

            Console.WriteLine();
            while (gladiatorOne.Health > 0 && gladiatorTwo.Health > 0)
            {
                Round r = new Round();
                r.DrawBar((int)(gladiatorOne.Health / defaultHelthOne), GladiatorOneXPosition, GladiatorsYPosition);
                r.DrawBar((int)(gladiatorTwo.Health / defaultHelthTwo), GladiatorTwoXPosition, GladiatorsYPosition);

                Console.WriteLine();
                (int CurrentPositionX, int CurrentPositionY) = Console.GetCursorPosition();

                gladiatorOne.TakeDamage(gladiatorTwo.Damage);
                gladiatorTwo.TakeDamage(gladiatorOne.Damage);
                Console.SetCursorPosition(GladiatorOneXPosition, CurrentPositionY);
                Console.Write($"{gladiatorOne.Health}");
                Console.SetCursorPosition(GladiatorTwoXPosition, CurrentPositionY++);
                Console.Write($"{gladiatorTwo.Health}");

                Thread.Sleep(500);
            }

            Console.WriteLine("\n");

            if (gladiatorOne.Health > 0)
                Console.WriteLine($"Победил гладиатор - {gladiatorOne.Name}");
            else if (gladiatorTwo.Health > 0)
                Console.WriteLine($"Победил гладиатор - {gladiatorTwo.Name}");
            else
                Console.WriteLine("Ничья!");

            Console.ReadKey();
        }
    }

    private static bool TryGetGladiator(string command, out Gladiator gladiator)
    {
        const string CommandToSetGal = "1";
        const string CommandToSetAnabat = "2";
        const string CommandToSetBestiary = "3";
        const string CommandToSetLekverary = "4";
        const string CommandToSetRetary = "5";

        switch (command) 
        {
            case CommandToSetGal:
                gladiator = new Gaal("Гал");
                break;

            case CommandToSetAnabat:
                gladiator = new Andabat("Анабат");
                break;

            case CommandToSetBestiary:
                gladiator = new Bestiary("Бестиарий");
                break;

            case CommandToSetLekverary:
                gladiator = new Lekveary("Лекверарий");
                break;

            case CommandToSetRetary:
                gladiator = new Retiary("Ретарий");
                break;

            default:
                gladiator = null;
                break;
        }

        if (gladiator is not null)
            return true;

        return false;
    }
}

class Retiary : Gladiator
{
    private int _fishnetPeriod = 10;
    private int fightCounter = 0;

    public Retiary(string name) : base(name) { }

    override public void ShowStats()
    {
        ShowInfo();
        Console.Write($", сеть (полностью отражает каждую {_fishnetPeriod} атаку " +
            $"но теряет половину брони.)");
    }

    override public void TakeDamage(float damage)
    {
        if (fightCounter % _fishnetPeriod == 0)
            _armor /= 2f;
        else
            Health -= damage - _armor;
    }

    override public string GetDescription()
    {
        return $"Гладиатор Ретиарий, сетью отражает каждый {_fishnetPeriod} " +
            $"удар, но теряет половину брони";
    }
}

class Lekveary : Gladiator
{
    private int lassoFightPeriod = 3;
    private int fightCounter = 0;
    private float _lassoDamage;
    public Lekveary(string name) : base(name)
    {
        ApplyLasso();
    }

    override public void ShowStats()
    {
        ShowInfo();
        Console.Write($", лассо (+{_lassoDamage} к атаке " +
            $"на каждом {lassoFightPeriod} ударе.)");
    }

    override public float Damage
    {
        get
        {
            if (fightCounter % lassoFightPeriod == 0)
                return _damge + _lassoDamage;

            return _damge;
        }
    }

    override public string GetDescription()
    {
        return $"Гладиатор Бестиарий, использует лассо каждый {lassoFightPeriod} удар";
    }

    private void ApplyLasso()
    {
        Random random = new Random();
        float minDamage = 1f;
        float maxDamage = 5f;
        _lassoDamage = (float)(random.NextDouble() * (maxDamage - minDamage) + minDamage);
    }
}

class Bestiary : Gladiator
{
    private float _dagger;

    public Bestiary(string name) : base(name)
    { 
        SetDagger();
    }

    override public float Damage
    {
        get
        {
            return _damge + _dagger;
        }
    }

    override public void ShowStats()
    {
        ShowInfo();
        Console.Write($", кинжал (+ к атаке {(_dagger * 100).ToString("F1")}%)");
    }

    override public string GetDescription()
    {
        return "Гладиатор Бестиарий, дополнительно нападает с кинжалом";
    }

    private void SetDagger()
    {
        Random random = new Random();
        float min = 0.09f;
        float max = 0.15f;
        _dagger = (float)(random.NextDouble() * (max - min) + min);
    }
}

class Andabat : Gladiator
{
    private float _chainArmor;

    public Andabat(string name) : base(name)
    {
        SetChainArmor();
    }

    override public void TakeDamage(float damage)
    {
        Health -= damage - _armor - (_armor * _chainArmor);
    }

    override public void ShowStats()
    {
        ShowInfo();
        Console.Write($", кольчуга (+ к броне {(_chainArmor * 100).ToString("F1")}%)");
    }

    override public string GetDescription()
    {
        return "Гладиатор Анабат, дополнительно защищается кольчугой";
    }

    private void SetChainArmor()
    {
        Random random = new Random();
        float min = 0.01f;
        float max = 0.2f;
        _chainArmor = (float)(random.NextDouble() * (max - min) + min);
    }

}

class Gaal : Gladiator
{
    public Gaal(string name) : base(name) { }

    override public void ShowStats()
    {
        ShowInfo();
    }

    override public string GetDescription()
    {
        return "Гладиатор Гал, сильный и безпечный";
    }
}

abstract class Gladiator
{
    protected float _armor;
    protected float _damge;

    public Gladiator(string name)
    {
        Name = name;

        int minArmor = 1;
        int maxArmor = 5;
        Random random = new Random();
        _armor = (float)(random.Next(minArmor, maxArmor));

        int minDamage = 10;
        int maxDamage = 22;
        _damge = (float)(random.Next(minDamage, maxDamage));

        int minHelth = 90;
        int maxHelth = 120;
        Health = random.Next(minHelth, maxHelth);
    }

    public string Name { get; private set; }
    public float Health { get; protected set; }

    virtual public float Damage
    {
        get
        {
            return _damge;
        }
    }

    protected void ShowInfo()
    {
        Console.Write($"\nГладиатор {Name}, здоровье {Health}, наносимый урон " +
            $"{Damage}, броня {_armor}");
    }

    public virtual void TakeDamage(float damage)
    {
        Health -= damage - _armor;
    }

    abstract public void ShowStats();
    abstract public string GetDescription();
}

class Round
{

    public void DrawBar(int value, int xPosition, int yPosition)
    {
        const int MaxValue = 10;
        const int ThresholdValue = 3;

        (int CurrentPositionX, int CurrentPositionY) = Console.GetCursorPosition();

        ConsoleColor defaultColor = Console.BackgroundColor;
        ConsoleColor fillColor = ConsoleColor.Green;
        ConsoleColor dangerouseColor = ConsoleColor.Yellow;

        ConsoleColor currentColor;

        if (value <= ThresholdValue)
            currentColor = dangerouseColor;
        else
            currentColor = fillColor;

        string fillBar = new string(' ', value);
        string emptyBar = new string(' ', MaxValue - value);

        Console.SetCursorPosition(xPosition, yPosition);
        Console.Write('[');
        Console.BackgroundColor = currentColor;
        Console.Write(fillBar);
        Console.BackgroundColor = defaultColor;
        Console.Write(emptyBar);
        Console.Write(']');

        Console.SetCursorPosition(CurrentPositionX, CurrentPositionY);
    }
}