using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace URIBased
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            // version URI route
            config.Routes.MapHttpRoute(
                name: "DefaultVersioned",
                routeTemplate: "api/v{version}/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional, version = @"\d+" }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
