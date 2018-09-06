using Library.BusinessObjects;
using System.Collections.Generic;

namespace Library.Repository
{
    public interface IBookRepository
    {
        Book SearchByPublishedBy(string publishedBy);

        bool AddBook(Book book);

        bool EditQuantity(int bookID, int quantity);

        bool DeleteBook(int bookId);

        Book SearchBookByName(string name);
        List<Book> GetAllBooks();

        Book GetBook();

    }
}