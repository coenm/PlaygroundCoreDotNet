using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using NLog;
using NLog.Extensions.Logging;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using ILogger = NLog.ILogger;

//using SimpleInjector.Integration.AspNetCore.Mvc;


// resource signalr: https://blogs.msdn.microsoft.com/webdev/2017/09/14/announcing-signalr-for-asp-net-core-2-0/

namespace Playground.Start
{
    public class Startup
    {
        private readonly Container _container;
        private readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        public Startup(Container container)
        {
            _container = container;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddJsonOptions(options =>
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());

            //            services.AddSignalR();

            services.AddSwaggerGen(SetupSwagger);

            // Add SimpleInjector Controller Activator
            services.AddSingleton<IControllerActivator>(new SimpleInjectorControllerActivator(_container));
            services.UseSimpleInjectorAspNetRequestScoping(_container);
        }

        private static void SetupSwagger(SwaggerGenOptions options)
        {
            options.SwaggerDoc("v1", new Info
            {
                Title = "Hello CoreCLR Service API",
                Description = "Just a playground...",
                TermsOfService = "None",
                Version = "1"
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // Configure is called after ConfigureServices is called.
        public void Configure(IApplicationBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            //add NLog to ASP.NET Core
            // https://stackoverflow.com/questions/34679727/use-nlog-in-asp-net-core-application
            var loggerFactory = app.ApplicationServices.GetService<ILoggerFactory>();
            loggerFactory.AddNLog();

            var env = app.ApplicationServices.GetService<IHostingEnvironment>();
            Logger.Info("Starting up in {0} mode.", env.EnvironmentName);


            if (env.IsDevelopment())
                UseStaticHosting(app);


            // Add MVC to the request pipeline.
            app.UseMvc();

            // Add SignalR to pipeline.
            //            app.UseSignalR(routes =>
            //            {
            //                routes.MapHub<ChatHub>("chat");
            //            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "1"));
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
