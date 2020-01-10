using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatihanConnectDB
{
    class Book
    {        
        // Model
        // Hold the Data
        // Can assumed as table representation in code

        public Book()
        {

        }

        public Book(string bookId, string bookTitle, string bookAuthor, int price)
        {
            BookId = bookId;
            BookTitle = bookTitle;
            BookAuthor = bookAuthor;
            Price = price;
        }

        public string BookId { get; set; }
        public string BookTitle { get; set; }
        public string BookAuthor { get; set; }
        public int Price { get; set; }
    }
}
