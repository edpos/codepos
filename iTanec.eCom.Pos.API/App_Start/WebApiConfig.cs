using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace iTanec.eCom.Pos.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes

            config.MapHttpAttributeRoutes();
            var cors = new EnableCorsAttribute("http://localhost:60259 , *", "*", "*");
            config.EnableCors();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
             name: "ActionApi",
             routeTemplate: "api/{controller}/{action}",
             defaults: new { id = RouteParameter.Optional }
             );

            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.Culture = new CultureInfo("en-US");
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
