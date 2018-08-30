using Library.BusinessObjects;
using System.Collections.Generic;

namespace Library.Repository
{
    public interface IUserRepository
    {
        User GetUserById(int userId);

        User GetUserByName(string name);

        bool RemoveUser(int userId);

        bool AddUser(User user);

        List<string> GetIssuedBookName(int userId);
    }
}