using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Playground.Calculator.MsTest.Test
{
    [TestClass]
    public class StandardCalculatorTest
    {
        [TestMethod]
        public void AdditionTest()
        {
            // arrange
            var logger = new Mock<ILogger>();
            var sut = new StandardCalculator(logger.Object);

            // act
            var result = sut.Add(6, 7);

            // assert
            Assert.AreEqual(13, result);
            logger.Verify(l => l.Log(It.IsAny<string>()), Times.Never);
        }

        [TestMethod]
        public void AdditionWithZerosLogsLineTest()
        {
            // arrange
            var logger = new Mock<ILogger>();
            var sut = new StandardCalculator(logger.Object);

            // act
            var result = sut.Add(0, 0);

            // assert
            Assert.AreEqual(0, result);
            logger.Verify(l => l.Log(It.IsAny<string>()), Times.Once);
        }
    }
}
