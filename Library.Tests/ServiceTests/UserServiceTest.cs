using Library.BusinessObjects;
using Library.BusinessObjects.enums;
using Library.Repository;
using Library.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;

namespace Library.Tests.ServiceTests
{
    [TestClass]
    public class UserServiceTest
    {
        private int deleteUserId = 0;
        private string name = "Uni11111";
        private IUserService userService;
        private UnityContainer unityContainer;

        [TestInitialize]
        public void Initialize()
        {
            unityContainer = new UnityContainer();
            unityContainer.RegisterType<IUserService, UserService>();
            unityContainer.RegisterType<IUserRepository, UserRepository>();
            userService = unityContainer.Resolve<UserService>();
        }

        [TestMethod]
        public void AddUserStudent()
        {
            User newUser = new User();
            newUser.name = name;
            newUser.password = "password";
            newUser.roleName = UserType.Student;
            newUser.username = "UnitTestStudent";
            newUser.address = "westernpearl";
            bool newUserCreated = userService.AddUser(newUser);
            if (newUserCreated)
                deleteUserId = userService.GetUserByName(name).userId;
            Assert.IsTrue(newUserCreated);
        }

        [TestMethod]
        public void AddInvalidUser()
        {
            User invalidUser = new User();
            Assert.IsFalse(userService.AddUser(invalidUser));
        }

        [TestMethod]
        public void GetValidUserByName()
        {
            var data = userService.GetUserByName(name);
            Assert.IsTrue(data.name == name && data.roleName == UserType.Student);
        }

        [TestMethod]
        public void GetInValidUserByName()
        {
            var data1 = userService.GetUserByName("Testkjlhog");
            Assert.IsTrue(data1.name == null && data1.password == null);
        }

        [TestMethod]
        public void GetValidUserById()
        {
            var data2 = userService.GetUserById(userService.GetUserByName(name).userId);
            Assert.IsTrue(data2.name == name);
        }

        [TestMethod]
        public void GetInvalidUserById()
        {
            var data3 = userService.GetUserById(4545);
            Assert.IsTrue(data3.username == null && data3.password == null);
        }

        [TestMethod]
        public void RemoveValidUser()
        {
            Assert.IsTrue(userService.RemoveUser(deleteUserId));
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
        public void UserServiceTest1()
        {
            AddInvalidUser();
            AddUserStudent();
            GetValidUserByName();
            GetInValidUserByName();
            GetValidUserById();
            GetInvalidUserById();
            RemoveValidUser();
            RemoveInValidUser();
        }
    }
}