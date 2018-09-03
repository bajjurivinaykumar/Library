using Library.BusinessObjects;
using Library.BusinessObjects.enums;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using System;

namespace Library.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private static Authentication permissionList;

        public bool Authorize(UserType userType, string permission)
        {
            if (permissionList == null)
            {
                ReadXML();
            }

          var isPermitted= permissionList.Role.Where(r => r.name == userType.ToString()).SingleOrDefault().Permission.Contains(permission);
            if (!isPermitted)
                throw new UnauthorizedAccessException(userType +" is not authorized to access this functionality"); 
            return isPermitted;
        }
        

        private void ReadXML()
        {
            XmlSerializer ser = new XmlSerializer(typeof(Authentication));
            StreamReader reader = new StreamReader("Permissions.xml");
            permissionList = (Authentication)ser.Deserialize(reader);
        }
    
    }
}