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

        public TransactionService(ITransactionRepository transactionRepository, IAuthorizationService authorizationService)
        {
            _transactionRepository = transactionRepository;
            _authorizationService = authorizationService;
        }

        
        public bool IssueBook(int userId, Book book)
        {
            if (book.quantity > 0)
            {
                _authorizationService.Authorize(loggedInUser.roleName, "IssueBook");
            
                return _transactionRepository.IssueBook(userId, book);
            }
            return false;
        }

        public bool ReturnBook(int userid, Book book)
        {
          _authorizationService.Authorize(loggedInUser.roleName, "ReturnBook");
                return _transactionRepository.ReturnBook(userid, book);
            
        }

        public bool RenewBook(int userId, Book book)

        {
            _authorizationService.Authorize(loggedInUser.roleName, "RenewBook");
                return _transactionRepository.RenewBook(userId, book);
            
        }
    }
}