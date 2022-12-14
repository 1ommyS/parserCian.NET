using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ParserServer.Scheduler;

namespace ParserServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            // using (var scope = host.Services.CreateScope())
            // {
            //     var serviceProvider = scope.ServiceProvider;
            //     try
            //     {
            //         ParsingScheduler.Start(serviceProvider);
            //     }
            //     catch (Exception)
            //     {
            //         throw;
            //     }
            // }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel(options =>
                    {
                        options.AddServerHeader = false;
                        options.Listen(IPAddress.Any, 80);
                        options.Listen(IPAddress.Any, 443);
                    });
                    webBuilder.UseStartup<Startup>();
                });
    }
}