using System;

namespace Library.BusinessObjects
{
    internal class Transaction
    {
        public int transactionId { get; set; }
        public int userId { get; set; }
        public int bookId { get; set; }
        public DateTime issueDate { get; set; }
        public DateTime dueDate { get; set; }
    }
}