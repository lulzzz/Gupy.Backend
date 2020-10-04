using Gupy.Api.Middleware;
using Microsoft.AspNetCore.Builder;

namespace Gupy.Api.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}