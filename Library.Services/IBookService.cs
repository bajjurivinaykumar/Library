using Library.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Library.Services
{
    interface IBookService
    {
         bool AddBook(Book book);
         Book ManageBooks();
         Book SearchBookByPublishedBy(String PublishedBy);
         Book SearchBookByName(String Name);

    }
}
