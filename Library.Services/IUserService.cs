using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.BusinessObjects;

namespace Library.Services
{
   public interface IUserService
    {
        bool AddUser(User user);
        bool RemoveUser(int userId);
        User GetUser(int userId);

    }
}
