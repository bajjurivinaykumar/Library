using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BusinessObjects
{
    public class Book
    {
        public long bookId { get; set; }
        public string Name { get; set; }
        public string author { get; set; }
        public string publisher { get; set; }
        public int price { get; set; }
        public DateTime dateOfPurchase { get; set; }
        public int Quantity { get; set; }

    }
}
