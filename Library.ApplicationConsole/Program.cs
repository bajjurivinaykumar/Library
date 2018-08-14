using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.BusinessObjects;
using Library.Services;
using Library.Repository;

using Unity;

namespace Library.ApplicationConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            UnityContainer unityContainer = new UnityContainer();
            unityContainer.RegisterType<IUserService, UserService>();
            unityContainer.RegisterType<IUserRepository, UserRepository>();


            UnityContainer unityContainer1 = new UnityContainer();
            unityContainer1.RegisterType<IBookService, BookService>();
          //  unityContainer1.RegisterType<IBookRepository, BookRepository>();


            


            IUserService userService = unityContainer.Resolve<UserService>();

           User u= userService.GetUser(10);      





            /*

           // UserService us = new UserService();
            BookService bs = new BookService();
            TransactionService ts = new TransactionService();
            User u = us.GetUser(8);
            Book b = bs.SearchBookByName("Harrypotter");
            b.BookType = BusinessObjects.enums.BookType.ActionandAdventures;
            ts.IssueBook(u, b);
           
    */
        }
        
    }
}
