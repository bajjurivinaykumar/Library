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
        public void getUserById()
        {
          var data = _userRepository.GetUserById(63);
            Assert.IsTrue(data.name == "Unit11");
        }
        [TestMethod]
        public void getUserByName()
        {
            var data = _userRepository.GetUserByName("Unit11");
            Assert.IsTrue(data.address == "westernpearl");
        }


}
}
