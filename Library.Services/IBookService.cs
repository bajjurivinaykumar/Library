using Library.BusinessObjects;
using System.Collections.Generic;

namespace Library.Services
{
    public interface IBookService
    {
        bool AddBook(Book book);

        Book SearchBookByPublishedBy(string PublishedBy);

        Book SearchBookByName(string Name);

        bool EditQuantity(int BookID, int Quantity);

        bool DeleteBook(int BookID);

        List<Book> GetAllBooks();
    }
}