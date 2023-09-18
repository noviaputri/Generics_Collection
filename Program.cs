using System;
using System.Collections.Generic;

// Defines Book class with three properties
public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int PublicationYear { get; set; }
}

// Defines LibraryCatalog class has four methods : AddBook, RemoveBook, FindBook, and ListBooks
public class LibraryCatalog
{
    // Declares a private instance variable called books, which is a list of Book objects
    private List<Book> books = new List<Book>();

    public void AddBook(Book book)
    {
        books.Add(book);
    }

    public void RemoveBook(Book book)
    {
        books.Remove(book);
    }

    public Book FindBook(string title)
    {
        return books.Find(b => b.Title.ToLower() == title.ToLower());
    }

    public void ListBooks()
    {
        foreach (var book in books)
        {
            Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Publication Year: {book.PublicationYear}");
        }
    }
}

// Defines LibraryApp class contains the Main method and provides a menu-based interface for interacting with the library catalog
public class LibraryApp
{
    // Declares a private static variable named catalog of type LibraryCatalog
    private static LibraryCatalog catalog = new LibraryCatalog();

    public static void Main(string[] args)
    {
        bool exit = false;

        // Looping for provides a menu-based interface for interacting with the library catalog
        while (!exit)
        {
            Console.WriteLine("Library Catalog App");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Remove Book");
            Console.WriteLine("3. Find Book");
            Console.WriteLine("4. List Books");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddBook();
                    break;
                case "2":
                    RemoveBook();
                    break;
                case "3":
                    FindBook();
                    break;
                case "4":
                    ListBooks();
                    break;
                case "5":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();

            // Looping for provides if a user want to back to library catalog or not
            if (!exit)
            {
                bool validChoice = false;

                while (!validChoice)
                {
                    Console.Write("Would you like to go back to Library Catalog App? (Yes/No) : ");
                    string continueChoice = Console.ReadLine();

                    if (continueChoice.ToLower() == "yes")
                    {
                        exit = false;
                        Console.Clear();
                        validChoice = true;
                    }
                    else if (continueChoice.ToLower() == "no")
                    {
                        exit = true;
                        validChoice = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter Yes or No.");
                    }
                }
            }
        }
    }

    // Method definition for AddBook. This method is part of the LibraryApp class and is used to add a new book to the library catalog
    private static void AddBook()
    {
        try
        {
            Console.Write("Enter title: ");
            string title = Console.ReadLine();

            Console.Write("Enter author: ");
            string author = Console.ReadLine();

            Console.Write("Enter publication year: ");
            int publicationYear = int.Parse(Console.ReadLine());

            var book = new Book
            {
                Title = title,
                Author = author,
                PublicationYear = publicationYear
            };

            catalog.AddBook(book);

            Console.WriteLine("Book added successfully.");
        }
        // Catch the exception and call the HandleError method of the ErrorHandler class to display an error message to the user
        catch (Exception ex)
        {
            ErrorHandler.HandleError(ex);
        }
    }

    // Method definition for RemoveBook. This method is part of the LibraryApp class and is used to remove a book from the library catalog
    private static void RemoveBook()
    {
        Console.Write("Enter title: ");
        string title = Console.ReadLine();

        var book = catalog.FindBook(title);

        if (book != null)
        {
            catalog.RemoveBook(book);
            Console.WriteLine("Book removed successfully.");
        }
        else
        {
            Console.WriteLine("Book not found.");
        }
    }

    // Method definition for FindBook. This method is part of the LibraryApp class and is used to find a book from the library catalog
    private static void FindBook()
    {
        Console.Write("Enter title: ");
        string title = Console.ReadLine();

        var book = catalog.FindBook(title);

        if (book != null)
        {
            Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Publication Year: {book.PublicationYear}");
        }
        else
        {
            Console.WriteLine("Book not found.");
        }
    }

    // Method definition for ListBooks. This method is part of the LibraryApp class and is used to show list of book from the library catalog
    private static void ListBooks()
    {
        catalog.ListBooks();
    }
}

// Defines ErrorHandler class with HandleError method to takes an Exception object as input and displays an error message to the user
public class ErrorHandler
{
    public static void HandleError(Exception ex)
    {
        Console.WriteLine("An error occurred:");
        Console.WriteLine(ex.Message);
    }
}