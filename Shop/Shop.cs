internal class Program
{
    private static void Main(string[] args)
    {
        const string CommandToShowSalesmanProducts = "1";
        const string CommandToShowBuerProducts = "2";
        const string CommandToBuy = "3";
        const string CommandToExit = "9";

        
        Salesman salesman = new Salesman();

        Console.Write("Сколько денег есть у пакупателя?: ");

        if (int.TryParse(Console.ReadLine(), out int buersMoney) == false)
        {
            Console.WriteLine("\nВведено неверное значение! Попробуй ещё раз");
            Console.ReadKey();
            return ;
        }

        Buyer buyer = new Buyer(buersMoney);

        Market market = new Market(salesman, buyer);

        bool isActive = true;

        while (isActive)
        {
            Console.Clear();
            Console.WriteLine($"{CommandToShowSalesmanProducts} - " +
                $"вывести товары продавца");
            Console.WriteLine($"{CommandToShowBuerProducts} - " +
                $"вывести товары покупателя");
            Console.WriteLine($"{CommandToBuy} - купить товар у продавца");
            Console.WriteLine($"{CommandToExit} Выход");
            Console.Write("Введите команду: ");

            string currentCommand = Console.ReadLine();

            Console.WriteLine();

            switch (currentCommand)
            {
                case CommandToShowSalesmanProducts:
                    salesman.ShowProducts();
                    break;

                case CommandToShowBuerProducts:
                    buyer.ShowProducts();
                    break;

                case CommandToBuy:
                    market.Offer();
                    break;

                case CommandToExit:
                    isActive = false;
                    break;

                default:
                    Console.WriteLine("\n\nТакой команды не существует");
                    break;
            }

            Console.WriteLine("\n\nНажмителю любую клавишу для продолжения.");
            Console.ReadKey();
        }
    }
}

class Market
{
    private Salesman _salesman;
    private Buyer _buyer;

    public Market(Salesman salesman, Buyer buyer)
    {
        _salesman = salesman;
        _buyer = buyer;
    }

    public void Offer()
    {
        _salesman.ShowProducts();

        Console.Write("Введите Id продукта для покупки: ");
        int.TryParse(Console.ReadLine(), out int id);

        if (_salesman.TryGetProduct(id, out Product product))
            Deal(product);

    }

    private bool Deal(Product product)
    {
        if (_buyer.CanBuy(product.Price))
        {
            _salesman.Sell(product);
            _buyer.Buy(product);

            return true;
        }

        return false;
    }
}

class Salesman : Person
{
    public Salesman() : base() 
    {
        FillProducts();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public bool Sell(Product product)
    {
        if (_products.Remove(product))
        {
            _wallet += product.Price;

            return true;
        }

        return false;
    }

    public bool TryGetProduct(int id, out Product product)
    {
        foreach (Product productForSale in _products)
        {
            if (productForSale.Id == id)
            {
                product = productForSale;

                return true;
            }
        }

        product = null;

        return false;
    }

    private void FillProducts()
    {
        AddProduct(new Product("Яблоко", 5));
        AddProduct(new Product("Груша", 7));
        AddProduct(new Product("Банан", 5));
        AddProduct(new Product("Апельсин", 6));
        AddProduct(new Product("Абрекос", 3));
        AddProduct(new Product("Арбуз", 3));
        AddProduct(new Product("Дыня", 4));
        AddProduct(new Product("Вишня", 9));
        AddProduct(new Product("Ананас", 11));
    }
}

class Buyer : Person
{
    public Buyer(int defaultMoney) : base()
    {
        _wallet = defaultMoney;
    }

    public void Buy(Product product)
    { 
        _wallet -= product.Price;
        _products.Add(product);
    }

    public bool CanBuy(int price)
    {
        return _wallet >= price;
    }
}

class Person
{
    protected List<Product> _products = new List<Product>();
    protected int _wallet;

    public void ShowProducts()
    {
        Console.WriteLine($"\nПродукты: ");
        foreach (Product product in _products)
            Console.WriteLine($"{product.Id} - {product.Name} ({product.Price})");
    }
}

class Product
{
    private static int _lastId = -1;

    public Product(string name, int price)
    {
        Name = name;
        Price = price;
        Id = ++_lastId;
    }

    public int Id { get; private set; }
    public string Name { get; private set; }
    public int Price { get; private set; }
}
