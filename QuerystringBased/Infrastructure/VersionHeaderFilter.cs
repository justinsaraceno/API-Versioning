using System.Web.Http.Filters;

namespace QuerystringBased.Infrastructure
{
    public class VersionHeaderFilter : ActionFilterAttribute
    {
        /// <summary>
        /// Displays the version number in the response header.
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var versionFinder = new VersionFinder();
            var version = versionFinder.GetVersionFromRequest(actionExecutedContext.Request);
            // if version wasn't passed in request, let's report it's version 1
            actionExecutedContext.Response.Content.Headers.Add("api-version", (version > 0 ? version : 1).ToString());
        }
    }
}