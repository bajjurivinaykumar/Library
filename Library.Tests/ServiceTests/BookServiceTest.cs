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
            Book book = new Book()
            {
                name = "Harry",
                bookType = BookType.ScienceFiction,
                quantity = 100,
                dateOfPurchase = DateTime.Now,
                price = 100,
                publishedBy = "J.K.Rowling",
                publisher = "Test"
            };
            unityContainer = new UnityContainer();
            unityContainer.RegisterType<IBookService, BookService>();

            Mock<IBookRepository> mockBookRepository = new Mock<IBookRepository>();   
            unityContainer.RegisterInstance<IBookRepository>(mockBookRepository.Object);

            Mock<IAuthorizationService> mockAuthorizationService = new Mock<IAuthorizationService>();
            unityContainer.RegisterInstance<IAuthorizationService>(mockAuthorizationService.Object);
            bookService = unityContainer.Resolve<BookService>();

            mockAuthorizationService.Setup(a => a.Authorize(UserType.Librarian, It.IsAny<string>())).Returns(true);
            
            mockBookRepository.Setup(b => b.SearchBookByName("Harry")).Returns(book);

            mockBookRepository.Setup(b => b.AddBook(It.IsAny<Book>())).Returns(true);
            
            mockBookRepository.Setup(b => b.SearchByPublishedBy("J.K.Rowling")).Returns(book);

            mockBookRepository.Setup(b => b.DeleteBook(100)).Returns(true);

            mockBookRepository.Setup(b => b.GetAllBooks()).Returns(new List<Book>() {
                book });

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

            var name = bookService.SearchBookByName("Harry");
            deleteBookId = name.bookId;
            Assert.AreEqual("Harry", name.name);

        }

        [TestMethod]
        public void SearchBookByPublishedBy()
        {
            var book = bookService.SearchBookByPublishedBy("J.K.Rowling");
            Assert.AreEqual("J.K.Rowling", book.publishedBy);
        }

        [TestMethod]
        public void InvalidBookSearchedByName()
        {
            var book = bookService.SearchBookByName("DaretoLive");
            Assert.IsTrue(book == null);
        }

        [TestMethod]
        public void invalidBookByPublishedBy()
        {
            var book = bookService.SearchBookByPublishedBy("Vicky");
            Assert.IsTrue(book == null);
        }

        [TestMethod]
        public void DeleteBook()
        {
            Assert.IsTrue(bookService.DeleteBook(100));
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

    }


}
