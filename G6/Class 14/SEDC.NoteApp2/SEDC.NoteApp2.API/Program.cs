using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using System;

namespace SEDC.NoteApp2.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .MinimumLevel.Information()
                .WriteTo.File(
                $@"{AppDomain.CurrentDomain.BaseDirectory}Logs\Note-Log-{DateTime.UtcNow.Date:dd-MM-yyyy}.log",
                LogEventLevel.Information,
                "{NewLine}{Timestamp:HH:mm:ss} [{Level}] {Message} {Exception}"
                )
                .CreateLogger();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
