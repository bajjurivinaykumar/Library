using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.BusinessObjects;
using Library.Repository;
using Library.BusinessObjects.enums;
using Unity;


namespace Library.Tests.RepositoryTests
{
    class TransactionRepositroyTest
    {
        [TestClass]
        public class TrasactionRepositorytest
        {
            private UnityContainer unitycontainer;
            TransactionRepository _transactionRepository;
            BookRepository _bookRepository;
            UserRepository _userRepository;


        [TestInitialize]
        public void Initialize()
            {
                unitycontainer = new UnityContainer();
                unitycontainer.RegisterType<ITransactionRepository, TransactionRepository>();
                unitycontainer.RegisterType<IBookRepository, BookRepository>();
                unitycontainer.RegisterType<IUserRepository, UserRepository>();
                _transactionRepository = unitycontainer.Resolve<TransactionRepository>();
                _bookRepository = unitycontainer.Resolve<BookRepository>();
                _userRepository = unitycontainer.Resolve<UserRepository>();

            }
            [TestMethod]

            public void issueBook()
            {
                Book book = _bookRepository.GetBook();
                var userId = _userRepository.GetUserId();

                var issueBook = _transactionRepository.IssueBook(userId, book);
                var returnBook = _transactionRepository.ReturnBook(userId, book);

                Assert.IsTrue(issueBook && returnBook);
                
                
            }

            [TestMethod]
            public void returnbook()
            {
                Book book = _bookRepository.GetBook();
                var userId = _userRepository.GetUserId();
                var issueBook = _transactionRepository.IssueBook(userId, book);
                var returnBook = _transactionRepository.ReturnBook(userId, book);

                Assert.IsTrue(issueBook && returnBook);

            }

            [TestMethod]
            public void renewbook()
            {
                Book book = _bookRepository.GetBook();
                var userId = _userRepository.GetUserId();
                var issueBook = _transactionRepository.IssueBook(userId, book);
                var renewBook = _transactionRepository.RenewBook(userId, book);
                var returnBook = _transactionRepository.ReturnBook(userId, book);

                Assert.IsTrue(issueBook && returnBook && renewBook);


            }

        }

    }
}
