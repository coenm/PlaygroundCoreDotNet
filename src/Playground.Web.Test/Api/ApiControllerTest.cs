namespace Playground.Web.Test.Api
{
    using System;
    using System.Net;
    using System.Threading.Tasks;

    using FakeItEasy;

    using Microsoft.AspNetCore.Mvc;

    using Playground.Calculator;
    using Playground.Web.Api;

    using Xunit;

    public class ApiControllerTest
    {
        private readonly ApiController _sut;

        public ApiControllerTest()
        {
            var dateTimeProvider = A.Fake<IDateTimeProvider>();
            A.CallTo(() => dateTimeProvider.Now).Returns(new DateTime(2000, 1, 1, 12, 44, 30));
            _sut = new ApiController(dateTimeProvider);
        }

        [Fact]
        public async Task SayHelloWorldShouldReplayMessageWithCurrentTimePrefixedTest()
        {
            // arrange

            // act
            var result = await _sut.SayHelloWorldAsync("test") as OkObjectResult;

            // assert
            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
            Assert.Equal("124430 test", (string)result.Value);
        }


        [Fact]
        public async Task GetTotalNumberOfGreetingsAsyncTest()
        {
            // arrange

            // act
            var result = await _sut.GetTotalNumberOfGreetingsAsync() as OkObjectResult;

            // assert
            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
            Assert.Equal(2, (int)result.Value);
        }
    }
}
