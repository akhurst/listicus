namespace Listicus.Web.Framework
{
    using System.Globalization;
    using System.Text.RegularExpressions;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    /// <summary>
    /// This class impliments a custom route handler to facilitate testing.
    /// </summary>
    public class CustomRouteHandler : IRouteHandler
    {
        /// <summary>
        /// Gets the HTTP handler and redirects output if "routeInfo" is a query string.
        /// </summary>
        /// <param name="requestContext">The request which is made to the route handler.</param>
        /// <returns>A HTTP Handler</returns>
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            if (HasQueryStringKey("routeInfo", requestContext.HttpContext.Request))
            {
                OutputRouteDiagnostics(requestContext.RouteData, requestContext.HttpContext);
            }

            var handler = new MvcHandler(requestContext);
            return handler;
        }

        /// <summary>
        /// Determines if a request contains the desired key.
        /// </summary>
        /// <param name="key">The key to search for.</param>
        /// <param name="request">The request string to search.</param>
        /// <returns>A value indicating whether the key was found in the request.</returns>
        private static bool HasQueryStringKey(string key, HttpRequestBase request)
        {
            return Regex.IsMatch(request.Url.Query, string.Format(CultureInfo.InvariantCulture, @"^\?{0}$", key));
        }

        /// <summary>
        /// Formats the route diagnostics for output.
        /// </summary>
        /// <param name="routeData">The routing data to use.</param>
        /// <param name="context">The HTTP context of the request.</param>
        private static void OutputRouteDiagnostics(RouteData routeData, HttpContextBase context)
        {
            var response = context.Response;
            response.Write(
            @"<style>body {font-family: Arial;}
                table th {background-color: #359; color: #fff;}
                </style>
                <h1>Route Data:</h1>
                <table border='1' cellspacing='0' cellpadding='3'>
                <tr><th>Key</th><th>Value</th></tr>");

            foreach (var pair in routeData.Values)
                response.Write(string.Format(CultureInfo.InvariantCulture, "<tr><td>{0}</td><td>{1}</td></tr>", pair.Key, pair.Value));

            response.Write(
            @"</table>
                <h1>Routes:</h1>
                <table border='1' cellspacing='0' cellpadding='3'>
                <tr><th></th><th>Route</th></tr>");

            var foundRouteUsed = false;
            foreach (Route r in RouteTable.Routes)
            {
                response.Write("<tr><td>");
                var matches = r.GetRouteData(context) != null;
                var backgroundColor = matches ? "#bfb" : "#fbb";
                if (matches && !foundRouteUsed)
                {
                    response.Write("&raquo;");
                    foundRouteUsed = true;
                }

                response.Write(string.Format(
                    CultureInfo.InvariantCulture,
                    "</td><td style='font-family: Courier New; background-color:{0}'>{1}</td></tr>",
                    backgroundColor,
                    r.Url));
            }

            response.End();
        }
    }
}