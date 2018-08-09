using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Library.BusinessObjects;
using System.IO;


namespace Library.Services
{
    class AuthorizationService
    {
        public bool Authorize(string userType,string permission)
        {
            XmlSerializer ser = new XmlSerializer(typeof(Authentication));

            StreamReader reader = new StreamReader("Permissions.xml");
            var data = (Authentication)ser.Deserialize(reader);
             return data.Role.Where(r => r.name == userType).SingleOrDefault().Permission.Contains(permission);

        }

    }
}

