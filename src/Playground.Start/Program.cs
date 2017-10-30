using System;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using NLog;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace Playground.Start
{
    class Program
    {
        private static readonly Container Container = new Container();
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        // Entry point for the application.
        public static void Main(string[] args)
        {
            RegisterComponents();
            LogVersion();
            Task.Run(() => RunWebHostService(CancellationToken.None));

            Console.ReadKey();
        }

        private static void RegisterComponents()
        {
            Logger.Info("Setup application components.");

            Container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            Container.RegisterSingleton<IConfiguration>(BuildConfiguration());
            Container.RegisterSingleton<WebHostService>();

            Container.Verify();
        }

        private static void LogVersion()
        {
            Logger.Info("{0} {1}", Assembly.GetEntryAssembly().GetName().Name,Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion);
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
            await Container.GetInstance<WebHostService>().Run(token);
        }
    }
}
