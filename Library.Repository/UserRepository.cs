using Library.BusinessObjects;
using System;
using System.Data.SqlClient;
using Library.BusinessObjects.enums;
namespace Library.Repository
{
    public class UserRepository : IUserRepository
    {
        private SqlConnection conn = new SqlConnection("Data Source=PremierDBDev1;Initial Catalog=Library;Pooling=true;Min Pool Size = 1;Max Pool Size=100;Integrated Security=False;Persist Security Info=False;user id=sa;password=$elf!h0st;Connect Timeout=300");

        private User userObj = new User();

        public User GetUserById(int userId)
        {
            conn.Open();
            SqlCommand command = new SqlCommand("select * from users where userid = " + userId);
            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                userObj.userId = (int)reader["userId"];
                userObj.name = (string)reader["name"];
                userObj.address = (string)reader["address"];
                userObj.username = (string)reader["username"];
                userObj.roleName = (UserType)Enum.Parse(typeof(UserType), (string)reader["roleName"]);
                userObj.issuedNumberBooks = (int)reader["issuedNumberBooks"];
            }
            conn.Close();
            return userObj;
        }

    

        public User GetUserByName(string name)
        {
            conn.Open();
            SqlCommand command = new SqlCommand("select * from users where username = " + name);
            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                userObj.userId = (int)reader["userId"];
                userObj.name = (string)reader["name"];
                userObj.address = (string)reader["address"];
                userObj.username = (string)reader["username"];
                userObj.roleName = (UserType)Enum.Parse(typeof(UserType), (string)reader["roleName"]);
                userObj.issuedNumberBooks = (int)reader["issuedNumberBooks"];
            }
            conn.Close();
            return userObj;
        }

        public bool RemoveUser(int userId)
        {
            int success;
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand("delete from users where userId = " + userId);
                command.Connection = conn;
                success = command.ExecuteNonQuery();
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

        public bool AddUser(User user)
        {
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand("insert into users (name,roleName,address,username,password,createdon,IssuedNumberBooks) values " +
                    "(\'" + user.name + "\',\'" + user.roleName + "\',\'" + user.address + "\',\'" + user.username + "\',\'" + user.password + "\',getdate(),0);");
                command.Connection = conn;
                int success = command.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}