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
    public class UserServiceTest
    {

        IUserService userService;
        [TestInitialize]
        public void Initialize()
        {
            UnityContainer unityContainer = new UnityContainer();
            unityContainer.RegisterType<IUserService, UserService>();
            unityContainer.RegisterType<IUserRepository, UserRepository>();
            userService = unityContainer.Resolve<UserService>();
        }

        [TestMethod]
        public void GetValidUser()
        {            
            var data = userService.GetUserById(8);
            Assert.IsTrue(data.username == "vinay" );
        }
        [TestMethod]
        public void GetInvalidUser()
        {
            var data = userService.GetUserById(4545);
            Assert.IsNull(data);
        }
        [TestMethod]
        public void AddUserStudent()
        {
            User newUser = new User();
            newUser.name = "UnitTest";
            newUser.password = "password";
            newUser.roleName = UserType.Student;
            newUser.username = "unitTest";
            newUser.address = "westernpearl";
            Assert.IsTrue(userService.AddUser(newUser));
        }
        [TestMethod]
        public void AddUserStaff()
        {
            User newUser = new User();
            newUser.name = "UnitTest";
            newUser.password = "password";
            newUser.roleName = UserType.Staff;
            newUser.username = "unitTest";
            newUser.address = "westernpearl";
            bool newUserCreated = userService.AddUser(newUser);
            Assert.IsTrue(newUserCreated);
        }
        [TestMethod]
        public void AddUserLibrarian()
        {
            User newUser = new User();
            newUser.name = "UnitTest";
            newUser.password = "password";
            newUser.roleName = UserType.Librarian;
            newUser.username = "unitTest";
            newUser.address = "westernpearl";
            bool newUserCreated = userService.AddUser(newUser);
            Assert.IsTrue(newUserCreated);
        }
        [TestMethod]
        public void RemoveValidUser()
        {
            Assert.IsTrue(userService.RemoveUser(10));
        }
        [TestMethod]
        public void RemoveInValidUser()
        {
            Assert.IsTrue(userService.RemoveUser(1022));
        }


    }
}
