using Library.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Library.Services
{
    public interface IBookService
    {
         bool AddBook(Book book);
         Book ManageBooks();
         Book SearchBookByPublishedBy(string PublishedBy);
         Book SearchBookByName(string Name);

         bool EditQuantity(int  BookID, int Quantity);

         bool DeleteBook(int BookID);

    }
}
