using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatihanConnectDB.Controller
{
    class UserController
    {
        // Controller
        // The main business logic is written here
        // As a bridge between view and repository too
        // and remember, don't create any object in this class
        // instead, use dependency Injection

        BookRepository bookRepository;

        public UserController(BookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }        

        public void Update(string bookId, string bookTitle, 
            string bookAuthor)
        {
            Book book = new Book(bookId, bookTitle, bookAuthor, -1);
            bookRepository.UpdateBookFromDatabase(book);
        }

        public void Delete(string bookId)
        {
            bookRepository.DeleteBookFromDatabase(bookId);
        }

        public List<Book> GetAllBook()
        {
            return bookRepository.GetAllBookFromDatabase();
        }

        public void Insert(string bookId, string bookTitle, 
            string bookAuthor, int price)
        {
            Book book = new Book(bookId, bookTitle, bookAuthor, price);
            bookRepository.InsertBookToDatabase(book);
        }

        public bool CheckBookID(string bookId)
        {
            // tidak boleh kosong
            // huruf depan nya harus 'B'
            return bookId.Equals("") || 
                bookId.ElementAt(0) != 'B';
        }

        public bool CheckBookTitle(string bookTitle)
        {
            // length >= 8
            return bookTitle.Length < 8;
        }

        public bool CheckBookAuthor(string bookAuthor)
        {
            // nama harus 2 kata
            // Jonathan Darwin

            bookAuthor = bookAuthor.Trim();

            int length = bookAuthor.Length;
            int space = bookAuthor.IndexOf(' ');                        

            return space == -1 || bookAuthor.ElementAt(length - 1) == ' ';
        }

        public bool CheckBookPrice(int price)
        {
            // 100.000 <= price <= 1.000.000
            return price < 100000 || price > 1000000;
        }
    }
}
