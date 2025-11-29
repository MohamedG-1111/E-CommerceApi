
using E_Commerce.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Api.Middleware
{
    public class GlobalExceptionMiddleware 
    {
        private readonly RequestDelegate next;
        private readonly ILogger<GlobalExceptionMiddleware> logger;

        public GlobalExceptionMiddleware(RequestDelegate next,ILogger<GlobalExceptionMiddleware>logger)
        {
            this.next = next;
            this.logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next.Invoke(context);
                await NotFoundEndPointAsync(context);
            }
            catch (Exception ex)
            {

                logger.LogError(ex.Message); // Logging

                var problem = new ProblemDetails()
                {
                    Title = "UnExcepted Error",
                    Detail = ex.Message,
                    Instance = context.Request.Path,
                     Status = ex switch
                     {
                         NotFoundException => StatusCodes.Status404NotFound,
                         _ => StatusCodes.Status500InternalServerError,
                     }

                };
                context.Response.StatusCode = problem.Status.Value;

                // write response
                await context.Response.WriteAsJsonAsync(problem);
            }

        }

        private static async Task NotFoundEndPointAsync(HttpContext context)
        {
            if (context.Response.StatusCode == StatusCodes.Status404NotFound)
            {
                var Problem = new ProblemDetails()
                {
                    Title = "Error The Request Processing ,Not found",
                    Instance = context.Request.Path,
                    Detail = $"{context.Request.Path} Not Found",
                    Status = StatusCodes.Status404NotFound,

                };
                await context.Response.WriteAsJsonAsync(Problem);
            }
        }
    }
}
