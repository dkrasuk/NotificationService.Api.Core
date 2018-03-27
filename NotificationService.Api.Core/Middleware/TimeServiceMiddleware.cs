using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace NotificationService.Api.Core.Middleware
{
    public class TimeServiceMiddleware
    {
        private readonly RequestDelegate _next;

        public TimeServiceMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.Value.ToLower() == "/time" && context.Request.Method.ToLower() == "get")
            {
                await context.Response.WriteAsync($"Time Now: {DateTime.Now}");
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}
