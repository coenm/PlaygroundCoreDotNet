using FakeItEasy;
using Xunit;

namespace Playground.Calculator.xUnit.Test
{
    public class StandardCalculatorTest
    {
        private readonly ILogger _logger;
        private readonly StandardCalculator _sut;

        public StandardCalculatorTest()
        {
            _logger = A.Fake<ILogger>();
            _sut = new StandardCalculator(_logger);
        }


        [Fact]
        public void AdditionTest()
        {
            // arrange

            // act
            var result = _sut.Add(6, 7);

            // assert
            Assert.Equal(13, result);
            A.CallTo(() => _logger.Log(A<string>._)).MustNotHaveHappened();
        }

        [Fact]
        public void AdditionCannotOverflowTest()
        {
            // arrange

            // act
            var result = _sut.Add(int.MaxValue, 1);

            // assert
            Assert.Equal(int.MinValue, result);
        }


        [Fact]
        public void AdditionWithLogLineTest()
        {
            // arrange

            // act
            var result = _sut.Add(0, 0);

            // assert
            Assert.Equal(0, result);
            A.CallTo(() => _logger.Log(A<string>._)).MustHaveHappened(Repeated.Exactly.Once);
        }

        [Fact]
        public void MultiplyTest()
        {
            // arrange

            // act
            var result = _sut.Multiply(0, 0);

            // assert
            Assert.Equal(42, result);
        }
    }
}
