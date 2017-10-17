using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Playground.Calculator.MsTest.Test
{
    [TestClass]
    public class StandardCalculatorTest
    {
        [TestMethod]
        public void AdditionTest()
        {
            // arrange
            var sut = new StandardCalculator(null);

            // act
            var result = sut.Add(6, 7);

            // assert
            Assert.AreEqual(13, result);
        }
    }
}
