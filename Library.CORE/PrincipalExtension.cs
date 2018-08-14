using Library.BusinessObjects;
using System.Security.Principal;

namespace Library.core
{
    public static class PrincipalExtension
    {
        public static User GetLoggedInUser(this IPrincipal principal)
        {
            return new User()
            {
                name = "VINAY",
                userId = 8,
                roleName = "librarian"
            };
        }
    }
}