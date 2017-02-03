using System.Collections.Generic;
using WebService.Core.Interfaces;
using WebService.Core.Model;

namespace WebService.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public IList<Customer> GetCustomersWithOrdersUnder(int numberOfOrders)
        {
            return new List<Customer>();
        }
    }
}