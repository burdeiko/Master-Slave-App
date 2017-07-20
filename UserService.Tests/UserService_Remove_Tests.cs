using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserService.Exceptions;
using System.Linq;

namespace UserService.Tests
{
    [TestClass]
    public class UserService_Remove_Tests
    {
        [TestMethod]
        [ExpectedException(typeof(NotExistedException))]
        public void Remove_NonExisted_ExceptionThrown()
        {
            var service = new UserService();
            service.Remove(new User() { Age = 12, FirstName = "Eddy", LastName = "White" });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Remove_Null_ExceptionThrown()
        {
            var service = new UserService();
            service.Remove(null);
        }

        [TestMethod]
        public void Remove_Succeeded()
        {
            var service = new UserService();
            var user = new User() { Age = 1, FirstName = "J", LastName = "S" };
            service.Add(user);
            service.Remove(user);
            Assert.AreEqual(service.Search(u => u.Equals(user)).Count(), 0);
        }
    }
}
