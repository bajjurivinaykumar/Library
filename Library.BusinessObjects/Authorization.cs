using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Library.BusinessObjects
{
    class Authorization
    {
    }

    [Serializable]
    [XmlRoot("Authentication")]
    public class Authentication
    {

        [XmlElement("Role")]
        public Role[] Role;

    }

    [Serializable]
    public class Role
    {

        [XmlElement]
        public string[] Permission;


        [XmlAttribute("name")]
        public string name;
    }

}
