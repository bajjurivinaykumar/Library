using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.BusinessObjects;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Library.Repository
{
    public class BookRepository
    {
        SqlConnection conn = new SqlConnection("Data Source=PremierDBDev1;Initial Catalog=Library;Pooling=true;Min Pool Size = 1;Max Pool Size=100;Integrated Security=False;Persist Security Info=False;user id=sa;password=$elf!h0st;Connect Timeout=300");

        Book Bookobj = new Book();
        public Book SearchBookByName(string name)
        {        

            conn.Open();
            SqlCommand command = new SqlCommand("select * from Books where Name = '" +  name+"'" );
            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Bookobj.Name = (string)reader["Name"];
                Bookobj.Quantity = (int)reader["Quantity"];
                Bookobj.BookId = (int)reader["bookId"];

            }
            conn.Close();
            return Bookobj;

        }

        public Book SearchByPublishedBy(String PublishedBy)
        {

           
            conn.Open();
            SqlCommand command = new SqlCommand("Select * from Books where PublishedBy='" + PublishedBy+"'");
            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Bookobj.PublishedBy = (String)reader["PublishedBy"];
            }
            conn.Close();
            return Bookobj;

            


        }

        public bool AddBook(Book book)
        {
            conn.Open();
            SqlCommand Command = new SqlCommand("Insert into Books(name,PublishedBy,Price)Values(\' " + book.Name + "\'," +
                "\'" + book.PublishedBy + "\'," + book.price +")");
            Command.Connection = conn;
            int Success=Command.ExecuteNonQuery();
            if (Success > 0)
                {
                return true;
            }
            else
            {
                return false;
            }



          
        }



        public bool EditQuantity(int bookID, int Quantity)
        {
            conn.Open();
            SqlCommand Command= new SqlCommand("Update Books set Quantity= " + Quantity + "  where Bookid= "+bookID+"");
            Command.Connection = conn;
            int Success = Command.ExecuteNonQuery();
            conn.Close();
            if (Success > 0)
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
            SqlCommand Command = new SqlCommand("Delete from Books where Bookid=" + bookid + "");
            Command.Connection = conn;
            int Success = Command.ExecuteNonQuery();
            if (Success > 0)
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
