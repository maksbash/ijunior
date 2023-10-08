internal class Program
{
    private static void Main(string[] args)
    {
        Supermarket supermarket = new Supermarket();
        supermarket.Service();

        Console.ReadKey();
    }
}

class Supermarket
{
    private Queue<Buyer> _buyers;
    private List<Product> _products;
    private Random _random;

    public Supermarket()
    {
        _buyers = new Queue<Buyer>();
        _products = new List<Product>();
        _random = new Random();

        FillProducts();
        CreateBuyers();
    }

    public void Service()
    {
        while (_buyers.Count > 0)
            _buyers.Dequeue().Buy();
    }

    private void CreateBuyers()
    {
        int minBuyers = 2;
        int maxBuyers = 10;
        
        int countBuyers = _random.Next(minBuyers, maxBuyers + 1);

        for (int i = 0; i <= countBuyers; i++)
            _buyers.Enqueue(GetBuyer());
    }

    private Buyer GetBuyer()
    {
        List<Product> products = new List<Product>();
        int countProducts = _random.Next(1, _products.Count + 1);
        
        int fullPriceOfProducts = 0;

        for (int i = 0; i < countProducts; i++)
        {
            int randomIndexOfProduct = _random.Next(0, _products.Count);
            products.Add(_products[randomIndexOfProduct]);
            fullPriceOfProducts += _products[randomIndexOfProduct].Price;
        }

        int hitPercent = 10;
        int minMoney = fullPriceOfProducts - (fullPriceOfProducts / hitPercent);
        int maxMoney = fullPriceOfProducts + (fullPriceOfProducts / hitPercent);
        int money = _random.Next(minMoney, maxMoney);

        return new Buyer(money, products);
    }

    private void FillProducts()
    {
        _products.Add(new Product("Яблоко", 5));
        _products.Add(new Product("Груша", 7));
        _products.Add(new Product("Банан", 5));
        _products.Add(new Product("Апельсин", 6));
        _products.Add(new Product("Абрекос", 3));
        _products.Add(new Product("Арбуз", 3));
        _products.Add(new Product("Дыня", 4));
        _products.Add(new Product("Вишня", 9));
        _products.Add(new Product("Ананас", 11));
    }
}

class Product
{
    public Product(string name, int price)
    {
        Name = name;
        Price = price;
    }

    public string Name { get; private set; }
    public int Price { get; private set; }
}

class Buyer
{
    private static int s_lastId = -1;

    private List<Product> _products;
    private int _wallet;
    private int _id;

    public Buyer(int money, List<Product> products) : base()
    {
        _products = new List<Product>();
        _id = ++s_lastId;
        _wallet = money;
        _products = products;
    }

    public void Buy()
    {
        Console.WriteLine($"Покупатель {_id}. Денег - {_wallet}. " +
            "Корзина покупателя вначале:");
        ShowProducts();

        while (CanBuy() == false && _products.Count > 0)
            RemoveRandomProduct();

        Console.WriteLine("Корзина покупателя которую он смог купить:");
        ShowProducts();

        _wallet -= GetFullPrice();

        Console.WriteLine();
    }

    private void ShowProducts()
    {
        foreach (Product product in _products)
            Console.WriteLine($"Покупатель {_id} - {product.Name} ({product.Price})");
    }

    private bool CanBuy()
    {
        int fullPrice = GetFullPrice();

        if (_wallet >= fullPrice)
            return true;

        return false;
    }

    private void RemoveRandomProduct()
    {
        Random random = new Random();
        int productIndex = random.Next(0, _products.Count);

        if (_products.Count > 0)
            _products.RemoveAt(productIndex);
        else
            Console.WriteLine($"Покупатель {_id} не смог оплатить покупки");
    }

    private int GetFullPrice()
    {
        int price = 0;

        foreach (Product product in _products)
            price += product.Price;

        return price;
    }
}
