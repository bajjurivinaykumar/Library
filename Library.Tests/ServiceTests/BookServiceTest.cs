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
            Addbook.name = "Camp";
            Addbook.quantity = 25;
            Addbook.price = 850;
            Addbook.publishedBy = "Maruthi";
            Addbook.publisher = "Dheeraj";
            Assert.IsTrue(BookService.AddBook(Addbook));

 
        }

        [TestMethod]
        public void SearchBookbyName()
        {

            var name = BookService.SearchBookByName("Camp");
            Assert.AreEqual("Camp", name.name);

        }

        [TestMethod]
        public void SearchBookByPublishedBy()
        {
            var Publishedby = BookService.SearchBookByPublishedBy("Maruthi");
            Assert.AreEqual("Maruthi", Publishedby.publishedBy);
        }

        [TestMethod]
        public void InvalidBookSearchedByName()
        {
            var BookName = BookService.SearchBookByName("DaretoLive");
            Assert.IsNull(BookName.name);
        }

        [TestMethod]
        public void invalidBookByPublishedBy()
        {
            var BookPublishedby = BookService.SearchBookByPublishedBy("Vicky");
            Assert.IsNull(BookPublishedby.publishedBy);
        }

        [TestMethod]
        public void DeleteBook()
        {
            Assert.IsTrue(BookService.DeleteBook(3));
        }

        [TestMethod]
        public void DeleteInvalidBook()
        {
            Assert.IsFalse(BookService.DeleteBook(69));
        }

        [TestMethod]
        public void EditBook()
        {
            var Newquantity = BookService.EditQuantity(4, 65);
            Assert.IsTrue(Newquantity);
        
        }
        [TestMethod]

        public void EditInvalidBook()
        {
            var NewQuantity = BookService.EditQuantity(69, 25);
            Assert.IsFalse(NewQuantity);
        }

    }


}
