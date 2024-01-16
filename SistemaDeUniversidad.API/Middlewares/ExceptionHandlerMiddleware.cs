using System.Text.Json;
using SistemaDeUniversidad.Contracts.Exceptions;

namespace SistemaDeUniversidad.API.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context); 
            }            
            catch (BadRequestExceptionMW ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = ex.Code;

                await context.Response.WriteAsync((new ErrorDetails(ex.Message, ex.Code)).ToString());
            }
            catch (KeyNotFoundExceptionMW ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = ex.Code;

                await context.Response.WriteAsync((new ErrorDetails(ex.Message, ex.Code)).ToString());
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync((new ErrorDetails(ex.Message, 500)).ToString());
            }
        }       
    }

    class ErrorDetails
    {
        public string Message { get; set; }
        public int Code { get; set; }

        public ErrorDetails(string message, int code)
        {
            Message = message;
            Code = code;
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}

