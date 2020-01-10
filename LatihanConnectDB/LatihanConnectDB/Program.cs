using LatihanConnectDB.Controller;
using LatihanConnectDB.Injection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatihanConnectDB
{
    class Program
    {
        UserController userController;        

        static void Main(string[] args)
        {
            // Program is injected by the Inject class to provide UserController
            new Program(Inject.ProvideUserController());
        }

        public Program(UserController userController)
        {
            // Assign userController from constructor parameter to our main userController Object
            this.userController = userController;

            int choice = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Book DB");
                Console.WriteLine("=======");
                Console.WriteLine("1. Create book");
                Console.WriteLine("2. Get all book");
                Console.WriteLine("3. Delete book");
                Console.WriteLine("4. Update book");
                Console.WriteLine("5. Exit");

                do
                {
                    Console.Write(">> ");
                    choice = int.Parse(Console.ReadLine());
                }
                while (choice < 1 || choice > 5);

                switch (choice)
                {
                    case 1:
                        CreateBook();
                        break;
                    case 2:
                        GetAllBook();
                        break;
                    case 3:
                        DeleteBook();
                        break;
                    case 4:
                        UpdateBook();
                        break;
                }

                Console.WriteLine("Press ENTER to continue...");
                Console.ReadKey();
            } while (choice != 5);
        }

        private void UpdateBook()
        {
            GetAllBook();

            string bookId = "";

            do
            {
                Console.WriteLine("Input Book ID : ");
                bookId = Console.ReadLine();
            }
            while (userController.CheckBookID(bookId));

            string bookTitle = "";
            string bookAuthor = "";
            int price = 0;

            Console.WriteLine("Input book title: ");
            bookTitle = Console.ReadLine();

            Console.WriteLine("Input book author: ");
            bookAuthor = Console.ReadLine();

            userController.Update(bookId, bookTitle, bookAuthor);
            
            Console.WriteLine("Update success");
        }

        private void DeleteBook()
        {
            GetAllBook();

            string bookId = "";
            do 
            {
                Console.WriteLine("Input Book ID : ");
                bookId = Console.ReadLine();
            }
            while (userController.CheckBookID(bookId));

            userController.Delete(bookId);
            Console.WriteLine("Delete success");
        }

        private void GetAllBook()
        {
            List<Book> bookList = userController.GetAllBook();
            Console.WriteLine("List book from database:");
            foreach(Book book in bookList)
            {
                Console.WriteLine("BookId = " + book.BookId);
                Console.WriteLine("BookTitle = " + book.BookTitle);
                Console.WriteLine("BookAuthor = " + book.BookAuthor);
                Console.WriteLine("BookPrice = " + book.Price);
                Console.WriteLine();
            }
        }

        private void CreateBook()
        {
            string bookId, bookTitle, bookAuthor;
            int price;
            
            do
            {
                Console.WriteLine("Input book id: ");
                bookId = Console.ReadLine();
            }
            while (userController.CheckBookID(bookId));
            
            do
            {
                Console.WriteLine("Input book title: ");
                bookTitle = Console.ReadLine();
            }
            while (userController.CheckBookTitle(bookTitle));
            
            do
            {
                Console.WriteLine("Input book author: ");
                bookAuthor = Console.ReadLine();
            }
            while (userController.CheckBookAuthor(bookAuthor));
            
            do
            {
                Console.WriteLine("Input book price: ");
                try
                {
                    price = int.Parse(Console.ReadLine());
                }                
                catch(Exception e)
                {
                    price = -1;
                    Console.WriteLine(e.Message);
                }
            }
            while (userController.CheckBookPrice(price));

            userController.Insert(
                bookId, 
                bookTitle, 
                bookAuthor, 
                price);

            Console.WriteLine("Create book success");
        }
    }
}
