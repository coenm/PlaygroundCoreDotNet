using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

// resource signalr: https://blogs.msdn.microsoft.com/webdev/2017/09/14/announcing-signalr-for-asp-net-core-2-0/

namespace Playground.Start
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddSignalR();


            // Add SimpleInjector Controller Activator
//            services.AddSingleton<IControllerActivator>(new SimpleInjectorControllerActivator(_container));
//            services.UseSimpleInjectorAspNetRequestScoping(_container);
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
//            var env = app.ApplicationServices.GetService<IHostingEnvironment>();
////            Logger.Info("Starting up in {0} mode.", env.EnvironmentName);
//
//
//            if (env.IsDevelopment())
//                UseStaticHosting(app);
//
//
//            // Add MVC to the request pipeline.
//            app.UseMvc();
//
//            // Add SignalR to pipeline.
//            //            app.UseSignalR(routes =>
//            //            {
//            //                routes.MapHub<ChatHub>("chat");
//            //            });




            app.UseStaticFiles();

            app.UseSignalR(routes =>
            {
                routes.MapHub<Chat>("chat");
            });

            app.UseMvc();
        }


        private static void UseStaticHosting(IApplicationBuilder app)
        {
            // Serve the default file, if present.
            app.UseDefaultFiles();

            // Add static files to the request pipeline.
            app.UseStaticFiles();
        }
    }
}
