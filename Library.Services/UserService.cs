using Library.BusinessObjects;
using Library.core;
using Library.Repository;
using System;
using System.Collections.Generic;

namespace Library.Services
{
    public class UserService : IUserService
    {
        private IAuthorizationService _authorizationService;
        private User loggedInUser = System.Threading.Thread.CurrentPrincipal.GetLoggedInUser();
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository, IAuthorizationService authorizationService)
        {
            _userRepository = userRepository;
            _authorizationService = authorizationService;
        }

        // UserRepository urep = new UserRepository();

        public bool AddUser(User newUser)
        {
          _authorizationService.Authorize(loggedInUser.roleName, "AddUser");
                return _userRepository.AddUser(newUser);
            
        }

        public bool RemoveUser(int userId)
        {
            _authorizationService.Authorize(loggedInUser.roleName, "RemoveUser");
                return _userRepository.RemoveUser(userId);
           
        }

        public User GetUserById(int userId)
        {
            _authorizationService.Authorize(loggedInUser.roleName, "GetuserById");
                return _userRepository.GetUserById(userId);
       
        }

        public User GetUserByName(string name)
        {
            _authorizationService.Authorize(loggedInUser.roleName, "GetUserByName");
            return _userRepository.GetUserByName(name);
           
        }

        public List<string> GetIssuedBookName(int userId)
        {
            _authorizationService.Authorize(loggedInUser.roleName, "GetIssuedBookName");
                return _userRepository.GetIssuedBookName(userId);
            
        }
        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

    }
}