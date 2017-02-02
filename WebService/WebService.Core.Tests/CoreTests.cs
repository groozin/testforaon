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
            var customerRepository = new CustomerRepository();
            var customerService = new CustomerService(customerRepository);
            var customers = customerService.GetCustomersWithOrdersUnder(2);

            Assert.NotNull(customers);
        }
    }

    public class CustomerRepository : ICustomerRepository
    {
        public IList<Customer> GetCustomersWithOrdersUnder(int numberOfOrders)
        {
            return new List<Customer>();
        }
    }

    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IList<Customer> GetCustomersWithOrdersUnder(int numberOfOrders)
        {
            return _customerRepository.GetCustomersWithOrdersUnder(numberOfOrders);
        }
    }

    public interface ICustomerService
    {
        IList<Customer> GetCustomersWithOrdersUnder(int numberOfOrders);
    }

    public interface ICustomerRepository
    {
        IList<Customer> GetCustomersWithOrdersUnder(int numberOfOrders);
    }

    public class Customer
    {
        public string Name { get; set; }
    }
}
