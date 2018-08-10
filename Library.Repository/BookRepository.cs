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

        Book userObj = new Book();
        public Book SearchBook(int Bookid)
        {


            conn.Open();
            SqlCommand command = new SqlCommand("select * from users where Bookid = " + Bookid);
            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                userObj.bookName = (string)reader["Name"];

            }
            conn.Close();
            return userObj;

        }

        public bool AddBook(Book Book)
        {
            return false;
        }
}
}
