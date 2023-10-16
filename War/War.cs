using System.Threading;

internal partial class Program
{
    private static void Main(string[] args)
    {
        War war = new War();
        war.Battle();

        Console.ReadKey();
    }
}

class War
{
    private int _numberOfWarriorsInTroop = 100;
    private int _fightNumber = 1;

    public void Battle()
    {
        Troop firstTroop = new Troop(_numberOfWarriorsInTroop);
        Troop secondTroop = new Troop(_numberOfWarriorsInTroop);

        Random random = new Random();
        int whoIsFirst = random.Next(0, 2);

        while (firstTroop.WarriorsCount > 0 && secondTroop.WarriorsCount > 0)
        {
            if (_fightNumber % 2 == whoIsFirst)
                Fight(secondTroop, firstTroop);
            else
                Fight(firstTroop, secondTroop);

            Console.WriteLine($"После сражения номер {_fightNumber} в первом " +
                $"войске осталось {firstTroop.WarriorsCount} бойца(ов), " +
                $"во втором {secondTroop.WarriorsCount}");

            _fightNumber++;
        }

        ShowResult(firstTroop, secondTroop);
    }

    private void ShowResult(Troop firstTroop, Troop secondTroop)
    {
        if (firstTroop.WarriorsCount > 0)
            Console.WriteLine("Победа первого войска");
        else if (secondTroop.WarriorsCount > 0)
            Console.WriteLine("Победа второго войска");
        else
            Console.WriteLine("Ничья");
    }

    private void Fight(Troop troop1, Troop troop2)
    {
        Random random = new Random();

        for (int i = 0; i < troop1.WarriorsCount; i++)
        {
            int enemyNumber = random.Next(0, troop2.WarriorsCount);
            
            if (troop2.WarriorsCount > 0)
            {
                troop2.GetWarrior(enemyNumber).TakeDamage(troop1.GetWarrior(i).DamageValue);
                troop2.RemoveDeadSoldiers();
            }
        }

        troop1.RemoveDeadSoldiers();
    }  
}

class Troop
{
    private List<Warrior> _warriors;

    public Troop(int numberOfWarriors)
    {
        _warriors = new List<Warrior>();
        SetRandomWarriors(numberOfWarriors);
    }

    public int WarriorsCount
    {
        get { return _warriors.Count; }
    }

    public Warrior GetWarrior(int index)
    {
        return _warriors[index];
    }

    public void RemoveDeadSoldiers()
    {
        for (int i = _warriors.Count - 1; i >= 0; i--)
            if (_warriors[i].Health <= 0)
                _warriors.RemoveAt(i);
    }

    private void SetRandomWarriors(int count)
    {
        Warrior[] warriors =
        {
            new Gaal("Гал"),
            new Andabat("Анабат"),
            new Bestiary("Bestiariy"),
            new Lekveary("Лекверарий"),
            new Retiary("Ретарий")
        };

        Random random = new Random();
        int warriorsCount = warriors.Length;

        for (int i = 0; i < count; i++)
        {
            int wariosIndex = random.Next(0, warriorsCount);
            Warrior warrior = (Warrior)warriors[wariosIndex].Clone();
            _warriors.Add(warrior);
        }
    }
}

class Retiary : Warrior, ICloneable
{
    private int _fishnetPeriod = 10;
    private int _fightCounter = 0;
    private float _armorDelimeter = 2f;

    public Retiary(string name) : base(name) { }

    public override void TakeDamage(float damage)
    {
        if (_fightCounter % _fishnetPeriod == 0)
            Armor /= _armorDelimeter;
        else
            Health -= damage - Armor;

        _fightCounter++;
    }

    public override object Clone()
    {
        return new Retiary(Name);
    }
}

class Lekveary : Warrior, ICloneable
{
    private int _lassoFightPeriod = 3;
    private int _fightCounter = 0;
    private float _lassoDamage;

    public Lekveary(string name) : base(name)
    {
        ApplyLasso();
    }

    public override float DamageValue
    {
        get
        {
            if (_fightCounter % _lassoFightPeriod == 0)
                return Damage + _lassoDamage;

            return Damage;
        }
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

class Bestiary : Warrior, ICloneable
{
    private float _dagger;

    public Bestiary(string name) : base(name)
    {
        SetDagger();
    }

    public override float DamageValue
    {
        get
        {
            return Damage + _dagger;
        }
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

class Andabat : Warrior, ICloneable
{
    private float _chainArmor;

    public Andabat(string name) : base(name)
    {
        SetChainArmor();
    }

    public override void TakeDamage(float damage)
    {
        Health -= damage - Armor - (Armor * _chainArmor);
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

class Gaal : Warrior, ICloneable
{
    public Gaal(string name) : base(name) { }

    public override object Clone()
    {
        return new Gaal(Name);
    }
}

abstract class Warrior : ICloneable
{
    protected float Armor;
    protected float Damage;

    public Warrior(string name)
    {
        Name = name;

        int minArmor = 1;
        int maxArmor = 5;
        Random random = new Random();
        Armor = (float)(random.Next(minArmor, maxArmor));

        int minDamage = 10;
        int maxDamage = 22;
        Damage = (float)(random.Next(minDamage, maxDamage));

        int minHelth = 90;
        int maxHelth = 120;
        Health = random.Next(minHelth, maxHelth);
    }

    public string Name { get; private set; }
    public float Health { get; protected set; }

    public virtual float DamageValue
    {
        get
        {
            return Damage;
        }
    }

    public virtual void TakeDamage(float damage)
    {
        Health -= damage - Armor;
    }

    public abstract object Clone();
}