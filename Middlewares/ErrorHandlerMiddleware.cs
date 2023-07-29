using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
            catch (DbUpdateException e)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsJsonAsync(
                    new {
                        statusCode = 400,
                        Message = e.InnerException.Message
                    }
                );
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