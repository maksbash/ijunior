internal class Program
{
    private static void Main(string[] args)
    {
        const int CommandToAddBook = 1;
        const int CommandToRemoveBook = 2;
        const int CommandToShowAllBooks = 3;
        const int CommandToShowAllBooksByYear = 4;
        const int CommandToShowAllBooksByGenre = 5;
        const int CommandToExit = 9;

        BookStorage bookStorage = new BookStorage();

        bool isActive = true;
        int currentCommand;

        while (isActive)
        {
            Console.Clear();
            Console.WriteLine("Меню хранилища книг:");
            Console.WriteLine($"{CommandToAddBook} Добавить книгу");
            Console.WriteLine($"{CommandToRemoveBook} Удалить книгу");
            Console.WriteLine($"{CommandToShowAllBooks} Показать все книги");
            Console.WriteLine($"{CommandToShowAllBooksByYear} Показать все " +
                $"книги по году издания");
            Console.WriteLine($"{CommandToShowAllBooksByGenre} Показать все " +
                $"книги по жанру");
            Console.WriteLine($"{CommandToExit} Выход");
            Console.Write("Введите команду: ");

            currentCommand = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            switch (currentCommand)
            {
                case CommandToAddBook:
                    bookStorage.AddBook();
                    break;

                case CommandToRemoveBook:
                    bookStorage.RemoveBook();
                    break;

                case CommandToShowAllBooks:
                    bookStorage.ShowAllBooks();
                    break;

                case CommandToShowAllBooksByYear:
                    bookStorage.ShowAllBooksByYear();
                    break;

                case CommandToShowAllBooksByGenre:
                    bookStorage.ShowAllBooksByGenre();
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

class BookStorage
{
    private List<Book> _books = new List<Book>();
    private Dictionary<int, Book> _bookStorage = new Dictionary<int, Book>();
    private int lastId = -1;

    public void AddBook()
    {
        Author author;
        Book book;
        Genre genre;
        string bookName;
        string authorFullName;
        int year;
        string genreName;

        Console.Clear();
        Console.WriteLine("Добавление новой книги");
        Console.Write("Введите название книги: ");
        bookName = Console.ReadLine();
        Console.Write("\nВведите ФИО автора: ");
        authorFullName = Console.ReadLine();
        Console.Write("\nВведите год издания: ");
        year = Convert.ToInt32(Console.ReadLine());
        Console.Write("\nВведите жанр: ");
        genreName = Console.ReadLine();

        genre = new Genre(genreName);
        author = new Author(authorFullName);
        book = new Book(bookName, author, year, genre);

        _bookStorage.Add(++lastId, book);
    }

    public void RemoveBook()
    {
        int id;
        Console.Clear();
        Console.WriteLine("Удаление книги");
        Console.Write("Введите номер книги для удаления: ");
        id = Convert.ToInt32(Console.ReadLine());

        if (_bookStorage.Keys.Contains(id))
            _bookStorage.Remove(id);
    }

    public void ShowAllBooks()
    {
        Console.Clear();
        Console.WriteLine("Хранилище книг: ");
        foreach (var bookDesk in _bookStorage)
        {
            Book book = bookDesk.Value;
            PrintBook(bookDesk.Key, book);
        }
    }

    public void ShowAllBooksByYear()
    {
        int year;

        Console.Clear();
        Console.Write("\nВведите год издания: ");
        year = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine($"\n\nХранилище книг {year} года: ");

        foreach (var bookDesk in _bookStorage)
        {
            Book book = bookDesk.Value;
            if (book.Year == year)
                PrintBook(bookDesk.Key, book);
        }
    }

    public void ShowAllBooksByAuthor()
    {
        string authorFullName;

        Console.Clear();
        Console.Write("\nВведите ФИО автора: ");
        authorFullName = Console.ReadLine();

        Console.WriteLine($"Хранилище книг автора {authorFullName}: ");

        foreach (var bookDesk in _bookStorage)
        {
            Book book = bookDesk.Value;
            if (book.Author.FullName == authorFullName)
                PrintBook(bookDesk.Key, book);
        }
    }

    public void ShowAllBooksByGenre()
    {
        string genreName;

        Console.Clear();
        Console.Write("\nВведите жанр: ");
        genreName = Console.ReadLine();

        Console.WriteLine($"Хранилище книг жанра {genreName}: ");

        foreach (var bookDesk in _bookStorage)
        {
            Book book = bookDesk.Value;
            if (book.Genre.Name == genreName)
                PrintBook(bookDesk.Key, book);
        }
    }

    private void PrintBook(int key, Book book)
    {
        Console.Write($"\n{key} - {book.GetDescription()}");
    }
}


class Book
{
    public Book(string name, Author author, int year, Genre genre)
    {
        Name = name;
        Author = author;
        Year = year;
        Genre = genre;
    }

    public string Name { get; private set; }
    public Author Author { get; private set; }
    public int Year { get; private set; }
    public Genre Genre { get; private set; }

    public string GetDescription()
    {
        string description = $"Название: {Name}, автор: {Author.FullName}, " +
            $"год: {Year}, жанр: {Genre.Name}";

        return description;
    }
}

class Author
{
    public Author(string fullName)
    {
        FullName = fullName;
    }

    public string FullName { get; set; }
}

class Genre
{
    public Genre(string genreName)
    {
        Name = genreName;
    }

    public string Name { get; private set; }
}
