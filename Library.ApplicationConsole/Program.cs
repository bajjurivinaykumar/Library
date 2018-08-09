using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.BusinessObjects;
using Library.Services;

namespace Library.ApplicationConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            UserService us = new UserService();
            User u = new User();
            u.address = "Kondapur";
            
            u.name = "vinay";
            u.Password = "test";
            u.roleId = 1;
            u.username = "vinay";
            u.userId = 5;
           us.AddUser(u);

        }
    }
}
