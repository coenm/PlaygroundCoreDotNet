using System;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Playground.Start
{
    class Program
    {
        // Entry point for the application.
        public static void Main(string[] args)
        {
            RegisterComponents();
              BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls("http://localhost:5000")
                .Build();
        

        private static void RegisterComponents()
        {
            BuildConfiguration();
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();
        }

        private static async Task RunWebHostService(CancellationToken token)
        {
//            await Container.GetInstance<WebHostService>().Run(token);
        }
    }
}
