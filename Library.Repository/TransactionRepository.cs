using Library.BusinessObjects;
using System;
using System.Data.SqlClient;

namespace Library.Repository

{
    public class TransactionRepository : ITransactionRepository
    {
        private SqlConnection conn = new SqlConnection("Data Source=PremierDBDev1;Initial Catalog=Library;Pooling=true;Min Pool Size = 1;Max Pool Size=100;Integrated Security=False;Persist Security Info=False;user id=sa;password=$elf!h0st;Connect Timeout=300");
        private BookRepository br = new BookRepository();

        public bool IssueBook(User user, Book book)
        {
            int success = 0;
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand("insert into [Transaction] (UserId, BookId, IssuedOn) values (" + user.userId + "," + book.bookId + ", getdate())");
                command.Connection = conn;
                success = command.ExecuteNonQuery();
                //decrement book quantity by 1  NEED TO IMPLEMENT IN BOOK REPOSITORY

                conn.Close();

                if (success > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}