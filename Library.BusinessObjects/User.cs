using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BusinessObjects
{
    public class User
    {
        public int userId { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string username { get; set; }
        public string Password   { get; set; }
        public int roleId { get; set; }
        public int IssuedNumberBooks { get; set; }
        public DateTime createdOn { get; set; }

    }
}
