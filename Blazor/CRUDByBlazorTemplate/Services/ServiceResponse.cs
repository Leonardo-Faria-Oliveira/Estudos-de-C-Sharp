using System.Net;

namespace CRUDByBlazorTemplate.Services
{
    public class ServiceResponse
    {

        public HttpStatusCode StatusCode { get; set; }

        public string? Message { get; set; }

        public object? Content { get; set; }

        public static  ServiceResponse Factory (HttpStatusCode statusCode, string? message=null, object? content=null)
        {
            return new ServiceResponse
            {
                StatusCode = statusCode,
                Message = message,
                Content = content
            };
        }

    }
}
