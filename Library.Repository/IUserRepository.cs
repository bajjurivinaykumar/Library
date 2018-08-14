using Library.BusinessObjects;

namespace Library.Repository
{
    public interface IUserRepository
    {
        User GetUserById(int userId);

        User GetUserByName(string name);

        bool RemoveUser(int userId);

        bool AddUser(User user);

        void GetRole(int userId);
    }
}