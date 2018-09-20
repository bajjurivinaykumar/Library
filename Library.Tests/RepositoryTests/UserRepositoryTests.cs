using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Unity;
using Library.Repository;
using Library.Services;
using Library.BusinessObjects.enums;
using Library.BusinessObjects;

namespace Library.Tests.RepositoryTests
{
    [TestClass]
  public   class UserRepositoryTests
    {
        private UnityContainer unityContainer;
        UserRepository _userRepository;
        
        [TestInitialize]
        public void Initialize()
        {          
            unityContainer = new UnityContainer();
            unityContainer.RegisterType<IUserRepository, UserRepository>();
            _userRepository = unityContainer.Resolve<UserRepository>();
        }

        [TestMethod]
        public void GetUserById()
        {
          var data = _userRepository.GetUserById(63);
            Assert.IsTrue(data.name == "Unit11");
        }
        [TestMethod]
        public void GetUserByName()
        {
            var data = _userRepository.GetUserByName("Unit11");
            Assert.IsTrue(data.address == "westernpearl");
        }
        [TestMethod]
        public void GetAllUsers()
        {
            List<User> userList = _userRepository.GetAllUsers();
            Assert.IsTrue(userList != null);
        }
        [TestMethod]
        public void GetIssuedBookList()
        {
            List<string> bookList = _userRepository.GetIssuedBookName(10);
            Assert.IsTrue(bookList != null);
        }
        [TestMethod]
        public void AddUser()
        {
            User user = new User()
            {
                name = "RepositoryTest",
                username = "rtest",
                password = "rtest",
                address = "repository",
                roleName = UserType.Student,
                createdOn = DateTime.Now

            };
            Assert.IsTrue(_userRepository.AddUser(user));
        }
        [TestMethod]
        public void RemoveUser()
        {
            int userId = _userRepository.GetUserId();
            Assert.IsTrue(_userRepository.RemoveUser(userId));
        }

}
}
