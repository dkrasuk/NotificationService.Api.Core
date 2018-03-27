using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Serilog;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog.Events;
using Serilog.Sinks.Slack;

namespace NotificationService.Api.Core.Middleware
{
    public class LoggingServiceMiddleware
    {
        private readonly RequestDelegate _next;
        private IConfiguration _configuration { get; set; }
        private readonly ILoggerFactory _logger;

        public LoggingServiceMiddleware(RequestDelegate next, IConfiguration configuration, ILoggerFactory logger)
        {
            _next = next;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            _logger.AddSerilog();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(_configuration)
                ////Send to Slack without appsetings.json
                //.WriteTo.Slack(new SlackSinkOptions
                //{
                //    WebHookUrl = "https://hooks.slack.com/services/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",
                //    CustomChannel = "errorlogs",
                //    Period = TimeSpan.FromSeconds(10),
                //    ShowDefaultAttachments = false,
                //    ShowExceptionAttachments = false,
                //    MinimumLogEventLevel = LogEventLevel.Error
                //})
                .CreateLogger();
            await _next.Invoke(context);
        }
    }
}
