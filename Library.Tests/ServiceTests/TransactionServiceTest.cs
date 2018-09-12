using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.BusinessObjects;
using Library.Repository;
using Library.Services;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;
using Moq;

namespace Library.Tests.ServiceTests
{
    [TestClass]
    public class TransactionServiceTest
    {


        ITransactionService transactionService;
        IBookService bookService;

        [TestInitialize]
        public void Intialize()
        {
            UnityContainer unityContainer = new UnityContainer();
            unityContainer.RegisterType<ITransactionService, TransactionService>();
            unityContainer.RegisterType<ITransactionRepository, TransactionRepository>();
            unityContainer.RegisterType<IBookService, BookService>();
            unityContainer.RegisterType<IBookRepository, BookRepository>();
            unityContainer.RegisterType<IAuthorizationService, AuthorizationService>();
            transactionService = unityContainer.Resolve<TransactionService>();
            unityContainer.RegisterType<IAuthorizationService, AuthorizationService>();
            bookService = unityContainer.Resolve<BookService>();

            Mock<ITransactionRepository> mocktrasactionrepository = new Mock<ITransactionRepository>();
            unityContainer.RegisterInstance<ITransactionRepository>(mocktrasactionrepository.Object);
            Mock<ITransactionService> mocktreasactionservices = new Mock<ITransactionService>();
            unityContainer.RegisterInstance<ITransactionService>(mocktreasactionservices.Object);

            transactionService = unityContainer.Resolve<TransactionService>();

            mocktrasactionrepository.Setup(a => a.IssueBook(63, bookService.SearchBookByName("Harry"))).Returns(true);

            mocktrasactionrepository.Setup(t => t.ReturnBook(63, bookService.SearchBookByName("Harry"))).Returns(true);

            mocktrasactionrepository.Setup(t => t.RenewBook(63, bookService.SearchBookByName("Harry"))).Returns(true);
            


        }

        [TestMethod]
        public void IssueBook()
        {
            var book = bookService.SearchBookByName("Ca");
            Assert.IsTrue(transactionService.IssueBook(63, book));

        }

        [TestMethod]
        public void InvalidIssueBook()
        {
            var book = bookService.SearchBookByName("Titanic");
            Assert.IsFalse(transactionService.IssueBook(1,book));

        }


        [TestMethod]
        public void ReturnBook()
        {
            var book = bookService.SearchBookByName("Ca11");
            Assert.IsTrue(transactionService.ReturnBook(63,book));

        }


        [TestMethod]
        public void Invalidreturnbook()
        {
            var book = bookService.SearchBookByName("Titanic");
            Assert.IsFalse(transactionService.ReturnBook(63,book));

        }


        [TestMethod]
        public void book()
        {
          
        }


    }
}


