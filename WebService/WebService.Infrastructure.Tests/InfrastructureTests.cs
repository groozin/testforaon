using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Moq;
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

        [Test, Category("Integration test"), Ignore("This will only work when Northwind databse is deployed and accessible.")]
        public void ItGetsCustomersFromRepository()
        {
            IList<Customer> list;
            using (var context = new Northwind())
            {
                var repository = new CustomerRepository(context);
                list = repository.GetCustomersWithOrdersUnder(2);
            }
            
            Assert.IsNotNull(list);
            Assert.IsNotEmpty(list);
            Assert.AreEqual(3, list.Count);
        }

        [Test]
        public void ItThrowsExceptionWhenNoContextPassedToCustomerRepositoryConstructor()
        {
            Assert.Throws<ArgumentNullException>(() => { new CustomerRepository(null); });
        }

        [Test]
        public void ItGetsCustomersFromMockDbContext()
        {
            var joelsOrders = new List<Order> { new Order(), new Order(), new Order() };
            var laurasOrders = new List<Order> { new Order() };

            var customers = new List<DAL.Customer>
            {
                new DAL.Customer { ContactName = "Joel Lang", Orders = joelsOrders },
                new DAL.Customer { ContactName = "Laura Daniels", Orders = laurasOrders }
            }.AsQueryable();

            var mockCustomersSet = new Mock<DbSet<DAL.Customer>>(); 
            mockCustomersSet.As<IQueryable<DAL.Customer>>().Setup(m => m.Provider).Returns(customers.Provider); 
            mockCustomersSet.As<IQueryable<DAL.Customer>>().Setup(m => m.Expression).Returns(customers.Expression); 
            mockCustomersSet.As<IQueryable<DAL.Customer>>().Setup(m => m.ElementType).Returns(customers.ElementType); 
            mockCustomersSet.As<IQueryable<DAL.Customer>>().Setup(m => m.GetEnumerator()).Returns(customers.GetEnumerator()); 
 
            var mockContext = new Mock<Northwind>(); 
            mockContext.Setup(c => c.Customers).Returns(mockCustomersSet.Object); 

            var repository = new CustomerRepository(mockContext.Object);
            var customersList = repository.GetCustomersWithOrdersUnder(2);

            Assert.IsNotNull(customersList);
            Assert.IsNotEmpty(customersList);
            Assert.AreEqual(1, customersList.Count);
            Assert.AreEqual("Laura Daniels", customersList.First().Name);
            Assert.AreEqual(1, customersList.First().NumberOfOrders);
        }
    }
}
