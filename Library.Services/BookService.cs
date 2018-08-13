using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.BusinessObjects;
using Library.Repository;


namespace Library.Services
{
    public class BookService : IBookService
    {
        BookRepository brep = new BookRepository();
        public Book AddBook()
        {
            return new Book();
        }
        public Book ManageBooks() {
            return new Book();
        }
        public Book SearchBook(string name) {
            return brep.SearchBook(name);
        }


    }
}
