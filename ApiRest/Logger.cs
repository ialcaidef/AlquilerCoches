using System;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;


namespace ApiRest
{
    public static class Logger
    {
        public static void CreateLogger(string pathLog, string appName)
        {
            string logTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u}] [{Properties:j}] {Message}{NewLine}{Exception}";
            var dateTime = DateTime.Now;
            string dateString = dateTime.ToString("dd-MM-yyyy");

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                 .Enrich.WithProperty("Application", appName)
                .WriteTo.Logger(
                    x => x.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Information)
                        .WriteTo.Console(theme: AnsiConsoleTheme.Code, outputTemplate: logTemplate)
                )
                .WriteTo.Logger(
                    x => x.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Error)
                        .WriteTo.Console(theme: AnsiConsoleTheme.Code, outputTemplate: logTemplate)
                )
                .WriteTo.Logger(
                    x => x.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Information)
                        .WriteTo.File($"{pathLog}/Info-{dateString}.log", outputTemplate: logTemplate)
                )
                .WriteTo.Logger(
                    x => x.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Error)
                        .WriteTo.File($"{pathLog}/Error-{dateString}.log", outputTemplate: logTemplate)
                )
                .WriteTo.Logger(
                    x => x.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Fatal)
                        .WriteTo.File($"{pathLog}/Fatal-{dateString}.log", outputTemplate: logTemplate)
                )
                .CreateLogger();
        }

        private static void SetupStaticLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("log.txt", LogEventLevel.Fatal, rollingInterval: RollingInterval.Day, retainedFileCountLimit: 10)
                .CreateLogger();
        }
    }
}
