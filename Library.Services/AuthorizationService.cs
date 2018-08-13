using Library.BusinessObjects;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Library.Services
{
    internal class AuthorizationService
    {
        private static Authentication permissionList;

        public bool Authorize(string userType, string permission)
        {
            if (permissionList == null)
            {
                ReadXML();
            }
            return permissionList.Role.Where(r => r.name == userType).SingleOrDefault().Permission.Contains(permission);
        }

        private void ReadXML()
        {
            XmlSerializer ser = new XmlSerializer(typeof(Authentication));
            StreamReader reader = new StreamReader("Permissions.xml");
            permissionList = (Authentication)ser.Deserialize(reader);
        }
    }
}