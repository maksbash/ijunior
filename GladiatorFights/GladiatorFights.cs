using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Game game = new Game();
        game.ShowMenu();
    }
}

class Game
{
    public void ShowMenu()
    {
        int gladiatorOneXPosition = 0;
        int gladiatorTwoXPosition = 50;
        int gladiatorsYPosition = 2;

        int sleepTime = 500;
        int dividerForBar = 10;

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
            {
                Console.WriteLine(index + ". " + gladiator.GetDescription());
                index++;
            }

            Console.Write("Введите номер 1-го гладиатора: ");

            int gladiatorIndex;
            int.TryParse(Console.ReadLine(), out gladiatorIndex);
            gladiatorOne = (Gladiator)gladiators[--gladiatorIndex].Clone();

            Console.Write("Введите номер 2-го гладиатора: ");

            int.TryParse(Console.ReadLine(), out gladiatorIndex);
            gladiatorTwo = (Gladiator)gladiators[--gladiatorIndex].Clone();

            isActive = false;

            Console.Clear();
            Console.WriteLine("Дерутся следующие гладиаторы: ");
            Console.WriteLine(gladiatorOne.GetDescription());
            Console.WriteLine(gladiatorTwo.GetDescription());
            gladiatorsYPosition += 2;

            Console.SetCursorPosition(gladiatorOneXPosition, gladiatorsYPosition);
            Console.Write($"{gladiatorOne.Name}");
            Console.SetCursorPosition(gladiatorTwoXPosition, gladiatorsYPosition++);
            Console.Write($"{gladiatorTwo.Name}");

            float defaultHelthOne = gladiatorOne.Health / dividerForBar;
            float defaultHelthTwo = gladiatorTwo.Health / dividerForBar;

            Console.WriteLine();
            while (gladiatorOne.Health > 0 && gladiatorTwo.Health > 0)
            {
                Bar bar = new Bar();
                bar.DrawBar((int)(gladiatorOne.Health / defaultHelthOne), gladiatorOneXPosition, gladiatorsYPosition);
                bar.DrawBar((int)(gladiatorTwo.Health / defaultHelthTwo), gladiatorTwoXPosition, gladiatorsYPosition);

                Console.WriteLine();
                (int CurrentPositionX, int CurrentPositionY) = Console.GetCursorPosition();

                gladiatorOne.TakeDamage(gladiatorTwo.Damage);
                gladiatorTwo.TakeDamage(gladiatorOne.Damage);
                Console.SetCursorPosition(gladiatorOneXPosition, CurrentPositionY);
                Console.Write($"{gladiatorOne.Health}");
                Console.SetCursorPosition(gladiatorTwoXPosition, CurrentPositionY++);
                Console.Write($"{gladiatorTwo.Health}");

                Thread.Sleep(sleepTime);
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
}

class Retiary : Gladiator, ICloneable
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

        fightCounter++;
    }

    override public string GetDescription()
    {
        return $"Гладиатор Ретиарий, сетью отражает каждый {_fishnetPeriod} " +
            $"удар, но теряет половину брони";
    }

    override public object Clone()
    {
        return new Retiary(Name);
    }
}

class Lekveary : Gladiator, ICloneable
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

    override public object Clone()
    {
        return new Lekveary(Name);
    }

    private void ApplyLasso()
    {
        Random random = new Random();
        float minDamage = 1f;
        float maxDamage = 5f;
        _lassoDamage = (float)(random.NextDouble() * (maxDamage - minDamage) + minDamage);
    }
}

class Bestiary : Gladiator, ICloneable
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

    override public object Clone()
    {
        return new Bestiary(Name);
    }

    private void SetDagger()
    {
        Random random = new Random();
        float min = 0.09f;
        float max = 0.15f;
        _dagger = (float)(random.NextDouble() * (max - min) + min);
    }
}

class Andabat : Gladiator, ICloneable
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

    override public object Clone()
    {
        return new Andabat(Name);
    }

    private void SetChainArmor()
    {
        Random random = new Random();
        float min = 0.01f;
        float max = 0.2f;
        _chainArmor = (float)(random.NextDouble() * (max - min) + min);
    }

}

class Gaal : Gladiator, ICloneable
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

    override public object Clone()
    {
        return new Gaal(Name);
    }
}

abstract class Gladiator: ICloneable
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
    public abstract object Clone();
}

class Bar
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