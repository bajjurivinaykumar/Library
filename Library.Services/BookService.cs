using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.BusinessObjects;
using Library.Repository;



namespace Library.Services
{
    public class BookService : IBookService
    {
        BookRepository Br = new BookRepository();
        public bool AddBook(Book book)
        {
            return Br.AddBook(book);
        }
        public Book ManageBooks() {
            return new Book();
        }
        public Book SearchBookByName(String Name)
        {
         return Br.SearchBookbyName(Name);
        }

        public Book SearchBookByPublishedBy(String PublishedBy)
        {
            return Br.SearchByPublishedBy(PublishedBy);
        }

        public bool EditQuantity(int bookID, int Quantity)
        {
            return Br.EditQuantity(bookID, Quantity);
        }


        public bool DeleteBook(int bookID)
        {
            return Br.DeletBook(bookID);
        }
    }
}
