using Library.Repository;
using Library.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Library.Tests.ServiceTests
{
    [TestClass]
    public class UserServiceTest
    {/*
        [TestMethod]
        public void validGetUser()
        {
            UnityContainer unityContainer = new UnityContainer();
            unityContainer.RegisterType<IUserService, UserService>();
            unityContainer.RegisterType<IUserRepository, UserRepository>();
            IUserService userService = unityContainer.Resolve<UserService>();
            var data = userService.GetUser(8);
            Assert.IsTrue(data.username == "vinay" );
        }
        */
    }
}
