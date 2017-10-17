using System;
using Xunit;

namespace Playground.Calculator.xUnit.Test
{
    public class StandardCalculatorTest
    {
        [Fact]
        public void AdditionTest()
        {
            // arrange
            var sut = new StandardCalculator();

            // act
            var result = sut.Add(6, 7);

            // assert
            Assert.Equal(13, result);
        }

        [Fact]
        public void AdditionCannotOverflowTest()
        {
            // arrange
            var sut = new StandardCalculator();

            // act
            var result = sut.Add(int.MaxValue, 1);

            // assert
            Assert.Equal(int.MinValue, result);
        }
    }
}
