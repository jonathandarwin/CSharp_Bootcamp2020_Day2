using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatihanConnectDB
{
    class BookRepository
    {
        // Repository
        // A class to do some CRUD operation
        // the logic about how we get/store the data is written here

        // To connect the repository and database, we need 3 main object :
        // SqlConnection : Provide DB Connection Info
        // SqlCommand    : To execute the query
        // SqlDataReader : After execute data, the return is stored to this object

        // 2. All the function below use raw query for CRUD operation that stored to string
        // If you want to call a Stored Procedure, the step is same as the raw query, except : 

        // a. string `query` value is the name of the Stored Procedure
        // string query = "SELECT * FORM msBook";
        // TO : 
        // string query = "book_get_all";

        // b. Command Type
        // command.CommandType = CommandType.Text;
        // To :
        // command.CommandType = CommandType.StoredProcedure;

        // c. Provide the parameter that correspond to that Stored Procedure

        public void InsertBookToDatabase(Book book)
        {
            // Initiate
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=.;Initial Catalog=BookDB;Integrated Security=True");
            SqlCommand command = new SqlCommand();
            SqlDataReader reader;

            // Set Query
            string query = "INSERT INTO Book VALUES(@BookId, @BookTitle, @BookAuthor, @Price)";

            // Set Parameter
            command.Parameters.Add("@BookId", SqlDbType.VarChar, 100).Value = book.BookId;
            command.Parameters.Add("@BookTitle", SqlDbType.VarChar, 100).Value = book.BookTitle;
            command.Parameters.Add("@BookAuthor", SqlDbType.VarChar, 100).Value = book.BookAuthor;
            command.Parameters.Add("@Price", SqlDbType.Int).Value = book.Price;

            // Prepare for Execution
            command.Connection = sqlConnection;
            command.CommandType = CommandType.Text;
            command.CommandText = query;

            // Open Connection
            sqlConnection.Open();

            // Execute Query
            command.ExecuteNonQuery();

            // Close All Connection
            command.Dispose();
            sqlConnection.Close();
        }

        public List<Book> GetAllBookFromDatabase()
        {
            // Initiate
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=.;Initial Catalog=BookDB;Integrated Security=True");
            SqlCommand command = new SqlCommand();
            SqlDataReader reader;
            List<Book> bookList = new List<Book>();


            // Set Query
            string query = "SELECT * FROM Book";

            // Prepare for Execution
            command.Connection = sqlConnection;
            command.CommandType = CommandType.Text;
            command.CommandText = query;

            // Open Connection
            sqlConnection.Open();

            // Execute Query
            reader = command.ExecuteReader();

            // Check Whether the Query is returned a result or not
            if (reader.HasRows)
            {
                // Looping as long as the reader object can read a row of the result
                while(reader.Read())
                {
                    // Add a Model
                    Book book = new Book();
                    book.BookId = reader["BookId"].ToString();
                    book.BookTitle = reader["BookTitle"].ToString();
                    book.BookAuthor = reader["BookAuthor"].ToString();
                    book.Price = int.Parse(reader["Price"].ToString());

                    // Add to List
                    bookList.Add(book);
                }
            }

            // Close All Connection
            command.Dispose();
            reader.Close();
            sqlConnection.Close();

            return bookList;
        }

        public void DeleteBookFromDatabase(string bookId)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=.;Initial Catalog=BookDB;Integrated Security=True");
            SqlCommand command = new SqlCommand();
            SqlDataReader reader;

            string query = "DELETE Book WHERE BookId = @BookId";

            command.Parameters.Add("@BookId", SqlDbType.VarChar, 100).Value = bookId;

            command.Connection = sqlConnection;
            command.CommandType = CommandType.Text;
            command.CommandText = query;

            sqlConnection.Open();
            command.ExecuteNonQuery();
            

            command.Dispose();
            sqlConnection.Close();
        }

        public void UpdateBookFromDatabase(Book book)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=.;Initial Catalog=BookDB;Integrated Security=True");
            SqlCommand command = new SqlCommand();
            SqlDataReader reader;

            string query 
                = "UPDATE Book SET BookTitle = @BookTitle" + 
                ", BookAuthor = @BookAuthor WHERE BookId = @BookId";

            command.Parameters.Add("@BookId", SqlDbType.VarChar, 100).Value = book.BookId;
            command.Parameters.Add("@BookTitle", SqlDbType.VarChar, 100).Value = book.BookTitle;
            command.Parameters.Add("@BookAuthor", SqlDbType.VarChar, 100).Value = book.BookAuthor;

            command.Connection = sqlConnection;
            command.CommandType = CommandType.Text;
            command.CommandText = query;

            sqlConnection.Open();
            command.ExecuteNonQuery();


            command.Dispose();
            sqlConnection.Close();
        }
    }
}
