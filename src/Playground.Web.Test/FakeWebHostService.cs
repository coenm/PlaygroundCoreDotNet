namespace Playground.Web.Test
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;

    using SimpleInjector;

    internal class FakeWebHostService : WebHostService
    {
        public FakeWebHostService(IConfiguration configuration, Container container) : base(configuration, container)
        {
        }

        public IWebHostBuilder CreateWebHostBuilder()
        {
            return ConstructWebHostBuilder();
        }
    }
}