using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Library.BusinessObjects;

namespace Library.CORE
{
    public static class PrincipalExtension
    {
        public static User GetLoggedInUser(this IPrincipal principal)
        {
            return new User()
            {
                name = "VINAY",
                userId = 8
            };
        }
    }
}
