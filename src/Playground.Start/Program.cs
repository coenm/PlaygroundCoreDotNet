using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Playground.Web;

namespace Playground.Start
{
    class Program
    {
        private static IConfigurationBuilder _configurationBuilder;

        // Entry point for the application.
        public static void Main(string[] args)
        {
            _configurationBuilder = new ConfigurationBuilder()
                .AddCommandLine(args)
                .AddEnvironmentVariables()
                .AddJsonFile("appsettings.json");


            RunWebHostService(CancellationToken.None).GetAwaiter().GetResult();
        }

        private static async Task RunWebHostService(CancellationToken token)
        {
            var webhost = new WebHostService(_configurationBuilder.Build());
            await webhost.RunAsync(token);
        }
    }
}
