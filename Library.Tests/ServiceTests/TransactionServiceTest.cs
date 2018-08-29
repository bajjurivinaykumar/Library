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

        [TestMethod]
        public void issueBook()
        {
            Transaction trans = new Transaction();

        }
    }
}
