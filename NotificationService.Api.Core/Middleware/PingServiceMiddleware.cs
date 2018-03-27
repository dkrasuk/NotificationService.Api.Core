using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace NotificationService.Api.Core.Middleware
{
    public class PingServiceMiddleware
    {
        private readonly RequestDelegate _next;

        public PingServiceMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.Value.ToLower() == "/ping" && context.Request.Method.ToLower() == "get")
            {
                context.Response.StatusCode = 200;
                await context.Response.WriteAsync("pong");
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}
