using System;
using System.Collections.Generic;
using WebService.Core.Interfaces;
using WebService.Core.Model;

namespace WebService.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        
        public CustomerService(ICustomerRepository customerRepository)
        {
            if (customerRepository == null) throw new ArgumentNullException("customerRepository");

            _customerRepository = customerRepository;
        }

        public IList<Customer> GetCustomersWithOrdersUnder(int numberOfOrders)
        {
            return _customerRepository.GetCustomersWithOrdersUnder(numberOfOrders);
        }
    }
}