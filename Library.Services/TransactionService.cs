using Library.BusinessObjects;
using Library.core;
using Library.Repository;

namespace Library.Services
{
    public class TransactionService : ITransactionService
    {
        private IAuthorizationService _authorizationService;
        private User loggedInUser = System.Threading.Thread.CurrentPrincipal.GetLoggedInUser();
        private ITransactionRepository _transactionRepository;
        private IBookRepository _bookRepository;

        public TransactionService(ITransactionRepository transactionRepository, IAuthorizationService authorizationService, IBookRepository bookRepository)
        {
            _transactionRepository = transactionRepository;
            _authorizationService = authorizationService;
            _bookRepository = bookRepository;

        }

        
        public bool IssueBook(int userId, Book book)
        {
            _authorizationService.Authorize(loggedInUser.roleName, "IssueBook");
            if (book.quantity > 0 && _transactionRepository.IssueBook(userId, book)==true)
            {

                _bookRepository.EditQuantity(book.bookId, book.quantity - 1);
                return true;
            }
            return false;
        }

        public bool ReturnBook(int userid, Book book)
        {
          _authorizationService.Authorize(loggedInUser.roleName, "ReturnBook");
            if (_transactionRepository.ReturnBook(userid, book) == true)
            {
                _bookRepository.EditQuantity(book.bookId, book.quantity + 1);
                return true;
                
            }
            return false;
            
        }

        public bool RenewBook(int userId, Book book)

        {
            _authorizationService.Authorize(loggedInUser.roleName, "RenewBook");
                return _transactionRepository.RenewBook(userId, book);
            
        }
    }
}