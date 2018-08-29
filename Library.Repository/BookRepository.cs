using Library.BusinessObjects;
using Library.BusinessObjects.enums;
using System.Data.SqlClient;

namespace Library.Repository
{
    public class BookRepository : IBookRepository
    {
        private SqlConnection conn = new SqlConnection("Data Source=PremierDBDev1;Initial Catalog=Library;Pooling=true;Min Pool Size = 1;Max Pool Size=100;Integrated Security=False;Persist Security Info=False;user id=sa;password=$elf!h0st;Connect Timeout=300");

        private Book bookObj = new Book();

        public Book SearchBookByName(string name)
        {
            conn.Open();
            SqlCommand command = new SqlCommand("select * from Books where Name = '" + name + "'");
            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                bookObj.name = (string)reader["name"];
                bookObj.quantity = reader.IsDBNull(4) ? 0 : (int)reader["quantity"];
                bookObj.bookId = (int)reader["bookId"];
                bookObj.publishedBy = (string)reader["publishedBy"];
                bookObj.bookType = (BookType)reader["BookTypeID"];
            }
            conn.Close();
            return bookObj;
        }

        public Book SearchByPublishedBy(string publishedBy)
        {
            conn.Open();
            SqlCommand command = new SqlCommand("Select * from Books where publishedBy='" + publishedBy + "'");
            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                bookObj.name = (string)reader["name"];
                bookObj.quantity = reader.IsDBNull(4) ? 0 : (int)reader["quantity"];
                bookObj.bookId = (int)reader["bookId"];
                bookObj.publishedBy = (string)reader["publishedBy"];
                bookObj.bookType = (BookType)reader["bookTypeID"];
            }
            conn.Close();
            return bookObj;
        }

        public bool AddBook(Book book)
        {
            conn.Open();

            SqlCommand Command = new SqlCommand("Insert into Books(name,PublishedBy,Price,booktypeID)Values(\'" + book.name + "\'," +
                "\'" + book.publishedBy + "\'," + book.price + "," + book.bookType + ")");
            Command.Connection = conn;
            int success = Command.ExecuteNonQuery();
            if (success > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EditQuantity(int bookID, int quantity)
        {
            conn.Open();
            SqlCommand Command = new SqlCommand("update Books set Quantity= " + quantity + "  where Bookid= " + bookID + "");
            Command.Connection = conn;
            int success = Command.ExecuteNonQuery();
            conn.Close();
            if (success > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteBook(int bookid)
        {
            conn.Open();
            SqlCommand Command = new SqlCommand("delete from Books where Bookid=" + bookid + "");
            Command.Connection = conn;
            int success = Command.ExecuteNonQuery();
            if (success > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}