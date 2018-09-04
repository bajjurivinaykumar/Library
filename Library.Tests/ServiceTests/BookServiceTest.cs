using Library.Repository;
using Library.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Library.BusinessObjects;
using Library.BusinessObjects.enums;
using Moq;

namespace Library.Tests.ServiceTests
{

    [TestClass]
    public class BookServiceTest
    {
        IBookService bookService;
        int deleteBookId = 0;
        private UnityContainer unityContainer;
        [TestInitialize]
        public void Initialize()
        {
            unityContainer = new UnityContainer();
            unityContainer.RegisterType<IBookService, BookService>();

            Mock<IBookRepository> mockBookRepository = new Mock<IBookRepository>();
            mockBookRepository.Setup(b => b.SearchBookByName(It.IsAny<string>())).Returns(new Book()
            {
                name = "Maru"
            });
            unityContainer.RegisterInstance<IBookRepository>(mockBookRepository.Object);

            mockBookRepository.Setup(b => b.AddBook(new Book()
            {
                name = "Harry",
                bookType = BookType.ScienceFiction,
                quantity = 100,
                dateOfPurchase = DateTime.Now,
                price=100,
                publishedBy ="J.K.Rowling",
                publisher ="Test"

            }));

            mockBookRepository.Setup(b => b.SearchByPublishedBy(It.IsAny<string>())).Returns(new Book()
            {
                name = "Harry",
                bookType = BookType.ScienceFiction,
                quantity = 100,
                dateOfPurchase = DateTime.Now,
                price = 100,
                publishedBy = "J.K.Rowling",
                publisher = "Test"
            });

            Mock<IAuthorizationService> mockAuthorizationService = new Mock<IAuthorizationService>();
            mockAuthorizationService.Setup(a => a.Authorize(UserType.Librarian, It.IsAny<string>())).Returns(true);
            unityContainer.RegisterInstance<IAuthorizationService>(mockAuthorizationService.Object);

            
            bookService = unityContainer.Resolve<BookService>();
        }

        [TestMethod]
        public void AddBook()
        {

            Book addbook = new Book();
            addbook.name = "Ca111";
            addbook.quantity = 25;
            addbook.price = 850;
            addbook.publishedBy = "Maru11";
            addbook.publisher = "Dheeraj";
            addbook.bookType = BookType.Academics;
            Assert.IsTrue(bookService.AddBook(addbook));


        }

        [TestMethod]
        public void SearchBookbyName()
        {

            var name = bookService.SearchBookByName("Ca111");
            deleteBookId = name.bookId;
            Assert.AreEqual("Ca11", name.name);

        }

        [TestMethod]
        public void SearchBookByPublishedBy()
        {
            var book = bookService.SearchBookByPublishedBy("Maru");
            Assert.AreEqual("Maru", book.publishedBy);
        }

        [TestMethod]
        public void InvalidBookSearchedByName()
        {
            var book = bookService.SearchBookByName("DaretoLive");
            Assert.IsTrue(book.name == null);
        }

        [TestMethod]
        public void invalidBookByPublishedBy()
        {
            var book = bookService.SearchBookByPublishedBy("Vicky");
            Assert.IsTrue(book.publishedBy == null);
        }

        [TestMethod]
        public void DeleteBook()
        {
            Assert.IsTrue(bookService.DeleteBook(deleteBookId));
        }


        [TestMethod]
        public void DeleteInvalidBook()
        {
            Assert.IsFalse(bookService.DeleteBook(69));
        }


        [TestMethod]
        public void EditInvalidBook()
        {
            var NewQuantity = bookService.EditQuantity(69, 25);
            Assert.IsFalse(NewQuantity);
        }
        [TestCleanup]
        public void CleanUp()
        {
            bookService = null;
            unityContainer = null;
        }

        [TestMethod]
        public void GetAllBooks()
        {
            var data = bookService.GetAllBooks();
            Assert.IsTrue(data.Count > 0);
        }


        [TestMethod]
        public void BookServiceTest1()
        {
            //AddBook();
            GetAllBooks();
            SearchBookbyName();
            SearchBookByPublishedBy();
            InvalidBookSearchedByName();
            invalidBookByPublishedBy();
            EditInvalidBook();
            DeleteInvalidBook();
            DeleteBook();
        }
    }


}
