using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.BusinessObjects;
using Library.Repository;

namespace Library.Services
{
    public class TransactionService : ITransactionService
    {
        private ITransactionService _transactionService;
        public TransactionService (ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }
        private TransactionRepository trep = new TransactionRepository();

        public bool IssueBook(User user, Book book)
        {
            if (book.Quantity > 0)
                return trep.IssueBook(user, book);
            else return false;
        }

        public bool ReturnBook(int userid, Book book)
                    {

            return trep.ReturnBook( userid, book);
        }

        public bool RenewBook(int userId, Book book)

        {
            return trep.RenewBook(userId,book);
        }

        public void DeleteTransaction()
        {
        }

        public void DisplayTransaction()
        {
        }

        public void CalculateFine()
        {
        }

        public void PayBill()
        {
        }
    }
}