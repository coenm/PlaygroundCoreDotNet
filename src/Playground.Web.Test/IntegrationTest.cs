namespace Playground.Web.Test
{
    using System;
    using System.Threading.Tasks;

    using FakeItEasy;

    using Microsoft.AspNetCore.TestHost;
    using Microsoft.Extensions.Configuration;

    using Playground.Calculator;

    using SimpleInjector;

    using Xunit;

    public class IntegrationTest
    {
        private readonly Container _container;
        private readonly IConfiguration _configuration;

        public IntegrationTest()
        {
            _container = new Container();
            _configuration = new ConfigurationBuilder().Build();
        }

        [Fact]
        public async Task VerifyWebApiIsAvailableByUrlTest()
        {
            // arrange
            var dateTimeProvider = A.Fake<IDateTimeProvider>();
            A.CallTo(() => dateTimeProvider.Now).Returns(new DateTime(2017, 2, 4, 6, 8, 10));
            _container.RegisterSingleton(dateTimeProvider);
            var webhostService = new FakeWebHostService(_configuration, _container);
            var hostBuilder = webhostService.CreateWebHostBuilder();

            using (var server = new TestServer(hostBuilder))
            {
                // act
                var response = await server.CreateRequest("/api/sayhelloworld/test").SendAsync("GET");

                // assert
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                Assert.Equal("060810 test", content);
            }
        }
    }
}