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
    class BookServiceTest
    {
        IBookService BookService;
        [TestInitialize]
        public void Initialize()
        {
            UnityContainer unityContainer = new UnityContainer();
            unityContainer.RegisterType<IBookService, BookService>();
            unityContainer.RegisterType<IBookRepository, BookRepository>();
            BookService=unityContainer.Resolve<BookService>();
        }

        [TestMethod]
        public void AddBook()
        {
            Book Addbook = new Book();
            Addbook.name = "Gudacahri";
            Addbook.quantity = 10;
            Addbook.price = 850;
            Addbook.publishedBy = "Adavisheshu";
            Addbook.publisher = "Varahi";
            Assert.IsTrue(BookService.AddBook(Addbook));

 
        }

        [TestMethod]
        public void SearchBookbyName()
        {

            var name = BookService.SearchBookByName("Gudacahri");
            Assert.IsTrue(name.Equals("Gudachari"));

        }

        [TestMethod]
        public void SearchBookByPublishedBy()
        {
            var Publishedby = BookService.SearchBookByPublishedBy("Adavisheshu");
            Assert.IsTrue(Publishedby.Equals("Adavisheshu"));
         
        }

        [TestMethod]
        public void InvalidBookSearchedByName()
        {
            var BookName = BookService.SearchBookByName("DaretoLive");
            Assert.IsNull(BookName);
        }

        [TestMethod]
        public void invalidBookByPublishedBy()
        {
            var BookPublishedby = BookService.SearchBookByPublishedBy("Vicky");
            Assert.IsNull(BookPublishedby);
        }

        [TestMethod]
        public void DeleteBook()
        {
            Assert.IsTrue(BookService.DeleteBook(1));
        }

        [TestMethod]
        public void DeleteInvalidBook()
        {
            Assert.IsTrue(BookService.DeleteBook(69));
        }

        [TestMethod]
        public void EditBook()
        {
            var Newquantity = BookService.EditQuantity(2, 25);
            Assert.IsTrue(Newquantity.Equals(25));
        
        }
        [TestMethod]

        public void EditInvalidBook()
        {
            var NewQuantity = BookService.EditQuantity(69, 25);
            Assert.IsTrue(NewQuantity.Equals(25));
        }

    }


}
