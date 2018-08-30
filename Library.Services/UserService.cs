using Library.BusinessObjects;
using Library.core;
using Library.Repository;

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
            if (_authorizationService.Authorize(loggedInUser.roleName, "AddUser"))
                return _userRepository.AddUser(newUser);
            else
                return false;
        }

        public bool RemoveUser(int userId)
        {
            if (_authorizationService.Authorize(loggedInUser.roleName, "RemoveUser"))
                return _userRepository.RemoveUser(userId);
            else
                return false;
        }

        public User GetUserById(int userId)
        {
            if (_authorizationService.Authorize(loggedInUser.roleName, "GetuserById"))
                return _userRepository.GetUserById(userId);
            else
                return null;
        }

        public User GetUserByName(string name)
        {
            if (_authorizationService.Authorize(loggedInUser.roleName, "GetUserByName"))
                return _userRepository.GetUserByName(name);
            else
                return null;
        }
    }
}