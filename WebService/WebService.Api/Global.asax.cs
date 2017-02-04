using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using WebService.Api.Controllers;
using WebService.Core.Services;
using WebService.Core.Interfaces;
using WebService.Infrastructure.DAL;
using WebService.Infrastructure.Repositories;

namespace WebService.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;
            
            builder.RegisterType<Northwind>().InstancePerLifetimeScope();
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>().InstancePerApiControllerType(typeof(CustomersController));
            builder.RegisterType<CustomerService>().As<ICustomerService>().InstancePerApiControllerType(typeof(CustomersController));
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
