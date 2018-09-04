using Library.BusinessObjects;
using Library.core;
using Library.Repository;
using System;
using System.Collections.Generic;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private IAuthorizationService _authorizationService;// = new AuthorizationService();
        private User loggedInUser = System.Threading.Thread.CurrentPrincipal.GetLoggedInUser();
        private IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository, IAuthorizationService authorizationService)

        {
            _bookRepository = bookRepository;
            _authorizationService = authorizationService;
        }

        //BookRepository bookRepository = new BookRepository();
        public bool AddBook(Book book)
        {
            _authorizationService.Authorize(loggedInUser.roleName, "AddBook");
                return _bookRepository.AddBook(book);
           
        }

        public Book SearchBookByName(string name)
        {
            _authorizationService.Authorize(loggedInUser.roleName, "SearchBookByName");
                return _bookRepository.SearchBookByName(name);
           
        }

        public Book SearchBookByPublishedBy(string publishedBy)
        {
            _authorizationService.Authorize(loggedInUser.roleName, "SearchByPublishedBy");
                return _bookRepository.SearchByPublishedBy(publishedBy);
          
        }

        public bool EditQuantity(int bookID, int quantity)
        {
            return _bookRepository.EditQuantity(bookID, quantity);
        }

        public bool DeleteBook(int bookID)
        {
            _authorizationService.Authorize(loggedInUser.roleName, "DeleteBook");
                return _bookRepository.DeleteBook(bookID);
            
        }
        public List<Book> GetAllBooks()
        {
            return _bookRepository.GetAllBooks();
        }
    }
}