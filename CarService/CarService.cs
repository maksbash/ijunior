internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}

class PartsWarehouse
{
    private List<Part> _parts;

    public PartsWarehouse()
    {
        _parts = new List<Part>();
        AddParts();
    }

    private void AddParts()
    {

    }
}

class Part
{
    public Part(string type, int price)
    {
        Type = type;
        Price = price;
    }

    public string Type { get; private set; }
    public int Price { get; private set; }
}