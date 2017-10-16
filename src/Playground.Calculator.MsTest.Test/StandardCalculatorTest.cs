using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Playground.Calculator.Test
{
    [TestClass]
    public class StandardCalculatorTest
    {
        [TestMethod]
        public void AdditionTest()
        {
            // arrange
            var sut = new StandardCalculator();

            // act
            var result = sut.Add(6, 7);

            // assert
            Assert.AreEqual(result, 13);
        }
    }
}
