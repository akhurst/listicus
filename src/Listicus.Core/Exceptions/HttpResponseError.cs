using System;
using System.Net;

namespace Listicus.Core.Exceptions
{
    public class HttpResponseError : SystemException
    {
        private readonly HttpStatusCode statusCode;
        private readonly string responseText;
        public HttpStatusCode StatusCode { get { return statusCode; } }
        public string ResponseText { get { return responseText; } }

        public HttpResponseError(HttpStatusCode statusCode, string responseText)
        {
            this.statusCode = statusCode;
            this.responseText = responseText;
        }
    }
}
