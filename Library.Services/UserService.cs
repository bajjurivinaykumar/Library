using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Repository;
using Library.BusinessObjects;
using Library.core;



namespace Library.Services
{
   public  class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
      // UserRepository urep = new UserRepository();
        AuthorizationService as1= new AuthorizationService();
        User loggedInUser = System.Threading.Thread.CurrentPrincipal.GetLoggedInUser();
        
        public bool  AddUser(User newUser) {

            if (as1.Authorize(loggedInUser.roleName, "AddUser"))
                return _userRepository.AddUser(newUser);
            else
            return false;
                   
            
        }


       public bool RemoveUser(int userId) {
           return _userRepository.RemoveUser(userId);
       }
       
       public User GetUser(int userId)
       {
           
           return _userRepository.GetUser(userId);
       }
      
      
    }
}
