using System;
using System.Web.Http;
using System.Web.Http.Cors;
using WebService.Core.Interfaces;

namespace WebService.Api.Controllers
{
    [EnableCors("*", "*", "*")]
    public class CustomersController : ApiController
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            if (customerService == null) throw new ArgumentNullException("customerService");
            _customerService = customerService;
        }

        [HttpGet]
        public IHttpActionResult GetCustomers()
        {
            var customers = _customerService.GetCustomersWithOrdersUnder(2);
            return Ok(customers);
        }
    }
}
