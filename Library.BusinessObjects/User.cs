using System;

namespace Library.BusinessObjects
{
    public class User
    {
        public int userId { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int roleId { get; set; }
        public int issuedNumberBooks { get; set; }
        public DateTime createdOn { get; set; }
        public string roleName { get; set; }
    }
}