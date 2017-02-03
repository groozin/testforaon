using System.Collections.Generic;
using System.Linq;
using WebService.Core.Interfaces;
using WebService.Infrastructure.DAL;
using Customer = WebService.Core.Model.Customer;

namespace WebService.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public IList<Customer> GetCustomersWithOrdersUnder(int numberOfOrders)
        {
            using (var northwind = new Northwind())
            {
                return northwind.Customers
                    .Where(c => c.Orders.Count < numberOfOrders)
                    .Select(c => new Customer { Name = c.ContactName })
                    .ToList();
            }
        }
    }
}