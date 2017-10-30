using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using NLog;
using NLog.Web;
using SimpleInjector;

namespace Playground.Start
{
    public class WebHostService
    {
        private readonly IConfiguration configuration;
        private readonly Container container;
        private static readonly ILogger Log = LogManager.GetCurrentClassLogger();

        public WebHostService(IConfiguration configuration, Container container)
        {
            this.configuration = configuration;
            this.container = container;
        }

        public async Task Run(CancellationToken token)
        {
            await Task.Run(async () =>
            {
                Log.Info("Starting Web host.");

                var buildWebHost = BuildWebHost();
                await buildWebHost.RunAsync(token);

                var y = 10;
            }, token);
//            .ContinueWith(t =>
//                Log.Info("Web host {0}", t.Status.Humanize().Transform(To.LowerCase)),
//                    TaskContinuationOptions.None);
        }

        private IWebHost BuildWebHost()
        {
            var startup = new Startup(container);

            var builder = new WebHostBuilder()
                .UseConfiguration(configuration)
//                .UseUrls("http://localhost:5000/")
//                .UseNLog()
                .UseKestrel()
                .ConfigureServices(serviceCollection => startup.ConfigureServices(serviceCollection))
                .Configure(applicationBuilder => startup.Configure(applicationBuilder));

            if (IsDevelopment())
                ConfigureWebRoot(builder);

            return builder.Build();
        }

        private static bool IsDevelopment() =>
            Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";

        private static void ConfigureWebRoot(IWebHostBuilder builder)
        {
            var webroot = FindWebRoot();
            Log.Warn("Running in Development environment, hosting static files from '{0}'.", webroot);
            builder.UseWebRoot(webroot);
        }

        private static string FindWebRoot()
        {
            var cwd = new FileInfo(Assembly.GetEntryAssembly().Location).DirectoryName;
            var webroot = Path.Combine(cwd, "..", "..", "..", "..", "..", "ui", "wwwroot");
            return Path.GetFullPath(webroot);
        }
    }
}