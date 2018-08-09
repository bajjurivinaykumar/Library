using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
using Library.BusinessObjects;
using Oracle.DataAccess.Client;


namespace Library.Repository
{
    public class UserRepository
    {
        SqlConnection conn = new SqlConnection("Data Source=PremierDBDev1;Initial Catalog=Library;Pooling=true;Min Pool Size = 1;Max Pool Size=100;Integrated Security=False;Persist Security Info=False;user id=sa;password=$elf!h0st;Connect Timeout=300");
        /* Connection con = new Connection();
        OracleConnection Oracleconn = new OracleConnection("Data Source=(DESCRIPTION="
             + "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=nydb37.campsys.com)(PORT=1521)))"
             + "(CONNECT_DATA=(SERVER=DEDICATED)(SID=teamgqa)));"
             + "User Id=appuser;Password=hillary;");
        */
        User userObj = new User();
        public User GetUser(int userId)
        {
            //con.connect();
            
            conn.Open();
            SqlCommand command = new SqlCommand("select * from users where userid = " + userId);
            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                userObj.name =(string) reader["Name"];

            }
            conn.Close();
            return userObj;

                      
        }
        public bool AddUser(User user)
        {
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand("insert into users (name,roleId,address,username,password,createdon,IssuedNumberBooks) values " +
                    "(\'" + user.name + "\'," + user.roleId + ",\'" + user.address + "\',\'" + user.username + "\',\'" + user.Password + "\',getdate(),0);");
                command.Connection = conn;
                int success = command.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
