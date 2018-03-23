using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NotificationService.Api.Core.Services;
using NotificationService.Api.Core.Services.Interfaces;
using NotificationService.Repository.Context;
using NotificationService.Repository.Repositories;
using NotificationService.Shared.Data;
using NotificationService.Shared.Repositories;
using Serilog;
using Swashbuckle.AspNetCore.Swagger;
using Serilog.Events;
using Serilog.Sinks.Slack;


namespace NotificationService.Api.Core
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var sqlConnectionString = Configuration.GetConnectionString("NotificationConnectionStrings");
            services.AddDbContext<NotificationContext>(options => options.UseNpgsql(sqlConnectionString
                , x => x.MigrationsHistoryTable("__EFMigrationsHistory", "Notification")
                ).EnableSensitiveDataLogging());
            services.AddMvc();
            services.AddLogging();

            services.AddTransient<INotificationContext, NotificationContext>();
            services.AddTransient<INotificationRepository<Notification>, NotificationRepository>();
            services.AddTransient<INotificationService, Services.NotificationService>();
            services.AddTransient<ISmtpService, SmtpService>();

            //Add Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Notification API", Version = "v1" });
                c.CustomSchemaIds(x => x.FullName);
            });

            //Add AutoMApper
            services.AddAutoMapper();
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Notification, Shared.DTO.Notification>();
                cfg.CreateMap<Shared.DTO.Notification, Notification>();
            });
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            

            //Connect Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Notification API V1");
            });


            //Connect SeriLog with appsetings.json   
            logger.AddSerilog();
            var configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)

                //Send to Slack without appsetings.json
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
        }
    }
}
