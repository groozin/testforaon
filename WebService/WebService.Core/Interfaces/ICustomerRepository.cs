using System.Collections.Generic;
using WebService.Core.Model;

namespace WebService.Core.Interfaces
{
    public interface ICustomerRepository
    {
        IList<Customer> GetCustomersWithOrdersUnder(int numberOfOrders);
    }
}