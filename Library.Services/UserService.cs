using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Repository;
using Library.BusinessObjects;
using Library.CORE;


namespace Library.Services
{
   public  class UserService : IUserService
    {
       UserRepository urep = new UserRepository();
        int userId = System.Threading.Thread.CurrentPrincipal.GetLoggedInUser().userId;

        public bool  AddUser(User newUser) {


           return urep.AddUser(newUser);
                   
        }


       public bool RemoveUser(int userId) {
           return urep.RemoveUser(userId);
       }
       
       public User GetUser(int userId)
       {
           
           return urep.GetUser(userId);
       }
      
      
    }
}
