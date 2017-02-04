using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace WebService.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var xmlSerializer = config.Formatters.XmlFormatter;
            config.Formatters.Remove(xmlSerializer);
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            
            config.EnableCors();
        }
    }
}
