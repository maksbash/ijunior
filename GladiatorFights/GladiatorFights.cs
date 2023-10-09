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
    private Gladiator[] _gladiators =
        {
            new Gaal("Гал"),
            new Andabat("Анабат"),
            new Bestiary("Bestiariy"),
            new Lekveary("Лекверарий"),
            new Retiary("Ретарий")
        };

    public void ShowMenu()
    {
        ShowExistsGladiators();

        int indexFirstGladiator = 1;
        int indexSecondGladiator = 2;
        Gladiator gladiatorOne = SelectGladiator(indexFirstGladiator, _gladiators);
        Gladiator gladiatorTwo = SelectGladiator(indexSecondGladiator, _gladiators);

        Figth(gladiatorOne, gladiatorTwo);

        Console.WriteLine("\n");

        if (gladiatorOne.Health > 0)
            Console.WriteLine($"Победил гладиатор - {gladiatorOne.Name}");
        else if (gladiatorTwo.Health > 0)
            Console.WriteLine($"Победил гладиатор - {gladiatorTwo.Name}");
        else
            Console.WriteLine("Ничья!");

        Console.ReadKey();
        
    }

    private void Figth(Gladiator gladiatorOne, Gladiator gladiatorTwo)
    {
        int firstGladiatorPositionX = 0;
        int secondGladiatorPositionX = 50;
        int gladiatorsPositionY = 2;
        int gladiatorsShiftPositionY = 2;

        float defaultHelthOne = gladiatorOne.Health;
        float defaultHelthTwo = gladiatorTwo.Health;

        int sleepTime = 500;

        gladiatorsPositionY += gladiatorsShiftPositionY;

        Console.Clear();
        Console.WriteLine("Дерутся следующие гладиаторы: ");
        Console.WriteLine(gladiatorOne.GetDescription());
        Console.WriteLine(gladiatorTwo.GetDescription());
        gladiatorsPositionY += gladiatorsShiftPositionY;

        Console.SetCursorPosition(firstGladiatorPositionX, gladiatorsPositionY);
        Console.Write($"{gladiatorOne.Name}");
        Console.SetCursorPosition(secondGladiatorPositionX, gladiatorsPositionY++);
        Console.Write($"{gladiatorTwo.Name}");
        Console.WriteLine();

        while (gladiatorOne.Health > 0 && gladiatorTwo.Health > 0)
        {
            Bar bar = new Bar();
            bar.DrawBar((int)gladiatorOne.Health, (int)defaultHelthOne, firstGladiatorPositionX, gladiatorsPositionY);
            bar.DrawBar((int)gladiatorTwo.Health, (int)defaultHelthTwo, secondGladiatorPositionX, gladiatorsPositionY);

            Console.WriteLine();
            (int CurrentPositionX, int CurrentPositionY) = Console.GetCursorPosition();

            gladiatorOne.TakeDamage(gladiatorTwo.Damage);
            gladiatorTwo.TakeDamage(gladiatorOne.Damage);
            Console.SetCursorPosition(firstGladiatorPositionX, CurrentPositionY);
            Console.Write($"{gladiatorOne.Health}");
            Console.SetCursorPosition(secondGladiatorPositionX, CurrentPositionY++);
            Console.Write($"{gladiatorTwo.Health}");

            Thread.Sleep(sleepTime);
        }
    }

    private void ShowExistsGladiators()
    {
        Console.WriteLine("Гладиаторы: ");
        int index = 1;

        foreach (Gladiator gladiator in _gladiators)
        {
            Console.WriteLine(index + ". " + gladiator.GetDescription());
            index++;
        }
    }

    private Gladiator SelectGladiator(int gladiatorNumber, Gladiator[] gladiators)
    {
        Console.Write($"Введите номер {gladiatorNumber}-го гладиатора: ");

        int.TryParse(Console.ReadLine(), out int gladiatorIndex);
        gladiatorIndex--;

        if (gladiatorIndex >= 0 && gladiatorIndex < gladiators.Length)
        {
            return (Gladiator)gladiators[gladiatorIndex].Clone();
        }
        else
        {
            Console.WriteLine("Введено некорректное значение, попробуйте ещё раз");
            return SelectGladiator(gladiatorNumber, gladiators);
        }
    }
}

class Retiary : Gladiator, ICloneable
{
    private int _fishnetPeriod = 10;
    private int _fightCounter = 0;
    private float _damageDelimeter = 2f;

    public Retiary(string name) : base(name) { }

   public override void ShowStats()
    {
        ShowInfo();
        Console.Write($", сеть (полностью отражает каждую {_fishnetPeriod} атаку " +
            $"но теряет половину брони.)");
    }

   public override void TakeDamage(float damage)
    {
        if (_fightCounter % _fishnetPeriod == 0)
            _armor /= _damageDelimeter;
        else
            Health -= damage - _armor;

        _fightCounter++;
    }

   public override string GetDescription()
    {
        return $"Гладиатор Ретиарий, сетью отражает каждый {_fishnetPeriod} " +
            $"удар, но теряет половину брони";
    }

   public override object Clone()
    {
        return new Retiary(Name);
    }
}

class Lekveary : Gladiator, ICloneable
{
    private int _lassoFightPeriod = 3;
    private int fightCounter = 0;
    private float _lassoDamage;

    public Lekveary(string name) : base(name)
    {
        ApplyLasso();
    }

   public override float Damage
    {
        get
        {
            if (fightCounter % _lassoFightPeriod == 0)
                return _damge + _lassoDamage;

            return _damge;
        }
    }

   public override void ShowStats()
    {
        ShowInfo();
        Console.Write($", лассо (+{_lassoDamage} к атаке " +
            $"на каждом {_lassoFightPeriod} ударе.)");
    }

   public override string GetDescription()
    {
        return $"Гладиатор Бестиарий, использует лассо каждый {_lassoFightPeriod} удар";
    }

   public override object Clone()
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

   public override float Damage
    {
        get
        {
            return _damge + _dagger;
        }
    }

   public override void ShowStats()
    {
        ShowInfo();
        int multiplyerForPercent = 100;
        Console.Write($", кинжал (+ к атаке " +
            $"{(_dagger * multiplyerForPercent).ToString("F1")}%)");
    }

   public override string GetDescription()
    {
        return "Гладиатор Бестиарий, дополнительно нападает с кинжалом";
    }

   public override object Clone()
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

   public override void TakeDamage(float damage)
    {
        Health -= damage - _armor - (_armor * _chainArmor);
    }

   public override void ShowStats()
    {
        ShowInfo();
        int multiplyerForPercent = 100;
        Console.Write($", кольчуга (+ к броне " +
            $"{(_chainArmor * multiplyerForPercent).ToString("F1")}%)");
    }

   public override string GetDescription()
    {
        return "Гладиатор Анабат, дополнительно защищается кольчугой";
    }

   public override object Clone()
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

   public override void ShowStats()
    {
        ShowInfo();
    }

   public override string GetDescription()
    {
        return "Гладиатор Гал, сильный и безпечный";
    }

   public override object Clone()
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

    public void DrawBar(int health, int defaultHealth, int xPosition, int yPosition)
    {
        const int MaxValue = 10;
        const int ThresholdValue = 3;
        int value = health / (defaultHealth / MaxValue);

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