﻿using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using WebService.Core.Interfaces;
using WebService.Core.Model;
using WebService.Core.Services;

namespace WebService.Core.Tests
{
    [TestFixture]
    public class CoreTests
    {
        [Test]
        public void ItCanRunFirstTestFromCore()
        {
            Assert.AreEqual(3, 3);
        }

        [Test]
        public void ItThrowsExceptionWhenNoContextPassedToCustomerServiceConstructor()
        {
            Assert.Throws<ArgumentNullException>(() => { new CustomerService(null); });
        }

        [Test]
        public void ItGetsCustomers()
        {
            var customersList = new List<Customer>
            {
                new Customer { Name = "Joel Lang", NumberOfOrders = 0 },
                new Customer { Name = "Laura Daniels", NumberOfOrders = 1 }
            };

            var customerRepository = new Mock<ICustomerRepository>();
            customerRepository.Setup(cr => cr.GetCustomersWithOrdersUnder(2)).Returns(customersList);
            
            var customerService = new CustomerService(customerRepository.Object);
            var customers = customerService.GetCustomersWithOrdersUnder(2);
            
            Assert.NotNull(customers);
            Assert.AreEqual(2, customers.Count);
            Assert.IsTrue(customers.Any(customer => customer.Name.Equals("Joel Lang", StringComparison.InvariantCulture)));
            Assert.IsTrue(customers.Any(customer => customer.Name.Equals("Laura Daniels", StringComparison.InvariantCulture)));
            Assert.AreEqual(0, customers.First(customer => customer.Name.Equals("Joel Lang", StringComparison.InvariantCulture)).NumberOfOrders);
            Assert.AreEqual(1, customers.First(customer => customer.Name.Equals("Laura Daniels", StringComparison.InvariantCulture)).NumberOfOrders);
        }
    }
}
