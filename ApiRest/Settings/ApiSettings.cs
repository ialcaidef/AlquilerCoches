using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ApiRest.Settings
{
    public class ApiSettings
    {

        private static string _LogFolder = string.Empty;
        private static string _AppName = string.Empty;

        private static double _PrecioDiaPremium = 0;
        private static double _PrecioDiaSuv = 0;
        private static double _PrecioDiaLittle = 0;

        private static double _PorcIncDiaExtraPremium = 0;
        private static double _PorcIncDiaExtraSuv = 0;
        private static double _PorcIncDiaExtraLittle = 0;

        private static double _PtosFidelidadPremium = 0;
        private static double _PtosFidelidadSuv = 0;
        private static double _PtosFidelidadLittle = 0;


        public static string LogFolder
        {
            get => _LogFolder;
        }
        public static string AppName
        {
            get => _AppName;
        }

        public static double PrecioDiaPremium
        {
            get => _PrecioDiaPremium;
        }

        public static double PrecioDiaSuv
        {
            get => _PrecioDiaSuv;
        }

        public static double PrecioDiaLittle
        {
            get => _PrecioDiaLittle;
        }

        public static double PorcIncDiaExtraPremium
        {
            get => _PorcIncDiaExtraPremium;
        }
        public static double PorcIncDiaExtraSuv
        {
            get => _PorcIncDiaExtraSuv;
        }
        public static double PorcIncDiaExtraLittle
        {
            get => _PorcIncDiaExtraLittle;
        }

        public static double PtosFidelidadPremium
        {
            get => _PtosFidelidadPremium;
        }
        public static double PtosFidelidadSuv
        {
            get => _PtosFidelidadSuv;
        }
        public static double PtosFidelidadLittle
        {
            get => _PtosFidelidadLittle;
        }



        public static void ConfigureApp()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("./Settings/ApiSettings.json", optional: false, reloadOnChange: true);
            IConfiguration configuration = builder.Build();
            configuration = builder.Build();
            
            _LogFolder = configuration["LogFolder"];
            _AppName = configuration["AppName"];

            _PrecioDiaPremium = double.Parse(configuration["PrecioDiaPremium"]);
            _PrecioDiaSuv = double.Parse(configuration["PrecioDiaSuv"]);
            _PrecioDiaLittle = double.Parse(configuration["PrecioDiaLittle"]);

            _PorcIncDiaExtraPremium = double.Parse(configuration["PorcIncDiaExtraPremium"]);
            _PorcIncDiaExtraSuv = double.Parse(configuration["PorcIncDiaExtraSuv"]);
            _PorcIncDiaExtraLittle = double.Parse(configuration["PorcIncDiaExtraLittle"]);

            _PtosFidelidadPremium = double.Parse(configuration["PtosFidelidadPremium"]);
            _PtosFidelidadSuv = double.Parse(configuration["PtosFidelidadSuv"]);
            _PtosFidelidadLittle = double.Parse(configuration["PtosFidelidadLittle"]);
        }
        
    }
}
