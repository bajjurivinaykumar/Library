using Library.BusinessObjects;
using Library.core;
using Library.Repository;

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

        public void GetRole(int userId)
        {
            _userRepository.GetRole(userId);
        }

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
            if (as1.Authorize(loggedInUser.roleName, "GetUser"))
                return _userRepository.GetUserById(userId);
            else
                return null;
        }

        public User GetUserByName(string name)
        {
            if (as1.Authorize(loggedInUser.roleName, "GetUser"))
                return _userRepository.GetUserByName(name);
            else
                return null;
        }
    }
}