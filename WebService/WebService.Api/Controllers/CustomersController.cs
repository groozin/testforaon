using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebService.Api.Controllers
{
    [EnableCors("*", "*", "*")]
    public class CustomersController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage GetCustomers()
        {
            var customers = new[] { new { Name = "Tomasz", Orders = "2" }, new { Name = "Tomasz", Orders = "2" }, new { Name = "Tomasz", Orders = "2" } };
            return Request.CreateResponse(customers);
        }
    }
}
