using Library.BusinessObjects;

namespace Library.Services
{
    public interface IUserService
    {
        bool AddUser(User user);

        bool RemoveUser(int userId);

        User GetUserById(int userId);

        User GetUserByName(string name);

        
    }
}