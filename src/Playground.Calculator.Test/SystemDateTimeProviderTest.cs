using System;
using Xunit;

namespace Playground.Calculator.Test
{
    public class SystemDateTimeProviderTest
    {
        /// <summary>
        /// Pretty lame test whether result is almost equal to the System.DateTime.Now
        /// </summary>
        [Fact]
        public void SystemDateTimeProviderNowShouldReturnSystemNowTest()
        {
            // arrange
            var sut = SystemDateTimeProvider.Instance;

            // act
            var resultA = sut.Now;
            var resultB = DateTime.Now;

            // assert
            var diff = resultB - resultA;
            Assert.InRange(diff.TotalSeconds, 0, 1);
        }
    }
}