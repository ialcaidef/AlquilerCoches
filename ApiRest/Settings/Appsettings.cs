using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ApiRest.Settings
{
    public class Appsettings
    {

        private static string _LogFolder = string.Empty;
        private static string _AppName = string.Empty;

        public static string LogFolder
        {
            get => _LogFolder;
        }
        public static string AppName
        {
            get => _AppName;
        }

        public static void ConfigureApp()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("./Settings/appsettings.json", optional: false, reloadOnChange: true);
            IConfiguration configuration = builder.Build();
            configuration = builder.Build();
            
            _LogFolder = configuration["LogFolder"];
            _AppName = configuration["AppName"];
        }
        
    }
}
