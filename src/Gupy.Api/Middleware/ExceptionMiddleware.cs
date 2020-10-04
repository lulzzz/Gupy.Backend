using System;
using System.Net;
using System.Threading.Tasks;
using Gupy.Api.Helpers;
using Gupy.Core.Exceptions;
using Microsoft.AspNetCore.Http;

namespace Gupy.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            switch (exception)
            {
                case NotFoundException notFoundException:
                {
                    var response = new ApiResponse<object>(HttpStatusCode.NotFound, error: notFoundException.Error);
                    context.Response.StatusCode = (int) HttpStatusCode.NotFound;
                    return context.Response.WriteAsync(response.ToString());
                }
                case NotValidException notValidException:
                {
                    var response = new ApiResponse<object>(HttpStatusCode.BadRequest, error: notValidException.Error);
                    context.Response.StatusCode = (int) HttpStatusCode.BadRequest;
                    return context.Response.WriteAsync(response.ToString());
                }
                default:
                {
                    var response = new ApiResponse<object>(HttpStatusCode.InternalServerError);
                    context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                    return context.Response.WriteAsync(response.ToString());
                }
            }
        }
    }
}