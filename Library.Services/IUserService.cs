using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.BusinessObjects;

namespace Library.Services
{
    interface IUserService
    {
        bool AddUser(User user);
        int RemoveUser(int userId);
        User GetUser(int userId);

    }
}
