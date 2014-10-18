using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace URIBased.Infrastructure
{
    public class VersionFinder
    {
        public int GetVersionFromRequest(HttpRequestMessage request)
        {
            string version;
            return NeedsUriVersioning(request, out version) ? VersionToInt(version) : 0;
        }

        private static bool NeedsUriVersioning(HttpRequestMessage request, out string version)
        {
            var routeData = request.GetRouteData();
            if (routeData != null)
            {
                object versionFromRoute;
                if (routeData.Values.TryGetValue("version", out versionFromRoute))
                {
                    version = versionFromRoute as string;
                    if (!string.IsNullOrWhiteSpace(version))
                        return true;
                }
            }
            
            version = null;
            return false;
        }

        private static int VersionToInt(string versionString)
        {
            int version;
            if (string.IsNullOrEmpty(versionString) || !int.TryParse(versionString, out version))
                return 0;

            return version;
        }
    }
}