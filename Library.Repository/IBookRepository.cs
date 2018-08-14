using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.BusinessObjects;

namespace Library.Repository
{
    public interface IBookRepository
    {
        Book SearchByPublishedBy(String PublishedBy);
        bool AddBook(Book book);
        bool EditQuantity(int bookID, int Quantity);
        bool DeleteBook(int bookid);
        Book SearchBookByName(string name);


    }
}
