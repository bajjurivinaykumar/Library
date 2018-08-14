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
        
        private IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)

        {
            _bookRepository = bookRepository;
        }
        
        //BookRepository bookRepository = new BookRepository();
        public bool AddBook(Book book)
        {
            return _bookRepository.AddBook(book);
        }
        public Book ManageBooks() {
            return new Book();
        }
        public Book SearchBookByName(string name)
        {
         return _bookRepository.SearchBookByName(name);
        }

        public Book SearchBookByPublishedBy(String PublishedBy)
        {
            return _bookRepository.SearchByPublishedBy(PublishedBy);
        }

        public bool EditQuantity(int bookID, int Quantity)
        {
            return _bookRepository.EditQuantity(bookID, Quantity);
        }


        public bool DeleteBook(int bookID)
        {
            return _bookRepository.DeleteBook(bookID);
        }
    }
}
