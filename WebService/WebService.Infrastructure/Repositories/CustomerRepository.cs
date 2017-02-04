using System;
using System.Collections.Generic;
using System.Linq;
using WebService.Core.Interfaces;
using WebService.Infrastructure.DAL;
using Customer = WebService.Core.Model.Customer;

namespace WebService.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly Northwind _context;
        
        public CustomerRepository(Northwind context)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;
        }

        public IList<Customer> GetCustomersWithOrdersUnder(int numberOfOrders)
        {
            return _context.Customers
                .Where(c => c.Orders.Count < numberOfOrders)
                .Select(c => new Customer { Name = c.ContactName, NumberOfOrders = c.Orders.Count })
                .ToList();
        }
    }
}