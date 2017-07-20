using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserService.Exceptions;

namespace UserService.Tests
{
    [TestClass]
    public class UserServiceTests
    {
        [TestMethod]
        [ExpectedException(typeof(AlreadyExistsException))]
        public void Add_UserExisted_ExceptionThrown()
        {
            var service = new UserService();
            var user = new User() { Age = 18, FirstName = "John", LastName = "Smith" };
            service.Add(user);
            service.Add(user);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Add_Null_ExceptionThrown()
        {
            var service = new UserService();
            service.Add(null);
        }

        [TestMethod]
        [ExpectedException(typeof(UserValidationException))]
        public void Add_AgeIsNegative_ExceptionThrown()
        {
            var service = new UserService();
            var user = new User() { Age = -1, FirstName = "John", LastName = "Smith" };
            service.Add(user);
        }

        [TestMethod]
        [ExpectedException(typeof(UserValidationException))]
        public void Add_NameIsNull_ExceptionThrown()
        {
            var service = new UserService();
            var user = new User() { Age = -13, FirstName = null, LastName = "Smith" };
            service.Add(user);
        }
    }
}
