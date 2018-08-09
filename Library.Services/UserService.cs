using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Repository;
using Library.BusinessObjects;


namespace Library.Services
{
   public  class UserService : IUserService
    {
       UserRepository urep = new UserRepository();
       
       public bool  AddUser(User user) {

           return urep.AddUser(user);
                   
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
