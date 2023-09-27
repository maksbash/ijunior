using System.Drawing;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
     private static void Main(string[] args)
    {
        const string CommandToAddTrain = "1";
        const string CommandToDepartTrain = "2";
        const string CommandToShowAllTrain = "3";
        const string CommandToExit = "9";

        Console.Clear();
        Console.WriteLine("Добро пожаловать в управление железной дорогой!");

        Reilway reilway = new Reilway();
        bool isActive = true;

        while (isActive)
        {
            reilway.PrintTrainsOnTheWay();

            Console.WriteLine("\nМеню управления: ");
            Console.WriteLine($"{CommandToAddTrain} - добавить новый поезд");
            Console.WriteLine($"{CommandToDepartTrain} - отправить поезд");
            Console.WriteLine($"{CommandToShowAllTrain} - показать все поезда");
            Console.WriteLine($"{CommandToExit} - выход из игры");

            Console.Write("Ваш выбор: ");
            string currentCommand = Console.ReadLine();

            switch (currentCommand)
            {
                case CommandToAddTrain:
                    reilway.AddTrain();
                    break;

                case CommandToDepartTrain:
                    reilway.TryDepartTrain();
                    break;

                case CommandToShowAllTrain:
                    reilway.Print();
                    break;

                case CommandToExit:
                    isActive = false;
                    break;
            }

            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
    }
}

class Reilway
{
    private List<Train> _trains = new List<Train>();

    public void AddTrain()
    {
        Direction direction = new Direction();
        int tickets = SoldTickets();
        Train train = new Train(tickets, direction);
        _trains.Add(train);
    }

    public void TryDepartTrain()
    {
        PrintTrainsInTheRailway();

        int id = -1;
        bool isActive = false;

        do
        {
            Console.Write("\nВведите номер поезда для отправления: ");

            if (int.TryParse(Console.ReadLine(), out id) == false)
            {
                Console.WriteLine("Ошибка при вводе...");
                Console.ReadKey();
                isActive = true;
            }

        } while (isActive);

        DepartTrain(id);
    }

    public void PrintTrainsOnTheWay()
    {
        Console.Clear();
        Console.WriteLine("Поезда в пути: ");

        foreach (Train train in _trains)
            if (train.IsDepart)
                train.Print();
    }

    public void Print()
    {
        Console.Clear();
        Console.WriteLine("Поезда: ");

        foreach (Train train in _trains)
            train.Print();
    }

    private void PrintTrainsInTheRailway()
    {
        Console.Clear();

        foreach (Train train in _trains)
        {
            if (train.IsDepart == false)
                train.Print();
        }
    }

    private void DepartTrain(int id)
    {
        if (TryGetTrain(id, out Train trainForDepart))
        {
            if (trainForDepart.IsDepart)
            {
                Console.WriteLine("Поезд нельзя отправить повторно");
            }
            else
            {
                trainForDepart.Depart();
                Console.WriteLine("Поезд отправлен");
            }
        }
    }

    private bool TryGetTrain(int id, out Train train)
    {
        foreach (Train currentTrain in _trains)
        {
            if (currentTrain.Id == id)
            {
                train = currentTrain;
                return true;
            }
        }

        train = null;
        return false;
    }

    private int SoldTickets()
    {
        int tickets = -1;

        while (tickets <= 0)
        {
            Console.Clear();
            Console.Write("Введите количество проданных билетов: ");

            if (int.TryParse(Console.ReadLine(), out tickets) == false)
            {
                Console.WriteLine("Введено неверное значение, попробуйте ещё раз");
                Console.ReadKey();
            }
        }

        return tickets;
    }

}

class Direction
{
    public Direction()
    {
        Console.Clear();
        Console.Write("Введите пункт отправления: ");
        Departure = Console.ReadLine();
        Console.Write("Введите пункт назначения: ");
        Arrival = Console.ReadLine();
    }

    public string Departure { get; private set; }
    public string Arrival { get; private set; }
}

class Train
{
    private List<TrainCar> _trainCars = new List<TrainCar>();
    private Direction _direction;

    private static int _lastId = -1;


    public Train(int tickets, Direction direction) 
    {
        Id = ++_lastId;
        _direction = direction;
        IsDepart = false;

        while (tickets > 0)
        {
            TrainCar trainCar= new TrainCar();
            _trainCars.Add(trainCar);
            tickets -= trainCar.NumberOfPlaces;
        }
    }  

    public bool IsDepart { get; private set; }
    public string Departure => _direction.Departure;
    public string Arrival => _direction.Arrival;
    public int Id { get; private set; }

    public void Depart()
    {
        IsDepart = true;
    }

    public void Print()
    {
        Console.WriteLine(GetDescription());
    }

    private string GetDescription()
    {
        string status;

        if (IsDepart)
            status = "поезд в пути";
        else 
            status = "позд не отправлен";

        string trainCars = "";
        int numberOfTranCar = 0;

        foreach (TrainCar train in _trainCars)
            trainCars += $"Вагон {++numberOfTranCar} " +
                $"занято {train.NumberOfPlaces} мест. ";

        return $"{Id}. {Departure}\t-\t{Arrival}. Статус: {status}. {trainCars}";
    }
}

class TrainCar
{
    public TrainCar() 
    {
        int lowerBoundOfPlaces = 10;
        int upperBoundOfPlaces = 25;
        Random random = new Random();

        NumberOfPlaces = random.Next(lowerBoundOfPlaces, upperBoundOfPlaces);
    }
    
    public int NumberOfPlaces { get; private set; }
}