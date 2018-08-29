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
    class TransactionServiceTest
    {

        ITransactionService Transactionservice;

        [TestInitialize]
        public void Intialize()
        {
            UnityContainer Container = new UnityContainer();
            Container.RegisterType<ITransactionService, TransactionService>();
            Container.RegisterType<ITransactionRepository, TransactionRepository>();
            Transactionservice = Container.Resolve<TransactionService>();

        }

        //[TestMethod]
        //public void IssueBook()
        //{
        //    Transaction trans = new Transaction();

        //    trans.userId =63;
        //    trans.bookId = 5;
        //    var user = new User() { userId = 1, name = "vikas" };
        //    Assert.IsTrue(Transactionservice.IssueBook(user, new Book() { bookId = 1 }));

        }
    }
}
}
