using System;
using System.Linq;
using System.Net.Http;

namespace QuerystringBased.Infrastructure
{
    public class VersionFinder
    {
        public int GetVersionFromRequest(HttpRequestMessage request)
        {
            string version;
            return NeedsQuerystringVersioning(request, out version) ? VersionToInt(version) : 0;
        }

        private static bool NeedsQuerystringVersioning(HttpRequestMessage request, out string version)
        {
            if (request.GetQueryNameValuePairs().Any(x => string.Compare(x.Key, "v", StringComparison.CurrentCultureIgnoreCase) == 0))
            {
                var querystringVersion =
                    request.GetQueryNameValuePairs()
                        .First(x => string.Compare(x.Key, "v", StringComparison.CurrentCultureIgnoreCase) == 0)
                        .Value;

                if (querystringVersion != null)
                {
                    version = querystringVersion;
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
                return int.Parse(System.Configuration.ConfigurationManager.AppSettings["latestApiVersion"]);

            return version;
        }
    }
}