using System.Linq;
using System.Net.Http;

namespace ContentNegotiation.Infrastructure
{
    public class VersionFinder
    {
        public int GetVersionFromRequest(HttpRequestMessage request)
        {
            string version;
            return NeedsAcceptVersioning(request, out version) ? VersionToInt(version) : 0;
        }

        private static bool NeedsAcceptVersioning(HttpRequestMessage request, out string version)
        {
            if (request.Headers.Accept.Any())
            {
                var acceptHeaderVersion =
                    request.Headers.Accept.FirstOrDefault(x => x.MediaType.Contains("vnd.saraceno.sample.api"));

                if (acceptHeaderVersion != null && acceptHeaderVersion.MediaType.Contains("-v") && acceptHeaderVersion.MediaType.Contains("+"))
                {
                    version = acceptHeaderVersion.MediaType.Between("-v", "+");
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