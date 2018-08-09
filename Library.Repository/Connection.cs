using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using Oracle.DataAccess.Client;


namespace Library.Repository
{
    class Connection
    {
       //SqlConnection conn =new SqlConnection("Data Source=PremierDBDev1\\Premier;Initial Catalog=Library;Pooling=true;Min Pool Size = 1;Max Pool Size=100;Integrated Security=False;Persist Security Info=False;user id=sa;password=$elf!h0st;Connect Timeout=300");
        OracleConnection Oracleconn = new OracleConnection("Data Source=(DESCRIPTION="
             + "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=IDCORA)(PORT=1521)))"
             + "(CONNECT_DATA=(SERVER=DEDICATED)(SID=DemoDb)));"
             + "User Id=system;Password=$elf!h0st;");


     public void connect()
     {
         Oracleconn.Open();
         Console.Write    ("Hi");

     }
    }
}
