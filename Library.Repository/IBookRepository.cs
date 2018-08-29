using Library.BusinessObjects;

namespace Library.Repository
{
    public interface IBookRepository
    {
        Book SearchByPublishedBy(string publishedBy);

        bool AddBook(Book book);

        bool EditQuantity(int bookID, int quantity);

        bool DeleteBook(int bookId);

        Book SearchBookByName(string name);
    }
}