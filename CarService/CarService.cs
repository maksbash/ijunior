internal class Program
{
    private static void Main(string[] args)
    {
        int countAvailebleParts = 10;
        Part[] parts = new Part[countAvailebleParts];
        parts[0] = new Part("Wheel", 70);
        parts[1] = new Part("LowBeams", 10);
        parts[2] = new Part("HighBeams", 13);
        parts[3] = new Part("Bumper", 20);
        parts[4] = new Part("Wiperss", 30);
        parts[5] = new Part("Tyre", 22);
        parts[6] = new Part("Silencer", 17);
        parts[7] = new Part("Brake", 48);
        parts[8] = new Part("GearShift", 52);
        parts[9] = new Part("AirBag", 55);

        int minimumCars = 10;
        int maximumCars = 200;
        int countCars = UserUtils.getRandomValue(minimumCars, maximumCars);

        Queue<Car> cars = new Queue<Car>();

        for (int i = 0; i < countCars; i++)
        {
            cars.Enqueue(new Car(countAvailebleParts));
        }

        CarService carService = new CarService(parts);

        Console.ReadKey();
    }

}

class CarService
{
    private int _minimumAvailibleParts = 50;
    private int _maximumAvailibleParts = 100;
    private int _countAvailibleParts;
    private int _balance = 2000;

    private PartsWarehouse _partsWarehouse;
    private Queue<Car> _cars;

    public CarService(Part[] availebleParts)
    {
        _partsWarehouse = new PartsWarehouse(availebleParts);

        

    }

    public void Service()
    {
        Console.Clear();

        while (_cars.Count > 0)
        {
            Console.WriteLine($"Автомобилей в очереди - {_cars.Count}");
            Car car = _cars.Dequeue();
            bool isFixed = TryFixCar(car);

            //if (isFixed == false)
            //    Refusal()
        }

    }

    private bool Refusal(int price)
    {
        return true;
    }

    private bool TryFixCar(Car car)
    {
        int partIdForChange = car.BrokenPart;
        _partsWarehouse.TryGetPart(partIdForChange, out Part part);

        if (part == null)
            return false;
        else
            return true;
    }
}

class Car
{
    public Car(int maximumParts)
    {
        BrokenPart = UserUtils.getRandomValue(0, maximumParts);
    }

    public int BrokenPart { get; private set; }
}

class PartsWarehouse
{
    private Part[] _worldParts;
    private Dictionary<Part, int> _parts;

    public PartsWarehouse(Part[] parts)
    {
        int minimumCurrent = 5;
        int maximumCurrent = 15;
        _parts = new Dictionary<Part, int>();

        for (int i = 0; i < parts.Length; i++)
        {
            int currentCount =
                UserUtils.getRandomValue(minimumCurrent, maximumCurrent);

            _parts.Add(parts[i].CLone(), currentCount);
        }
    }

    public void TryGetPart(Part partForSearch, out Part part)
    {
        if (_parts.Keys.Contains(partForSearch))
        {
            if (_parts[partForSearch] > 0)
            {
                part = _parts.Keys.;
            }
        }



        if (_parts[partId].Count == 0)
            part = null;

        part = _parts[partId].Dequeue();
    }

}

class Part : IComparable<Part>
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

    public bool Compare(Part part)
    {
        return part.Name == Name && part.Price == Price;
    }

    public int CompareTo(Part? other)
    {
        if (!(other.Name == Name && other.Price == Price)) return -1;
        else return 0;
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

//enum Parts
//{
//    Wheel,
//    LowBeams,
//    HighBeams,
//    Bumper,
//    Wiperss,
//    Tyre,
//    Silencer,
//    Brake,
//    GearShift,
//    AirBag
//}
