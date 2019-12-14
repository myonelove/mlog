using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models; 
using MLog.Api.Models.Middleware;
using MLog.Api.Services;
using MLog.Api.Websockets;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.Swagger; 

namespace MLog.Api
{
    /// <summary>
    /// Startup
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Startup
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param> 
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(); 
            services.AddDistributedMemoryCache();
            services.AddSwaggerSevice(); 
            services.AddJwtService(Configuration);
            services.AddMongoClientService(Configuration); 
            services.AddSingleton(typeof(UserService));
            services.AddSignalR();
             
            services.AddCors(option=>option.AddPolicy("cors",
                policy=> policy
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
                .WithOrigins("http://127.0.0.1:8080")));

            services.AddHostedService<RabbitMQWorker>(); //添加rabbitmq 后台工作
            services.AddHostedService<WebSocketWorker>(); //添加websocket 后台工作
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param> 
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
             
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
             
            app.UseCors("cors");
             
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "log manager system api v1");
            });
        }
    }
}
