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

namespace Library.Tests.ServiceTests
{

    [TestClass]
    public class BookServiceTest
    {
        IBookService bookService;
        int deleteBookId =0;
                private UnityContainer unityContainer;
        [TestInitialize]
        public void Initialize()
        {
             unityContainer = new UnityContainer();
            unityContainer.RegisterType<IBookService, BookService>();
            unityContainer.RegisterType<IBookRepository, BookRepository>();
            unityContainer.RegisterType<IAuthorizationService, AuthorizationService>();
            bookService=unityContainer.Resolve<BookService>();
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

            var name = bookService.SearchBookByName("Ca");
            deleteBookId = name.bookId;
            Assert.AreEqual("Ca", name.name);

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
            Assert.IsTrue(book.name==null);
        }

        [TestMethod]
        public void invalidBookByPublishedBy()
        {
            var book = bookService.SearchBookByPublishedBy("Vicky");
            Assert.IsTrue(book.publishedBy==null);
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
