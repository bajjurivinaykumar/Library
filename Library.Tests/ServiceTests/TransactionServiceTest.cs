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

namespace Library.Tests.ServiceTests
{
    [TestClass]
    public class TransactionServiceTest
    {


        ITransactionService Transactionservice;
        IBookService bookService;

        [TestInitialize]
        public void Intialize()
        {
            UnityContainer Container = new UnityContainer();
            Container.RegisterType<ITransactionService, TransactionService>();
            Container.RegisterType<ITransactionRepository, TransactionRepository>();
            Container.RegisterType<IBookService, BookService>();
            Container.RegisterType<IBookRepository, BookRepository>();
            Transactionservice = Container.Resolve<TransactionService>();
            bookService = Container.Resolve<BookService>();

        }

        [TestMethod]
        public void IssueBook()
        {
            Transaction trans = new Transaction();

            var book = bookService.SearchBookByName("Ca");
            Assert.IsTrue(Transactionservice.IssueBook(63, book));

        }

        [TestMethod]
        public void InvalidIssueBook()
        {
            var book = bookService.SearchBookByName("Titanic");
            Assert.IsFalse(Transactionservice.IssueBook(1,book));

        }


        [TestMethod]
        public void ReturnBook()
        {
            var book = bookService.SearchBookByName("Ca");
            Assert.IsTrue(Transactionservice.ReturnBook(63,book));

        }


        [TestMethod]
        public void Invalidreturnbook()
        {
            var book = bookService.SearchBookByName("Titanic");
            Assert.IsFalse(Transactionservice.ReturnBook(63,book));

        }


        [TestMethod]
        public void book()
        {
          
        }


    }
}


