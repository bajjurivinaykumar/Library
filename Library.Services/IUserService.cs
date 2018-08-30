using Library.BusinessObjects;
using System.Collections.Generic;

namespace Library.Services
{
    public interface IUserService
    {
        bool AddUser(User user);

        bool RemoveUser(int userId);

        User GetUserById(int userId);

        User GetUserByName(string name);

        List<string> GetIssuedBookName(int userid);


    
    }
}