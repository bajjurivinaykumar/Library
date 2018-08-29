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
        IBookService BookService;
        int deleteBookId =0;
                private UnityContainer unityContainer;
        [TestInitialize]
        public void Initialize()
        {
             unityContainer = new UnityContainer();
            unityContainer.RegisterType<IBookService, BookService>();
            unityContainer.RegisterType<IBookRepository, BookRepository>();
            BookService=unityContainer.Resolve<BookService>();
        }

        [TestMethod]
        public void AddBook()
        {
            
            Book Addbook = new Book();
            Addbook.name = "Ca";
            Addbook.quantity = 25;
            Addbook.price = 850;
            Addbook.publishedBy = "Maru";
            Addbook.publisher = "Dheeraj";
            Addbook.bookType = BookType.Academics;
            Assert.IsTrue(BookService.AddBook(Addbook));

 
        }

        [TestMethod]
        public void SearchBookbyName()
        {

            var name = BookService.SearchBookByName("Ca");
            deleteBookId = name.bookId;
            Assert.AreEqual("Ca", name.name);

        }

        [TestMethod]
        public void SearchBookByPublishedBy()
        {
            var Publishedby = BookService.SearchBookByPublishedBy("Maru");
            Assert.AreEqual("Maru", Publishedby.publishedBy);
        }

        [TestMethod]
        public void InvalidBookSearchedByName()
        {
            var BookName = BookService.SearchBookByName("DaretoLive");
            Assert.IsTrue(BookName.name==null);
        }

        [TestMethod]
        public void invalidBookByPublishedBy()
        {
            var BookPublishedby = BookService.SearchBookByPublishedBy("Vicky");
            Assert.IsTrue(BookPublishedby.publishedBy==null);
        }

        [TestMethod]
        public void DeleteBook()
        {
            Assert.IsTrue(BookService.DeleteBook(deleteBookId));
        }
        [TestMethod]
        public void EditBook()
        {
            var Newquantity = BookService.EditQuantity(deleteBookId, 65);
            Assert.IsTrue(Newquantity);

        }
        [TestMethod]
        public void DeleteInvalidBook()
        {
            Assert.IsFalse(BookService.DeleteBook(69));
        }

        
            [TestMethod]

        public void EditInvalidBook()
        {
            var NewQuantity = BookService.EditQuantity(69, 25);
            Assert.IsFalse(NewQuantity);
        }
        [TestCleanup]
        public void CleanUp()
        {
            BookService = null;
            unityContainer = null;
        }


        [TestMethod]
        public void BookServiceTest1()
        {
            AddBook();
            SearchBookbyName();
            SearchBookByPublishedBy();
            InvalidBookSearchedByName();
            invalidBookByPublishedBy();
            EditBook();
            EditInvalidBook();
            DeleteInvalidBook();
            DeleteBook();
        }
    }


}
