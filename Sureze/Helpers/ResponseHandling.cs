using System.Net;

namespace Sureze.Helpers
{
    public class ResponseHandling
    {
        public HttpStatusCode? StatusCode { get; set; }
        public string? Response { get; set; }
        public object? ReturnedData { get; set; }


        public ResponseHandling(HttpStatusCode? statusCode = null, string? response = null, object? returnedData = null)
        {
            StatusCode = statusCode;
            Response = response;
            ReturnedData = returnedData;
        }

    }
}
