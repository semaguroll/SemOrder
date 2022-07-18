using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SemOrder.Model.Services.ConfigurationService;
using SemOrder.Model.Services.EnvironmentService;
using System;
using System.Collections.Generic;
using System.Text;

namespace SemOrder.Model.Context
{
    public class DependencyResolver
    {
        public IServiceProvider ServiceProvider { get; }
        public string CurrentDirectory { get; set; }
        public DependencyResolver()
        {
            //Setup Dependency Injection
            IServiceCollection service = new ServiceCollection();
            ConfigureServices(service);
            ServiceProvider = service.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection service)
        {
            //Register env and config services
            service.AddTransient<IEnvironmentService, EnvironmentService>();
            service.AddTransient<IConfigurationService, ConfigurationService>(provider =>
            new ConfigurationService(provider.GetService<IEnvironmentService>())
            {
                CurrentDirectory = this.CurrentDirectory
            });

            //Register DbContext class
            service.AddTransient(provider =>
            {
                var optionBuilder = new DbContextOptionsBuilder<DataContext>();
                var configService = provider.GetService<IConfigurationService>();

                var connectionString = configService.GetConfiguration().GetConnectionString("Conn");
                optionBuilder.UseSqlServer(connectionString, builder => builder.MigrationsAssembly("SemOrder.Model"));
                optionBuilder.EnableSensitiveDataLogging();

                IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();
                return new DataContext(optionBuilder.Options, httpContextAccessor);
            });
        }
    }
}
