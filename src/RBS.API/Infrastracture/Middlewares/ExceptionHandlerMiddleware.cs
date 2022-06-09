using Newtonsoft.Json;
using RBS.Application.Exceptions;

namespace RBS.API.Infrastracture.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (BaseException ex)
            {
                await HandleBaseExceptionAsync(context, ex);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleBaseExceptionAsync(HttpContext context, BaseException ex)
        {
            var error = ex.ApiError;
            var result = JsonConvert.SerializeObject(error);

            context.Response.Clear();
            context.Response.ContentType = "application/json";
#pragma warning disable CS8629 // Nullable value type may be null.
            context.Response.StatusCode = error.Status.Value;
#pragma warning restore CS8629 // Nullable value type may be null.

            await context.Response.WriteAsync(result);
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var error = new ApiError
            {
                Status = 500
            };
            var result = JsonConvert.SerializeObject(error);

            context.Response.Clear();
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = error.Status.Value;

            await context.Response.WriteAsync(result);
        }
    }
}
