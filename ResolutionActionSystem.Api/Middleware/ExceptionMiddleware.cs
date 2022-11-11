using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ResolutionActionSystem.Application.Exceptions;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ResolutionActionSystem.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpcontext)
        {
            try
            {
                await _next(httpcontext);
            }
            catch(Exception ex)
            {
                await HandleExceptionAsync(httpcontext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
           context.Response.ContentType = "application/json";

            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;

            string result = JsonConvert.SerializeObject(new ErrorDetails  
            {
                ErrorMessage = exception.Message, 
                ErrorType ="Failure" 
            });

            switch (exception)
            {
                case BadRequestException BadRequestException:
                    statusCode = HttpStatusCode.BadRequest;
                    break;
                case ValidationException validationException:
                    statusCode = HttpStatusCode.BadRequest;
                    result = JsonConvert.SerializeObject(validationException.Errors);
                    break;
                case NotFoundException notFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    break;
                default:
                    break;
            }

            context.Response.StatusCode = (int)statusCode;
            return context.Response.WriteAsync(result);

        }

        public class ErrorDetails
        {
            public string ErrorType { get; set; }
            public string ErrorMessage { get; set; }
        }
    }
}
