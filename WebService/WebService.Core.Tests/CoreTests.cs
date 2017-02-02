using System.Collections.Generic;
using NUnit.Framework;
using WebService.Core;

namespace WebService.Core.Tests
{
    [TestFixture]
    public class CoreTests
    {
        [Test]
        public void ItCanRunFirstTest()
        {
            Assert.AreEqual(3, 3);
        }

        [Test]
        public void ItGetsCustomers()
        {
            var customerService = new CustomerService();
            var customers = customerService.GetCustomers();

            Assert.NotNull(customers);
        }
    }

    public class CustomerService
    {
        public IList<Customer> GetCustomers()
        {
            return new List<Customer>();
        }
    }

    public class Customer
    {
        public string Name { get; set; }
    }
}
