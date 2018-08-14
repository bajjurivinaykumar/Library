using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.BusinessObjects;
using Library.Services;

namespace Library.ApplicationConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            UserService us = new UserService();
            BookService bs = new BookService();
            TransactionService ts = new TransactionService();
            User u = us.GetUser(8);
            Book b = bs.SearchBookByName("Harrypotter");
            b.bookType = BusinessObjects.enums.BookType.ActionandAdventures;
            ts.IssueBook(u, b);
           

        }
        
    }
}
