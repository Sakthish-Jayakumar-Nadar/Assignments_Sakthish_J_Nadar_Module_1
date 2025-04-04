using System.Net;
using LMS.Application.Exception;

namespace LMS.API.Middleware
{
    public class ExceptionMiddleware
    {
        readonly RequestDelegate _next;
        //create constructor
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
                await HandleExceptionsAsync(httpContext, ex);
            }
        }

        private static async Task<Task> HandleExceptionsAsync(HttpContext httpContext, Exception ex)
        {
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            switch (ex)
            {
                case NotFoundException NotFound:
                    statusCode = HttpStatusCode.NotFound;
                    break;
                case BadRequestException BadRequest:
                    statusCode = HttpStatusCode.BadRequest;
                    break;
                default:
                    statusCode = HttpStatusCode.InternalServerError;
                    break;
            }
            ;
            httpContext.Response.StatusCode = (int)statusCode;
            var response = new
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = ex.Message

            };
            return httpContext.Response.WriteAsJsonAsync(response);
        }
    }
}
