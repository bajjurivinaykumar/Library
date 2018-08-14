using Library.BusinessObjects;
using Library.Repository;

namespace Library.Services
{
    public class TransactionService : ITransactionService
    {
        public TransactionRepository trep = new TransactionRepository();

        public bool IssueBook(User u, Book b)
        {
            if (b.Quantity > 0)
                return trep.IssueBook(u, b);
            else return false;
        }

        public void ReturnBook()
        {
        }

        public void RenewBook()
        {
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