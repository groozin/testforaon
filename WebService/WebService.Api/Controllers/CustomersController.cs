using System.Net.Http;
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
            _customerService = customerService;
        }

        [HttpGet]
        public HttpResponseMessage GetCustomers()
        {
            var customers = _customerService.GetCustomersWithOrdersUnder(2);
            return Request.CreateResponse(customers);
        }
    }
}
