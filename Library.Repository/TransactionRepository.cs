﻿using Library.BusinessObjects;
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
                SqlCommand command = new SqlCommand("insert into [Transaction] (UserId, BookId, IssuedOn,status,Duedate) values (" + user.userId + "," + book.bookId + ", getdate(),0,dateadd(Month,1,getdate()))");
                command.Connection = conn;
                success = command.ExecuteNonQuery();

                conn.Close();

                if (success > 0)
                {
                    br.EditQuantity(book.bookId, book.quantity - 1);
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ReturnBook(int userid, Book book)
        {
            conn.Open();
            // SqlCommand Command = new SqlCommand("Update [Transactions] set ReturnedON = "+ReturnedON+" where UserID= "+userid+" and BookID="+book.bookId+"");
            SqlCommand command = new SqlCommand("ReturnBook");
            command.Connection = conn;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@userId", userid));
            command.Parameters.Add(new SqlParameter("@BookId", book.bookId));
            int success = command.ExecuteNonQuery();

            if (success > 0)
            {
                br.EditQuantity(book.bookId, book.quantity + 1);

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RenewBook(int userID, Book book)
        {
            conn.Open();
            SqlCommand Command = new SqlCommand("Duedate");
            Command.CommandType = System.Data.CommandType.StoredProcedure;
            Command.Parameters.Add(new SqlParameter("@userId", userID));
            Command.Parameters.Add(new SqlParameter("@BookId", book.bookId));

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