using Library.BusinessObjects;

namespace Library.Services
{
    public interface ITransactionService
    {
        bool IssueBook(int UserID, Book b);

        bool ReturnBook(int userid, Book book);

        bool RenewBook(int UserId, Book book);
    }
}