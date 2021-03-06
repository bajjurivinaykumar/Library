﻿using Library.BusinessObjects;
using Library.BusinessObjects.enums;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace Library.Repository
{
    public class BookRepository : IBookRepository
    {
        private SqlConnection connection = new SqlConnection("Data Source=PremierDBDev1;Initial Catalog=Library;Pooling=true;Min Pool Size = 1;Max Pool Size=100;Integrated Security=False;Persist Security Info=False;user id=sa;password=$elf!h0st;Connect Timeout=300");
      
        private Book bookObj;

        public Book SearchBookByName(string name)
        {
            connection.Open();
            bookObj = new Book();
            SqlCommand command = new SqlCommand("select * from Books where Name = '" + name + "'");
            command.Connection = connection;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                bookObj.name = (string)reader["name"];
                bookObj.quantity = reader.IsDBNull(4) ? 0 : (int)reader["quantity"];
                bookObj.bookId = (int)reader["bookId"];
                bookObj.publishedBy = (string)reader["publishedBy"];
                bookObj.bookType =  (BookType)Enum.Parse(typeof(BookType), (string)reader["BookType"]);
            }
            connection.Close();
            return bookObj;
        }

        public Book SearchByPublishedBy(string publishedBy)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Select * from Books where publishedBy='" + publishedBy + "'");
            command.Connection = connection;
            bookObj = new Book();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                bookObj.name = (string)reader["name"];
                bookObj.quantity = reader.IsDBNull(4) ? 0 : (int)reader["quantity"];
                bookObj.bookId = (int)reader["bookId"];
                bookObj.publishedBy = (string)reader["publishedBy"];
                bookObj.bookType = (BookType)Enum.Parse(typeof(BookType), (string)reader["BookType"]);
            }
            connection.Close();
            return bookObj;
        }

        public bool AddBook(Book book)
        {
            connection.Open();

            SqlCommand Command = new SqlCommand("Insert into Books(name,PublishedBy,Quantity,AddedDate,Price,booktype)Values(\'" + book.name + "\'," +
                "\'" + book.publishedBy +"\',"+ book.quantity  + ",getdate()," + book.price + ",\'" + book.bookType + "\')");
            Command.Connection = connection;
            int success = Command.ExecuteNonQuery();
            connection.Close();
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
            connection.Open();
            SqlCommand Command = new SqlCommand("update Books set Quantity= " + quantity + "  where Bookid= " + bookID + "");
            Command.Connection = connection;
            int success = Command.ExecuteNonQuery();
            connection.Close();
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
            connection.Open();
            SqlCommand Command = new SqlCommand("delete from Books where Bookid=" + bookid + "");
            Command.Connection = connection;
            int success = Command.ExecuteNonQuery();
            connection.Close();
            if (success > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<Book> GetAllBooks()
        {
            connection.Open();
            SqlCommand command = new SqlCommand("select bookid,name,booktype,quantity,publishedby from Books");
            command.Connection = connection;
            SqlDataReader reader = command.ExecuteReader();

            List<Book> bookList = new List<Book>();
            Book bookObj;
            while (reader.Read())
            {
                bookObj = new Book();
                bookObj.name = (string)reader["name"];
                bookObj.quantity = reader.IsDBNull(4) ? 0 : (int)reader["quantity"];
                bookObj.bookId = (int)reader["bookId"];
                bookObj.publishedBy = (string)reader["publishedBy"];
                bookObj.bookType = (BookType)Enum.Parse(typeof(BookType), (string)reader["BookType"]);
                bookList.Add(bookObj);
            }
            connection.Close();
            return bookList;
        }
        public Book GetBook()
        {
            connection.Open();
            bookObj = new Book();
            
            SqlCommand command = new SqlCommand("select top 1 * from Books order by AddedDate ");
            command.Connection = connection;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                bookObj.bookId = (int)reader["bookId"];
                bookObj.quantity = (int)reader["quantity"];

            }
            connection.Close();
            return bookObj;
        }
        }
}