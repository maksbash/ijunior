internal class Program
{
    private static void Main(string[] args)
    {
        int countAvailebleParts = 10;
        Part[] parts = new Part[countAvailebleParts];
        parts[0] = new Part("Wheel", 70);
        parts[1] = new Part("LowBeams", 100);
        parts[2] = new Part("HighBeams", 130);
        parts[3] = new Part("Bumper", 200);
        parts[4] = new Part("Wiperss", 30);
        parts[5] = new Part("Tyre", 220);
        parts[6] = new Part("Silencer", 170);
        parts[7] = new Part("Brake", 48);
        parts[8] = new Part("GearShift", 520);
        parts[9] = new Part("AirBag", 550);

        int minimumCars = 100;
        int maximumCars = 500;
        int countCars = UserUtils.getRandomValue(minimumCars, maximumCars);

        Queue<Car> cars = new Queue<Car>();

        for (int i = 0; i < countCars; i++)
        {
            int partIndex = UserUtils.getRandomValue(0, countAvailebleParts);
            cars.Enqueue(new Car(parts[partIndex].Clone()));
        }

        CarService carService = new CarService(parts, cars);
        carService.Service();

        Console.ReadKey();
    }
}

class CarService
{
    private int _balance = 1000;
    private int _profitInPercent = 10;
    private int _fineInPercent = 10;

    private PartsWarehouse _partsWarehouse;
    private Queue<Car> _cars;

    public CarService(Part[] availebleParts, Queue<Car> cars)
    {
        _partsWarehouse = new PartsWarehouse(availebleParts);
        _cars = cars;
    }

    public void Service()
    {
        Console.Clear();

        while (_cars.Count > 0 && _balance > 0)
        {
            Console.WriteLine($"Баланс сервиса = {_balance}");
            Console.WriteLine($"Автомобилей в очереди - {_cars.Count}");
            
            Car car = _cars.Dequeue();

            Console.WriteLine($"Поломка текущего автомобиля - {car.BrokenPart.Name}");

            int countOfThisParts = _partsWarehouse.GetPartsCount(car.BrokenPart);
            Console.WriteLine($"У вас имеется {countOfThisParts} таких запчастей");

            if (countOfThisParts > 0)
            {
                _partsWarehouse.GetPart(car.BrokenPart);
                _balance += car.BrokenPart.Price + (car.BrokenPart.Price / _profitInPercent);
                Console.WriteLine("Машина починена.");
            }
            else
            {
                _balance -= car.BrokenPart.Price / _fineInPercent;
            }
        }

        if (_balance > 0)
            Console.WriteLine($"Вы починили все машины! Ваш баланс - {_balance}");
        else
            Console.WriteLine("Вы обанкротились");
    }
}

class Car
{
    public Car(Part brokenPart)
    {
        BrokenPart = brokenPart;
    }

    public Part BrokenPart { get; private set; }
}

class PartsWarehouse
{
    private Dictionary<string, int> _parts;

    public PartsWarehouse(Part[] parts)
    {
        int minimumCurrent = 1;
        int maximumCurrent = 4;
        _parts = new Dictionary<string, int>();

        for (int i = 0; i < parts.Length; i++)
        {
            int currentCount =
                UserUtils.getRandomValue(minimumCurrent, maximumCurrent);

            _parts.Add(parts[i].Name, currentCount);
        }
    }

    public int GetPartsCount(Part partForSearch)
    {
        if (_parts.Keys.Contains(partForSearch.Name))
            return _parts[partForSearch.Name];

        return 0;
    }

    public void GetPart(Part partForSearch)
    {
        if (GetPartsCount(partForSearch) > 0)
            _parts[partForSearch.Name]--;
    }
}

class Part
{
    public Part(string name, int price)
    {
        Price = price;
        Name = name;
    }

    public int Price { get; private set; }
    public string Name { get; private set; }

    public Part Clone()
    {
        return new Part(Name, Price);
    }
}

class UserUtils
{
    private static Random _random = new Random();

    public static int getRandomValue(int minimumValue, int maximumValue)
    {
        return _random.Next(minimumValue, maximumValue);
    }
}

