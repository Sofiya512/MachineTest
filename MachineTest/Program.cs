

//SET-1

//Create an application to manage a library.The application will have  An interface Ibooks that has the methods AddBooks and GetDetails
//A class Books that has the methods AddBooks()to add the details of the book like id, name and category  and GetBookDetails() to
//retrieve the details of the books. This class should implement from IBooks .
//The AddBooks and GetBookDetails should be a choice get from the user.Retrieve the details of the books into a suitable collection
//Handle all exceptions at runtime.



using System;
using System.Collections.Generic;

namespace LibraryManagementSystem
{
    interface IBooks
    {
        void AddBook(int id, string name, string category);
        void GetBookDetails();
        void SearchBook(int id);
    }

    class Books : IBooks
    {
        private List<Book> bookCollection = new List<Book>();

        public void AddBook(int id, string name, string category)
        {
            try
            {
                if (bookCollection.Exists(book => book.Id == id))
                {
                    Console.WriteLine("Book with the same ID already exists.");
                }
                else
                {
                    Book newBook = new Book(id, name, category);
                    bookCollection.Add(newBook);
                    Console.WriteLine("Book added successfully!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        public void GetBookDetails()
        {
            try
            {
                if (bookCollection.Count == 0)
                {
                    Console.WriteLine("No books in the library.");
                }
                else
                {
                    Console.WriteLine("List of Books:");
                    foreach (var book in bookCollection)
                    {
                        Console.WriteLine($"ID: {book.Id}, Name: {book.Name}, Category: {book.Category}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        public void SearchBook(int id)
        {
            try
            {
                var foundBook = bookCollection.Find(book => book.Id == id);
                if (foundBook != null)
                {
                    Console.WriteLine($"Book found with ID {id}:");
                    Console.WriteLine($"ID: {foundBook.Id}, Name: {foundBook.Name}, Category: {foundBook.Category}");
                }
                else
                {
                    Console.WriteLine($"No book found with ID {id}.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }

    class Book
    {
        public int Id;
        public string Name;
        public string Category;

        public Book(int id, string name, string category)
        {
            Id = id;
            Name = name;
            Category = category;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LIBRARY MANAGEMENT SYSTEM");
            IBooks library = new Books();

            while (true)
            {
                Console.WriteLine("\nLibrary Management System Menu:");
                Console.WriteLine("1. Add a Book");
                Console.WriteLine("2. Get Book Details");
                Console.WriteLine("3. Search for a Book by ID");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter Book ID: ");
                            int id = int.Parse(Console.ReadLine());
                            Console.Write("Enter Book Name: ");
                            string name = Console.ReadLine();
                            Console.Write("Enter Book Category: ");
                            string category = Console.ReadLine();
                            library.AddBook(id, name, category);
                            break;

                        case 2:
                            library.GetBookDetails();
                            break;

                        case 3:
                            Console.Write("Enter the Book ID to search for: ");
                            if (int.TryParse(Console.ReadLine(), out int searchId))
                            {
                                library.SearchBook(searchId);
                            }
                            else
                            {
                                Console.WriteLine("Invalid input for Book ID.");
                            }
                            break;

                        case 4:
                            Console.WriteLine("Exiting the program.");
                            return;

                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid choice.");
                }
            }
        }
    }
}
