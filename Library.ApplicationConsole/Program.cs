using Library.BusinessObjects;
using Library.BusinessObjects.enums;
using Library.Repository;
using Library.Services;
using Unity;

namespace Library.ApplicationConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            /*UnityContainer unityContainer = new UnityContainer();
            unityContainer.RegisterType<IUserService, UserService>();
            unityContainer.RegisterType<IUserRepository, UserRepository>();

            unityContainer.RegisterType<IBookService, BookService>();
            unityContainer.RegisterType<IBookRepository, BookRepository>();

            unityContainer.RegisterType<ITransactionService, TransactionService>();
            unityContainer.RegisterType<ITransactionRepository, TransactionRepository>();

            //unityContainer.RegisterType<IAuthorizationService, AuthorizationService>();

            IUserService userService = unityContainer.Resolve<UserService>();
            IBookService bookService = unityContainer.Resolve<BookService>();
            //ITransactionService transactionService = unityContainer.Resolve<TransactionService>();

            User u = userService.GetUserById(16);
            User newUser = new User();
            newUser.address = "chandanagar";
            newUser.name = "test";
            newUser.password = "test";
            newUser.roleName = UserType.Librarian;
            newUser.username = "vinay";
            bool result = userService.AddUser(newUser);

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