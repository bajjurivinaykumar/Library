using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BusinessObjects
{
    class Transaction
    {
        public int transactionId { get; set; }
        public int userId { get; set; }
        public int bookId { get; set; }
        public DateTime issueDate { get; set; }
        public DateTime dueDate { get; set; }

    }
}
