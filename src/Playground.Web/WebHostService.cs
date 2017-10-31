using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Playground.Web
{
    public class WebHostService
    {
        private readonly IConfiguration _configuration;

        public WebHostService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task RunAsync(CancellationToken token)
        {
            await BuildWebHost().RunAsync(token);
        }

        private IWebHost BuildWebHost()
        {
            var startup = new Startup(_configuration);
            var builder = new WebHostBuilder()
                .UseConfiguration(_configuration)
                .UseKestrel()
                .UseIISIntegration()
                .ConfigureServices(serviceCollection => startup.ConfigureServices(serviceCollection))
                .Configure(applicationBuilder => startup.Configure(applicationBuilder));

//            if (IsDevelopment())
            ConfigureWebRoot(builder);

            return builder.Build();
        }

        private static bool IsDevelopment()
        {
            try
            {
                return Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static void ConfigureWebRoot(IWebHostBuilder builder)
        {
            var webroot = FindWebRoot();
            builder.UseWebRoot(webroot);
        }

        private static string FindWebRoot()
        {
            var cwd = Directory.GetCurrentDirectory();
//            var cwd = new FileInfo(Assembly.GetEntryAssembly().Location).DirectoryName;
//            var webroot = Path.Combine(cwd, "..", "..", "..", "..", "..", "ui", "wwwroot");
            var webroot = Path.Combine(cwd, "wwwroot");
            return Path.GetFullPath(webroot);
        }
    }
}