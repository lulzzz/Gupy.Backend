using System.Net;
using System.Text.Json;
using Gupy.Core.Common;

namespace Gupy.Api.Helpers
{
    public class ApiResponse<T>
    {
        public HttpStatusCode StatusCode { get; }
        public T Data { get; }
        public Error Error { get; }

        public ApiResponse(HttpStatusCode statusCode, T data = default, Error error = default)
        {
            StatusCode = statusCode;
            Data = data;
            Error = error;
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this,
                new JsonSerializerOptions {PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
        }
    }
}