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
        Book bookObj = new Book();
        public Book SearchBook(String Name)
        {


            conn.Open();
            SqlCommand command = new SqlCommand("select * from Books where Name = \'" + Name + "\'");
            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                bookObj.Name = (string)reader["Name"];
                bookObj.bookId = (int)reader["bookId"];
                bookObj.Quantity = (int)reader["Quantity"];


            }
            conn.Close();
            return bookObj;

        }

    }
}
