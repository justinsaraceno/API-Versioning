﻿using System.Web.Http;
using System.Web.Http.Dispatcher;
using ContentNegotiation.Infrastructure;

namespace ContentNegotiation
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // replace the default HTTP controller selector with a version-aware controller selector
            config.Services.Replace(typeof(IHttpControllerSelector), new VersionAwareControllerSelector(config));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            GlobalConfiguration.Configuration.Filters.Add(new VersionHeaderFilter());
        }
    }
}
