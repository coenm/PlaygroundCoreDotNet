using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Playground.Web.Hub;
using SimpleInjector;


using Microsoft.AspNetCore.Mvc.Controllers;
using SimpleInjector.Integration.AspNetCore.Mvc;

// resource signalr: https://blogs.msdn.microsoft.com/webdev/2017/09/14/announcing-signalr-for-asp-net-core-2-0/

namespace Playground.Web
{
    public class Startup
    {
        private IConfiguration _configuration;
        private readonly Container _container;

        public Startup(IConfiguration configuration, Container container)
        {
            _configuration = configuration;
            _container = container;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDirectoryBrowser();

            services.AddMvc();

            services.AddSignalR();

            IntegrateSimpleInjector(services);
        }

        // see https://simpleinjector.readthedocs.io/en/latest/aspnetintegration.html
        private void IntegrateSimpleInjector(IServiceCollection services)
        {
            // services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton<IControllerActivator>(new SimpleInjectorControllerActivator(_container));
//            services.AddSingleton<IViewComponentActivator>(new SimpleInjectorViewComponentActivator(container));

//            services.EnableSimpleInjectorCrossWiring(container);
            services.UseSimpleInjectorAspNetRequestScoping(_container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // Configure is called after ConfigureServices is called.
        public void Configure(IApplicationBuilder app)
        {
            //            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            //
            ////            //add NLog to ASP.NET Core
            ////            // https://stackoverflow.com/questions/34679727/use-nlog-in-asp-net-core-application
            ////            var loggerFactory = app.ApplicationServices.GetService<ILoggerFactory>();
            ////            loggerFactory.AddNLog();
            //
            var env = app.ApplicationServices.GetService<IHostingEnvironment>();
            //Logger.Info("Starting up in {0} mode.", env.EnvironmentName);
            
            if (env.IsDevelopment())
                UseStaticHosting(app);
            else //todo
                UseStaticHosting(app);

            // Add SignalR to pipeline.
            app.UseSignalR(routes =>
            {
                routes.MapHub<MonitorHub>("monitor");
            });

            // Add MVC to the request pipeline.
            app.UseMvc();
        }


        private static void UseStaticHosting(IApplicationBuilder app)
        {
            // Serve the default file, if present.
            app.UseDefaultFiles();

            // Add static files to the request pipeline.
            app.UseStaticFiles();
            app.UseDirectoryBrowser();


//            app.UseStaticFiles(); // For the wwwroot folder

//            app.UseStaticFiles(new StaticFileOptions
//            {
//                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot")),
//                RequestPath = new PathString("/")
//            });
//
//            app.UseDirectoryBrowser(new DirectoryBrowserOptions
//            {
//                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot")),
//                RequestPath = new PathString("/")
//            });
        }
    }
}
