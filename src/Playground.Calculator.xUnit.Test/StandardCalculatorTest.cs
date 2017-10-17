using FakeItEasy;
using Xunit;

namespace Playground.Calculator.xUnit.Test
{
    public class StandardCalculatorTest
    {
        [Fact]
        public void AdditionTest()
        {
            // arrange
            var logger = A.Fake<ILogger>();
            var sut = new StandardCalculator(logger);

            // act
            var result = sut.Add(6, 7);

            // assert
            Assert.Equal(13, result);
            A.CallTo(() => logger.Log(A<string>._)).MustNotHaveHappened();
        }

        [Fact]
        public void AdditionCannotOverflowTest()
        {
            // arrange
            var sut = new StandardCalculator(null);

            // act
            var result = sut.Add(int.MaxValue, 1);

            // assert
            Assert.Equal(int.MinValue, result);
        }


        [Fact]
        public void AdditionWithLogLineTest()
        {
            // arrange
            var logger = A.Fake<ILogger>();
            var sut = new StandardCalculator(logger);

            // act
            var result = sut.Add(0, 0);

            // assert
            Assert.Equal(0, result);
            A.CallTo(() => logger.Log(A<string>._)).MustHaveHappened(Repeated.Exactly.Once);
        }
    }
}
