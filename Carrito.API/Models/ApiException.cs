namespace Carrito.API.Models
{
    public class ApiException
    {
        public ApiException(int statusCode, string message = null, string detail = null)
        {
            StatusCode = statusCode;
            Message = message;
            Detail = detail;
        }

        public int StatusCode { get; }
        public string Message { get; }
        public string Detail { get; }
    }
}
