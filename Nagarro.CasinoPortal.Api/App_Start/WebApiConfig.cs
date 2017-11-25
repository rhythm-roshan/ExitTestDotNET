using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Nagarro.CasinoPortal.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes

            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
            config.MapHttpAttributeRoutes();



            config.Routes.MapHttpRoute(
                name: "Roulette",
                routeTemplate: "api/roulette/{id}",
                defaults: new { controller = "GameController", id = RouteParameter.Optional },
                constraints: new { id = "/d+" }
            );

            config.Routes.MapHttpRoute(
          name: "Admin",
          routeTemplate: "api/admin/{id}",
          defaults: new { controller = "AdminController", id = RouteParameter.Optional },
          constraints: new { id = "/d+" }
      );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);
        }
    }
}
