using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProject.Middlewares
{
    public class ErrorHandlerMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            /* client request -> error handler (routing -> controller -> ...) */
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(
                    new {
                        statusCode = 500,
                        Message = e.Message
                    }
                );
            }
        }
    }
}