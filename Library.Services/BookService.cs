using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.BusinessObjects;


namespace Library.Services
{
    public class BookService : IBookService
    {
        public Book AddBook()
        {
            return new Book();
        }
        public Book ManageBooks() {
            return new Book();
        }
        public Book SearchBook() {
         return new Book();}


    }
}
