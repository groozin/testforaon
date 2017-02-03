using System.Collections.Generic;
using NUnit.Framework;
using WebService.Infrastructure.DAL;
using WebService.Infrastructure.Repositories;
using Customer = WebService.Core.Model.Customer;

namespace WebService.Infrastructure.Tests
{
    [TestFixture]
    public class InfrastructureTests
    {
        [Test]
        public void ItCanRunFirstTestFromInfrastructure()
        {
            Assert.AreEqual(2, 2);
        }

        [Test]
        public void ItGetsCustomersFromRepository()
        {
            IList<Customer> list = new List<Customer>();
            using (var context = new Northwind())
            {
                var repository = new CustomerRepository(context);
                list = repository.GetCustomersWithOrdersUnder(2);
            }
            
            Assert.IsNotNull(list);
            Assert.IsNotEmpty(list);
            Assert.AreEqual(3, list.Count);
        }
    }
}
