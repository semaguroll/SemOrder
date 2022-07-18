using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SemOrder.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SemOrder.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IConfigurationRoot Configuration { get; }
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                              .SetBasePath(env.ContentRootPath)
                              .AddJsonFile("appsettings.json", reloadOnChange: true, optional: true)
                              .AddJsonFile($"appsettings.{env.EnvironmentName}.json", reloadOnChange: true, optional: true)
                              .AddEnvironmentVariables();
            Configuration = builder.Build();

        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IConfiguration>(Configuration);

            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:Conn"]);
            });

            //Add AutoMapper
            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}