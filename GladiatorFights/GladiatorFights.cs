internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}

class Gladiator
{
    private string _name;
    private int _health;
    private int _damage;
    private int _armor; 

    public void TakeDamage(int damage)
    {
        _health -= damage - _armor;
    }

}