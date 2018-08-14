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


            //BookService Bs = new BookService();

            //var data = Bs.EditQuantity(2, 10);

            BookService Bs = new BookService();
            UserService us = new UserService();
            TransactionService ts = new TransactionService();
            User user = us.GetUser(10);
            Book book = Bs.SearchBookByName(" Harry");
           ts.IssueBook(user, book);
            ts.ReturnBook(9, book);
            



        }
        
    }
}
