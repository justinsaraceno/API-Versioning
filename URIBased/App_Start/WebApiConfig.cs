using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using URIBased.Infrastructure;

namespace URIBased
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // replace the default HTTP controller selector with a version-aware controller selector
            config.Services.Replace(typeof(IHttpControllerSelector), new VersionAwareControllerSelector(config));

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
