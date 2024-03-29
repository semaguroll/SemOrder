﻿using Microsoft.Extensions.Configuration;
using SemOrder.Model.Services.EnvironmentService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SemOrder.Model.Services.ConfigurationService
{
    public class ConfigurationService : IConfigurationService
    {
        private IEnvironmentService _env { get; }
        public string CurrentDirectory { get; set; }
        public ConfigurationService(IEnvironmentService env)
        {
            _env = env;
        }
        public IConfiguration GetConfiguration()
        {
            CurrentDirectory = CurrentDirectory ?? Directory.GetCurrentDirectory();
            return new ConfigurationBuilder()
                .SetBasePath(CurrentDirectory)
                .AddJsonFile("appsettings.json", reloadOnChange: true, optional: true)
                .AddJsonFile($"appsettings.{_env.EnvironmentName}.json", reloadOnChange: true, optional: true)
                .AddEnvironmentVariables()
                .Build();
        }
    }
}
