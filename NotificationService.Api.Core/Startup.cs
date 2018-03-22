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
using NotificationService.Repository.Context;
using NotificationService.Repository.Repositories;
using NotificationService.Shared.Data;
using NotificationService.Shared.Repositories;
using Swashbuckle.AspNetCore.Swagger;

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
            services.AddAutoMapper();
            services.AddLogging();

            // services.AddTransient<Func<INotificationContext>>(s => () => new NotificationContext());
            services.AddTransient<INotificationContext, NotificationContext>();
            services.AddTransient<INotificationRepository<Notification>, NotificationRepository>();
            services.AddTransient<Services.NotificationService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Notification API", Version = "v1" });
                c.CustomSchemaIds(x=>x.FullName);
            });

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Notification, Shared.DTO.Notification>();
                cfg.CreateMap<Shared.DTO.Notification, Notification>();
            });
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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

          
           
        }
    }
}
