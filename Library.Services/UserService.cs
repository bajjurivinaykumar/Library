using Library.BusinessObjects;
using Library.core;
using Library.Repository;
using System.Collections.Generic;

namespace Library.Services
{
    public class UserService : IUserService
    {
        private AuthorizationService as1 = new AuthorizationService();
        private User loggedInUser = System.Threading.Thread.CurrentPrincipal.GetLoggedInUser();
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // UserRepository urep = new UserRepository();

        public bool AddUser(User newUser)
        {
            if (as1.Authorize(loggedInUser.roleName, "AddUser"))
                return _userRepository.AddUser(newUser);
            else
                return false;
        }

        public bool RemoveUser(int userId)
        {
            if (as1.Authorize(loggedInUser.roleName, "RemoveUser"))
                return _userRepository.RemoveUser(userId);
            else
                return false;
        }

        public User GetUserById(int userId)
        {
            if (as1.Authorize(loggedInUser.roleName, "GetuserById"))
                return _userRepository.GetUserById(userId);
            else
                return null;
        }

        public User GetUserByName(string name)
        {
            if (as1.Authorize(loggedInUser.roleName, "GetUserByName"))
                return _userRepository.GetUserByName(name);
            else
                return null;
        }

        public List<string> GetIssuedBookName(int userId)
        {
            if (as1.Authorize(loggedInUser.roleName, "GetIssuedBookName"))
                return _userRepository.GetIssuedBookName(userId);
            else
                return null;
        }
    }
}