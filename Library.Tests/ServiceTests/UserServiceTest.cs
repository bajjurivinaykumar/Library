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
        
        int deleteUserId=0;
       string name = "UnitTestStudent" + DateTime.Now.ToString("yyyyMMddHHmmss");
        IUserService userService;
        UnityContainer unityContainer;

        public string Name { get => name; set => name = value; }

        [TestInitialize]
        public void Initialize()
        {
            unityContainer = new UnityContainer();
            unityContainer.RegisterType<IUserService, UserService>();
            unityContainer.RegisterType<IUserRepository, UserRepository>();
            userService = unityContainer.Resolve<UserService>();
        }

        [TestMethod]
        public void GetValidUserById()
        {            
            var data = userService.GetUserById(8);
            Assert.IsTrue(data.username == "vinay" );
        }
        [TestMethod]
        public void GetInvalidUserById()
        {
            var data = userService.GetUserById(4545);
            Assert.IsTrue(data.username ==null && data.password==null);
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
        /*
       [TestMethod]
       public void AddUserStaff()
        {
            User newUser = new User();
            newUser.name = "UnitTestStaff";
            newUser.password = "password";
            newUser.roleName = UserType.Staff;
            newUser.username = "UnitTestStaff";
            newUser.address = "westernpearl";
             Assert.IsTrue(userService.AddUser(newUser));
        }
        [TestMethod]
        public void AddUserLibrarian()
        {
            User newUser = new User();
            newUser.name = "UnitTestLibrarian";
            newUser.password = "password";
            newUser.roleName = UserType.Librarian;
            newUser.username = "UnitTestLibrarian";
            newUser.address = "westernpearl";
           Assert.IsTrue(userService.AddUser(newUser));
           }

        */
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
            Assert.IsTrue(data.username == name && data.roleName == UserType.Student);
        }
        [TestMethod]
        public void GetInValidUserByName()
        {
            var data = userService.GetUserByName("Testkjlhog");
            Assert.IsTrue(data.username == null && data.password ==null);
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

    }
}
