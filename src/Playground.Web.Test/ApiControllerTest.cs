using System;
using System.Net;
using System.Threading.Tasks;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Playground.Calculator;
using Playground.Web.Api;
using Xunit;

namespace Playground.Web.Test
{
    public class ApiControllerTest
    {
        [Fact]
        public async Task SayHelloWorldShouldReplayMessageWithCurrentTimePrefixedTest()
        {
            // arrange
            var dateTimeProvider = A.Fake<IDateTimeProvider>();
            A.CallTo(() => dateTimeProvider.Now).Returns(new DateTime(2000, 1, 1, 12, 44, 30));
            var sut = new ApiController(dateTimeProvider);

            // act
            var result = await sut.SayHelloWorldAsync("test") as OkObjectResult;

            // assert
            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);

            var resultString = result.Value as string;
            Assert.NotNull(resultString);
            Assert.Equal("124430 test", resultString);
        }
    }
}
