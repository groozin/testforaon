using System.Collections.Generic;
using WebService.Core.Model;

namespace WebService.Core.Interfaces
{
    public interface ICustomerService
    {
        IList<Customer> GetCustomersWithOrdersUnder(int numberOfOrders);
    }
}