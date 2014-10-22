using System.Linq;
using System.Net.Http;

namespace RequestHeaders.Infrastructure
{
    public class VersionFinder
    {
        public int GetVersionFromRequest(HttpRequestMessage request)
        {
            string version;
            return NeedsHeaderVersioning(request, out version) ? VersionToInt(version) : 0;
        }

        private static bool NeedsHeaderVersioning(HttpRequestMessage request, out string version)
        {
            if (request.Headers.Contains("api-version"))
            {
                version = request.Headers.GetValues("api-version").FirstOrDefault();
                if (version != null)
                {
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