using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace ContentNegotiation.Infrastructure
{
    public class VersionAwareControllerSelector : DefaultHttpControllerSelector
    {
        public VersionAwareControllerSelector(HttpConfiguration configuration) : base(configuration)
        {
        }

        public override string GetControllerName(System.Net.Http.HttpRequestMessage request)
        {
            var controllerName = base.GetControllerName(request);
            var versionFinder = new VersionFinder();
            var version = versionFinder.GetVersionFromRequest(request);

            if (version > 0)
            {
                return GetVersionedControllerName(request, controllerName, version);
            }

            return controllerName;
        }

        private string GetVersionedControllerName(HttpRequestMessage request, string controllerName, int version)
        {
            // for version 1, use the controller name without a version number; use the version number to all other controller names
            var versionControllerName = version > 1 ? string.Format("{0}v{1}", controllerName, version) : string.Format("{0}", controllerName);
            HttpControllerDescriptor descriptor;
            if (GetControllerMapping().TryGetValue(versionControllerName, out descriptor))
                return versionControllerName;

            throw new HttpResponseException(
                request.CreateErrorResponse(
                    HttpStatusCode.NotFound, 
                    String.Format("No HTTP resource was found that matches the URI {0} and version number {1}", request.RequestUri, version)));
        }
    }
}