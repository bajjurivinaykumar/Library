using Library.BusinessObjects;
using Library.core;
using Library.Repository;

namespace Library.Services
{
    public class TransactionService : ITransactionService
    {
        private AuthorizationService authorizationService = new AuthorizationService();
        private User loggedInUser = System.Threading.Thread.CurrentPrincipal.GetLoggedInUser();
        private ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        // private TransactionRepository trep = new TransactionRepository();

        public bool IssueBook(User user, Book book)
        {
            if (book.quantity > 0 && authorizationService.Authorize(loggedInUser.roleName, "IssueBook"))
            {
                return _transactionRepository.IssueBook(user, book);
            }
            else return false;
        }

        public bool ReturnBook(int userid, Book book)
        {
            if (authorizationService.Authorize(loggedInUser.roleName, "ReturnBook"))
                return _transactionRepository.ReturnBook(userid, book);
            else
                return false;
        }

        public bool RenewBook(int userId, Book book)

        {
            if (authorizationService.Authorize(loggedInUser.roleName, "RenewBook"))
                return _transactionRepository.RenewBook(userId, book);
            else
                return false;
        }
    }
}