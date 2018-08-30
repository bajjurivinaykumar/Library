using Library.BusinessObjects;
using Library.BusinessObjects.enums;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Library.Repository
{
    public class UserRepository : IUserRepository
    {
        private SqlConnection connection = new SqlConnection("Data Source=PremierDBDev1;Initial Catalog=Library;Pooling=true;Min Pool Size = 1;Max Pool Size=100;Integrated Security=False;Persist Security Info=False;user id=sa;password=$elf!h0st;Connect Timeout=300");

        private User userObj;

        public User GetUserById(int userId)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("select * from users where userid = " + userId);
            command.Connection = connection;
            SqlDataReader reader = command.ExecuteReader();
            userObj = new User();
            while (reader.Read())
            {
                userObj.userId = (int)reader["userId"];
                userObj.name = (string)reader["name"];
                userObj.address = (string)reader["address"];
                userObj.username = (string)reader["username"];
                userObj.roleName = (UserType)Enum.Parse(typeof(UserType), (string)reader["roleName"]);
                userObj.issuedNumberBooks = (int)reader["issuedNumberBooks"];
            }
            connection.Close();
            return userObj;
        }

        public User GetUserByName(string name)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("select * from users where name = \'" + name + "\'");
            command.Connection = connection;
            SqlDataReader reader = command.ExecuteReader();
            userObj = new User();
            while (reader.Read())
            {
                userObj.userId = (int)reader["userId"];
                userObj.name = (string)reader["name"];
                userObj.address = (string)reader["address"];
                userObj.username = (string)reader["username"];
                userObj.roleName = (UserType)Enum.Parse(typeof(UserType), (string)reader["roleName"]);
                userObj.issuedNumberBooks = (int)reader["issuedNumberBooks"];
            }
            connection.Close();
            return userObj;
        }

        public bool RemoveUser(int userId)
        {
            int success;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("delete from users where userId = " + userId);
                command.Connection = connection;
                success = command.ExecuteNonQuery();
                connection.Close();
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

        public bool AddUser(User user)
        {
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("insert into users (name,roleName,address,username,password,createdon,IssuedNumberBooks) values " +
                    "(\'" + user.name + "\',\'" + user.roleName + "\',\'" + user.address + "\',\'" + user.username + "\',\'" + user.password + "\',getdate(),0);");
                command.Connection = connection;
                int success = command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
                return false;
            }

            return true;

      
        }
        public List<string> GetIssuedBookName(int userID)
        {
            connection.Open();
            SqlCommand Command = new SqlCommand("Select b.bookName from [Transaction] t, Book b where t.Status=0 and t.Bookid=b.BookID and t.UserId=  "+userID);
            Command.Connection = connection;
           SqlDataReader reader= Command.ExecuteReader();
            List<string> list = null;
            while (reader.Read())
            {
               
               string  bookname = (string)reader["bookName"];

                list.Add(bookname);

            }
            return list;
            






        }
    }
}