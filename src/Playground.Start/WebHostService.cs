using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Playground.Start
{
    public class WebHostService
    {
        private readonly IConfiguration configuration;

        public WebHostService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

//        public async Task Run(CancellationToken token)
//        {
//            await Task.Run(async () =>
//            {
//                var buildWebHost = BuildWebHost();
//                await buildWebHost.RunAsync(token);
//
//                var y = 10;
//            }, token);
////            .ContinueWith(t =>
////                Log.Info("Web host {0}", t.Status.Humanize().Transform(To.LowerCase)),
////                    TaskContinuationOptions.None);
//        }

//        private IWebHost BuildWebHost()
//        {
//            var startup = new Startup();
//
//            var builder = new WebHostBuilder()
//                .UseConfiguration(configuration)
////                .UseUrls("http://localhost:5000/")
////                .UseNLog()
//                .UseKestrel()
//                .ConfigureServices(serviceCollection => startup.ConfigureServices(serviceCollection))
//                .Configure(applicationBuilder => startup.Configure(applicationBuilder));
//
//            if (IsDevelopment())
//                ConfigureWebRoot(builder);
//
//            return builder.Build();
//        }

        private static bool IsDevelopment() =>
            Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";

        private static void ConfigureWebRoot(IWebHostBuilder builder)
        {
            var webroot = FindWebRoot();
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