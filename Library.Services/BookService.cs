using Library.BusinessObjects;
using Library.core;
using Library.Repository;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private AuthorizationService authorizationService = new AuthorizationService();
        private User loggedInUser = System.Threading.Thread.CurrentPrincipal.GetLoggedInUser();
        private IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)

        {
            _bookRepository = bookRepository;
        }

        //BookRepository bookRepository = new BookRepository();
        public bool AddBook(Book book)
        {
            if (authorizationService.Authorize(loggedInUser.roleName, "AddBook"))
                return _bookRepository.AddBook(book);
            else
                return false;
        }

        public Book SearchBookByName(string name)
        {
            if (authorizationService.Authorize(loggedInUser.roleName, "SearchBookByName"))
                return _bookRepository.SearchBookByName(name);
            else
                return null;
        }

        public Book SearchBookByPublishedBy(string publishedBy)
        {
            if (authorizationService.Authorize(loggedInUser.roleName, "SearchBookByPublishedBy"))

                return _bookRepository.SearchByPublishedBy(publishedBy);
            else
                return null;
        }

        public bool EditQuantity(int bookID, int quantity)
        {
            return _bookRepository.EditQuantity(bookID, quantity);
        }

        public bool DeleteBook(int bookID)
        {
            if (authorizationService.Authorize(loggedInUser.roleName, "DeleteBook"))
                return _bookRepository.DeleteBook(bookID);
            else
                return false;
        }
    }
}