using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services
{
    public interface IAuthorizationService
    {
        bool Authorize(string userType, string permission);
        void ReadXML();
    }
}
