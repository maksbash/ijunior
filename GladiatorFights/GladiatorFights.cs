using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Round r = new Round();
        r.DrawBar(6, 5, 0);
        r.DrawBar(3, 25, 0);

        Gladiator[] gladiators = {
            new Gaal("Гал"),
            new Andabat("Анабат"),
            new Bestiary("Bestiariy"),
            new Lekveary("Лекверарий"),
            new Retiary("Ретарий")
        };

        int index = 1;
        foreach (Gladiator gladiator in gladiators)
        {
            Console.WriteLine(index++ + ". " + gladiator.GetDescription());
            //index++;
        }
        
        while (gladiators[0].Health > 0 && gladiators[1].Health > 0)
        {
            gladiators[0].TakeDamage(gladiators[1].Damage);
            gladiators[1].TakeDamage(gladiators[0].Damage);
            Console.WriteLine($"\n1: {gladiators[0].Health}; 2: {gladiators[1].Health}");
            //Console.ReadKey();
        }

        Console.ReadKey();
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
        Console.SetCursorPosition(0, yPosition + 1);
    }
}