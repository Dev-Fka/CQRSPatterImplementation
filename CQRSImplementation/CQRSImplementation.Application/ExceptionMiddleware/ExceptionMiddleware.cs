using CQRSImplementation.Application.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;

namespace AspNetApiPractice.Application.ExceptionMiddleware
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

        private static Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            if ((ex is TimesNotAvaibleException) || (ex is IsNotApprovedException))
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }

            return httpContext.Response.WriteAsync(JsonConvert.SerializeObject(new
            {

                StatusCode = httpContext.Response.StatusCode,
                Value = ex.Message
            }));
        }

    }
}