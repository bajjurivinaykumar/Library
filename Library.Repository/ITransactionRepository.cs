using Library.BusinessObjects;

namespace Library.Repository
{
    public interface ITransactionRepository
    {
        bool IssueBook(int userId, Book book);

        bool ReturnBook(int userid, Book book);

        bool RenewBook(int userID, Book book);
    }
}