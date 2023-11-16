using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        List<Criminal> criminals = new List<Criminal>
        {
            new Criminal("Иванов Иван Иванович", true, 178, 85, "Русский"),
            new Criminal("Петров Петр Петрович", false, 180, 91, "Русский"),
            new Criminal("Баширов Андрей Евставьевич ", false, 175, 79, "Татарин"),
            new Criminal("Кызыл Индат Рамонови", true, 160, 70, "Узбек"),
            new Criminal("Трынд Кудф Прадфлы", false, 165, 79, "Узбек"),
            new Criminal("Аламбашев Марат Айдарович", false, 177, 85, "Татарин")
        };

        bool isActive = true;
        string commandToExit = "exit";

        while (isActive)
        {
            Console.Clear();
            Console.Write("Введите рост преступника: ");
            string response = Console.ReadLine();
            int.TryParse(response, out int height);

            Console.Write("Введите вес преступника: ");
            response = Console.ReadLine();
            int.TryParse(response, out int weight);

            Console.Write("Введите национальность преступника: ");
            string nationality = Console.ReadLine();

            var filteredCriminals = criminals.Where(
                criminals => criminals.TakenIntoCustody == false &&
                criminals.Height == height && criminals.Weight == weight &&
                criminals.Nationality.ToUpper() == nationality.ToUpper()).Select(criminals => criminals.Name);

            Console.WriteLine("Вот что удалось найти:");

            foreach (var criminalElement in filteredCriminals)
                Console.WriteLine(criminalElement);

            Console.Write("Нажмите интр для продолжения " +
                $"или {commandToExit} для выхода: ");
            response = Console.ReadLine();

            if (response.ToLower() == commandToExit)
                isActive = false;
        }
    }
}

class Criminal
{
    public Criminal(string name, bool takenIntoCustody, int height, int weight,
        string nationality)
    {
        Name = name;
        TakenIntoCustody = takenIntoCustody;
        Height = height;
        Weight = weight;
        Nationality = nationality;
    }

    public string Name { get; private set; }
    public bool TakenIntoCustody { get; private set; }
    public int Height { get; private set; }
    public int Weight { get; private set; }
    public string Nationality { get; private set; }
}