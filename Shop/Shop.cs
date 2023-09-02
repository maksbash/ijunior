﻿internal class Program
{
    private static void Main(string[] args)
    {
        const string CommandToAddBook = "1";
        const string CommandToRemoveBook = "2";
        const string CommandToShowAllBooks = "3";
        const string CommandToShowAllBooksByYear = "4";
        const string CommandToShowAllBooksByGenre = "5";
        const string CommandToShowAllBooksByAuthor = "6";
        const string CommandToExit = "9";

        BookStorage bookStorage = new BookStorage();

        bool isActive = true;
        string currentCommand;

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
            Console.WriteLine($"{CommandToShowAllBooksByAuthor} Показать все " +
                $"книги по автору");
            Console.WriteLine($"{CommandToExit} Выход");
            Console.Write("Введите команду: ");

            currentCommand = Console.ReadLine();

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

                case CommandToShowAllBooksByAuthor:
                    bookStorage.ShowAllBooksByAuthor();
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
    private Dictionary<int, Book> _books = new Dictionary<int, Book>();
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

        year = RequestYear();

        Console.Write("\nВведите жанр: ");
        genreName = Console.ReadLine();

        genre = new Genre(genreName);
        author = new Author(authorFullName);
        book = new Book(bookName, author, year, genre);

        _books.Add(++lastId, book);
    }

    public void RemoveBook()
    {
        int id;
        Console.Clear();
        Console.WriteLine("Удаление книги");
        Console.Write("Введите номер книги для удаления: ");

        if (int.TryParse(Console.ReadLine(), out id))
            if (_books.Keys.Contains(id))
                _books.Remove(id);
    }

    public void ShowAllBooks()
    {
        Console.Clear();
        Console.WriteLine("Хранилище книг: ");

        foreach (var bookDesk in _books)
        {
            Book book = bookDesk.Value;
            PrintBook(bookDesk.Key, book);
        }
    }

    public void ShowAllBooksByYear()
    {
        int year;

        Console.Clear();
        year = RequestYear();

        Console.WriteLine($"\n\nХранилище книг {year} года: ");

        foreach (var bookDesk in _books)
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

        foreach (var bookDesk in _books)
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

        foreach (var bookDesk in _books)
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

    private int RequestYear()
    {
        int year;

        Console.Write("\nВведите год издания: ");

        if (int.TryParse(Console.ReadLine(), out year))
            return year;

        Console.WriteLine("Введено некорректное значение!");

        return RequestYear();
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

class Salesman : Person
{
    public Salesman(string name) : base(name) { }

    public void Sell(Product product)
    {
        if (_products.Contains(product))
        {
            _cache += product.Cost;
            _products.Remove(product);
        }
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

}

class Person
{
    protected List<Product> _products = new List<Product>();
    protected int _cache;

    public Person(string name)
    {
        Name = name;
    }

    public string Name { get; protected set; }

    public void ShowProduct()
    {
        foreach (Product product in _products)
            Console.WriteLine(product);
    }
}

class Product
{
    public Product(string name, int cost)
    {
        Name = name;
        Cost = cost;
    }

    public string Name { get; private set; }
    public int Cost { get; private set; }
}