internal partial class Program
{
    private static void Main(string[] args)
    {
        War war = new War();
        war.Buttle();

        Console.ReadKey();
    }
}

class War
{
    private int _numberOfWarriorsInTroop = 100;
    private int _fightNumber = 1;

    public void Buttle()
    {
        Troop firstTroop = new Troop(_numberOfWarriorsInTroop);
        Troop secondTroop = new Troop(_numberOfWarriorsInTroop);

        Random random = new Random();
        int whoIsFirst = random.Next(0, 2);

        while (firstTroop.Warriors.Count > 0 && secondTroop.Warriors.Count > 0)
        {
            if (_fightNumber % 2 == whoIsFirst)
                Fight(secondTroop, firstTroop);
            else
                Fight(firstTroop, secondTroop);

            Console.WriteLine($"После сражения номер {_fightNumber} в первом " +
                $"войске осталось {firstTroop.Warriors.Count} бойца(ов), " +
                $"во втором {secondTroop.Warriors.Count}");

            _fightNumber++;
        }

        if (firstTroop.Warriors.Count > 0)
            Console.WriteLine("Победа первого войска");
        else if (secondTroop.Warriors.Count > 0)
            Console.WriteLine("Победа второго войска");
        else
            Console.WriteLine("Ничья");
    }

    private void Fight(Troop troop1, Troop troop2)
    {
        Random random = new Random();

        foreach (Warrior warrior in troop1.Warriors)
        {
            int enemyNumber = random.Next(0, troop2.Warriors.Count);

            if (troop2.Warriors.Count > 0)
            {
                troop2.Warriors[enemyNumber].TakeDamage(warrior.Damage);
                troop2.removeIfDead();
            }
        }

        troop1.removeIfDead();
    }  
}

class Troop
{
    public Troop(int numberOfWarriors)
    {
        Warriors = new List<Warrior>();
        SetRandomWarriors(numberOfWarriors);
    }

    public List<Warrior> Warriors { get; private set; }

    public void removeIfDead()
    {
        for (int i = Warriors.Count - 1; i >= 0; i--)
            if (Warriors[i].Health <= 0)
                Warriors.RemoveAt(i);
    }

    private void SetRandomWarriors(int number)
    {
        Warrior[] warriors = {
            new Gaal("Гал"),
            new Andabat("Анабат"),
            new Bestiary("Bestiariy"),
            new Lekveary("Лекверарий"),
            new Retiary("Ретарий")
        };

        Random random = new Random();
        int numberOfWarriors = warriors.Length;

        for (int i = 0; i < number; i++)
        {
            int wariosNumber = random.Next(0, numberOfWarriors);
            Warrior warrior = (Warrior)warriors[wariosNumber].Clone();
            Warriors.Add(warrior);
        }
    }
}

class Retiary : Warrior, ICloneable
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
        return $"Воин Ретиарий, сетью отражает каждый {_fishnetPeriod} " +
            $"удар, но теряет половину брони";
    }

    override public object Clone()
    {
        return new Retiary(Name);
    }
}

class Lekveary : Warrior, ICloneable
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
                return _damage + _lassoDamage;

            return _damage;
        }
    }

    override public string GetDescription()
    {
        return $"Воин Бестиарий, использует лассо каждый {lassoFightPeriod} удар";
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

class Bestiary : Warrior, ICloneable
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
            return _damage + _dagger;
        }
    }

    override public void ShowStats()
    {
        ShowInfo();
        Console.Write($", кинжал (+ к атаке {(_dagger * 100).ToString("F1")}%)");
    }

    override public string GetDescription()
    {
        return "Воин Бестиарий, дополнительно нападает с кинжалом";
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

class Andabat : Warrior, ICloneable
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
        return "Воин Анабат, дополнительно защищается кольчугой";
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

class Gaal : Warrior, ICloneable
{
    public Gaal(string name) : base(name) { }

    override public void ShowStats()
    {
        ShowInfo();
    }

    override public string GetDescription()
    {
        return "Воин Гал, сильный и безпечный";
    }

    override public object Clone()
    {
        return new Gaal(Name);
    }
}

abstract class Warrior : ICloneable
{
    protected float _armor;
    protected float _damage;

    public Warrior(string name)
    {
        Name = name;

        int minArmor = 1;
        int maxArmor = 5;
        Random random = new Random();
        _armor = (float)(random.Next(minArmor, maxArmor));

        int minDamage = 10;
        int maxDamage = 22;
        _damage = (float)(random.Next(minDamage, maxDamage));

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
            return _damage;
        }
    }

    protected void ShowInfo()
    {
        Console.Write($"\nВоин {Name}, здоровье {Health}, наносимый урон " +
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