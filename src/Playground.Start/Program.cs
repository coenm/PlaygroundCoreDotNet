using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Playground.Web;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using Playground.Calculator;

namespace Playground.Start
{
    class Program
    {
        private static IConfigurationBuilder _configurationBuilder;
        private static readonly Container Container = new Container();

        // Entry point for the application.
        public static void Main(string[] args)
        {
            _configurationBuilder = new ConfigurationBuilder()
                .AddCommandLine(args)
                .AddEnvironmentVariables()
                .AddJsonFile("appsettings.json");

            SetupResources(_configurationBuilder.Build());

            RunWebHostService(CancellationToken.None).GetAwaiter().GetResult();
        }

        private static void SetupResources(IConfiguration configuration)
        {
            // todo check what this means.
            Container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            Container.RegisterSingleton(configuration);
//            Container.RegisterSingleton(Container);
            Container.RegisterSingleton<WebHostService>();
            Container.RegisterSingleton<IDateTimeProvider>(SystemDateTimeProvider.Instance);
            Container.Verify();

        }

        private static async Task RunWebHostService(CancellationToken token)
        {
            var webhost = Container.GetInstance<WebHostService>();
//            var webhost = new WebHostService(_configurationBuilder.Build());
            await webhost.RunAsync(token);
        }
    }
}
