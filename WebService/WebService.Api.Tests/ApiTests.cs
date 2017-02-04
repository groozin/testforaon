using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web.Http.Results;
using Moq;
using NUnit.Framework;
using WebService.Api.Controllers;
using WebService.Core.Interfaces;
using WebService.Core.Model;

namespace WebService.Api.Tests
{
    [TestFixture]
    public class ApiTests
    {
        [Test]
        public void ItCanRunFirstTestFromApi()
        {
            Assert.AreEqual(3,3);
        }

        [Test]
        public void CustomersControllerShouldThrowExceptionWhenNoServicePassed()
        {
            Assert.Throws<ArgumentNullException>(() => { new CustomersController(null); });            
        }

        [Test]
        public void CustomersControllerShouldReturnListOfCustomers()
        {
            var customersList = new List<Customer>
            {
                new Customer { Name = "Joel Lang", NumberOfOrders = 0 },
                new Customer { Name = "Laura Daniels", NumberOfOrders = 1 }
            };
            var customerService = new Mock<ICustomerService>();
            customerService.Setup(k => k.GetCustomersWithOrdersUnder(2)).Returns(customersList);
            
            var ctrl = new CustomersController(customerService.Object);
            var result = ctrl.GetCustomers();

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkNegotiatedContentResult<IList<Customer>>>(result);
            var okResult = result as OkNegotiatedContentResult<IList<Customer>>;
            Assert.IsAssignableFrom<List<Customer>>(okResult.Content);
            Assert.AreEqual("Joel Lang", customersList.First().Name);
            Assert.AreEqual(0, customersList.First().NumberOfOrders);
        }
    }
}
