using Library.BusinessObjects.enums;
using System;

namespace Library.BusinessObjects
{
    public class Book
    {
        public int bookId { get; set; }
        public string name { get; set; }
        public string publishedBy { get; set; }
        public string publisher { get; set; }
        public int price { get; set; }
        public DateTime dateOfPurchase { get; set; }
        public int quantity { get; set; }
        public BookType bookType { get; set; }
    }
}