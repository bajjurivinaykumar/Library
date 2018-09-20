using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Repository;
using Library.BusinessObjects;
using Library.BusinessObjects.enums;
using Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Library.Tests.RepositoryTests
{
    [TestClass]
    public class BookRepositoryTests
    {
        private UnityContainer unityContainer;
        BookRepository _bookRepository;
        Book book;
        

       [TestInitialize]
        public void Initialize()
        {
            unityContainer = new UnityContainer();
            unityContainer.RegisterType<IBookRepository, BookRepository>();
            _bookRepository = unityContainer.Resolve<BookRepository>();
           
            
        }
        [TestMethod]
        public void GetAllBooks()
        {
            List<Book> bookList = _bookRepository.GetAllBooks();
            Assert.IsTrue(bookList != null);
        }
        [TestMethod]
        public void AddBook()
        {
            book = new Book();
            book.bookType = BookType.Academics;
            book.name = "testBook2";
            book.price = 100;
            book.quantity = 25;
            book.publishedBy = "Test";
            book.publisher = "pppp";
            book.dateOfPurchase = DateTime.Now;
            Assert.IsTrue(_bookRepository.AddBook(book));
        }
        [TestMethod]
        public void SearchBookByName()
        {
            book = new Book();
            book = _bookRepository.SearchBookByName("testBook2");
            Assert.IsTrue(book.name == "testBook2");
        }
        [TestMethod]
        public void SearchBookByPublishedBy()
        {
            book = new Book();
            book = _bookRepository.SearchByPublishedBy("Test");
            Assert.IsTrue(book.publishedBy == "Test");
        }
        [TestMethod]
        public void EditQuantity()
        {
            book = new Book();
            book = _bookRepository.GetBook();
            _bookRepository.EditQuantity(book.bookId, book.quantity+1);
            
        }
        [TestMethod]
        public void RemoveBook()
        {
            book = new Book();
            book = _bookRepository.GetBook();
            Assert.IsTrue(_bookRepository.DeleteBook(book.bookId));

        }

    }
}
