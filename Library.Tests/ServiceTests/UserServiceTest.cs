using Library.BusinessObjects;
using Library.BusinessObjects.enums;
using Library.Repository;
using Library.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Unity;
using Moq;
using System.Collections.Generic;

namespace Library.Tests.ServiceTests
{
    [TestClass]
    public class UserServiceTest
    {
        
        private IUserService userService;
        private UnityContainer unityContainer;

        [TestInitialize]
        public void Initialize()
        {
            unityContainer = new UnityContainer();
            User user = new User()
            {
                address = "Kondapur",
                createdOn = DateTime.Now,
                name = "Vinay",
                password = "test",
                username = "vinay",
                roleName = UserType.Librarian

            };
            Book book = new Book();
            unityContainer.RegisterType<IUserService, UserService>();
            //unityContainer.RegisterType<IUserRepository, UserRepository>();
           // unityContainer.RegisterType<IAuthorizationService, AuthorizationService>();
            

            Mock<IUserRepository> mockUserRepository = new Mock<IUserRepository>();
            unityContainer.RegisterInstance<IUserRepository>(mockUserRepository.Object);
            Mock<IAuthorizationService> mockAuthorizationService = new Mock<IAuthorizationService>();
            unityContainer.RegisterInstance<IAuthorizationService>(mockAuthorizationService.Object);
            userService = unityContainer.Resolve<UserService>();

            mockAuthorizationService.Setup(a => a.Authorize(UserType.Librarian, It.IsAny<string>())).Returns(true);

            mockUserRepository.Setup(u => u.AddUser(It.IsAny<User>())).Returns(true);

            mockUserRepository.Setup(u => u.GetAllUsers()).Returns(new List<User>() { user });

            mockUserRepository.Setup(u => u.GetUserById(100)).Returns(user);

            mockUserRepository.Setup(u => u.GetUserByName("vinay")).Returns(user);

            mockUserRepository.Setup(u => u.RemoveUser(100)).Returns(true);

            mockUserRepository.Setup(u => u.GetIssuedBookName(It.IsAny<int>())).Returns(new List<string>() {"book" });

        }

        [TestMethod]
        public void AddUserStudent()
        {
            User newUser = new User();
            newUser.name = "test";
            newUser.password = "password";
            newUser.roleName = UserType.Student;
            newUser.username = "UnitTestStudent";
            newUser.address = "westernpearl";
            bool newUserCreated = userService.AddUser(newUser);
            Assert.IsTrue(newUserCreated);
        }

      

        [TestMethod]
        public void GetValidUserByName()
        {
            var data = userService.GetUserByName("vinay");
            Assert.IsTrue(data.name == "Vinay" && data.address == "Kondapur");
        }

        [TestMethod]
        public void GetInValidUserByName()
        {
            var data1 = userService.GetUserByName("Testkjlhog");
            Assert.IsTrue(data1 == null);
        }

        [TestMethod]
        public void GetValidUserById()
        {
            var data2 = userService.GetUserById(100);
            Assert.IsTrue(data2.name == "Vinay");
        }

        [TestMethod]
        public void GetInvalidUserById()
        {
            var data3 = userService.GetUserById(4545);
            Assert.IsTrue(data3 == null);
        }

        [TestMethod]
        public void RemoveValidUser()
        {
            Assert.IsTrue(userService.RemoveUser(100));
        }

        [TestMethod]
        public void RemoveInValidUser()
        {
            Assert.IsFalse(userService.RemoveUser(1022));
        }

        [TestCleanup]
        public void CleanUp()
        {
            userService = null;
            unityContainer = null;
        }
        [TestMethod]
        public void GetAllUsers()
        {
           var data =  userService.GetAllUsers();
            Assert.IsTrue(data.Count > 0);
        }
}
}