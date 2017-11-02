using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using SimpleInjector;

namespace Playground.Web.Test
{
    class FakeWebHostService : WebHostService
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