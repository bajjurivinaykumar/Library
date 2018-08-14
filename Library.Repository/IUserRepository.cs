﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.BusinessObjects;

namespace Library.Repository
{
    public interface IUserRepository
    {
        User GetUser(int userId);
        bool RemoveUser(int userId);
        bool AddUser(User user);

    }
}
