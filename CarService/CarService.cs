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

        int minimumCars = 10;
        int maximumCars = 200;
        int countCars = UserUtils.getRandomValue(minimumCars, maximumCars);

        _cars = new Queue<Car>();

        for (int i = 0; i < countCars; i++)
        {
            _cars.Enqueue(new Car(_countAvailibleParts));
        }
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
    private List<Queue<Part>> _parts;

    public PartsWarehouse(Part[] parts)
    {
        _worldParts = parts;
        _parts = new List<Queue<Part>>();
        AddParts(_worldParts.Length);
    }

    public List<Queue<Part>> getParts() => _parts;

    public void TryGetPart(int partId, out Part part)
    {
        if (partId >= _parts.Count)
            part = null;

        if (_parts[partId].Count == 0)
            part = null;

        part = _parts[partId].Dequeue();
    }

    private void AddParts(int countAvailibleParts)
    {
        int percentPartsIn = 80; //сколько запчастей в % от имеющихся в природе
        int partsCount = countAvailibleParts - (countAvailibleParts / 100) * percentPartsIn;

        //Заполняем запчастями
        for (int i = 0; i < partsCount; i++)
        {
            int minimumCurrent = 5;
            int maximumCurrent = 15;
            int currentCount =
                UserUtils.getRandomValue(minimumCurrent, maximumCurrent);

            _parts.Add(new Queue<Part>());

            //Заполняем количеством каждую запчасть
            for (int j = 0; j < currentCount; j++)
            {
                _parts[i].Enqueue(_worldParts[i]);
            }
        }
    }
}

class Part
{
    private static int LastId = -1;

    public Part(string name, int price)
    {
        Id = ++LastId;
        Price = price;
        Name = name;
    }

    public int Id { get; private set; }
    public int Price { get; private set; }
    public string Name { get; private set; }
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
