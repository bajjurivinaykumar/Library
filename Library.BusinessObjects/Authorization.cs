using System;
using System.Xml;
using System.Xml.Serialization;

namespace Library.BusinessObjects
{
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