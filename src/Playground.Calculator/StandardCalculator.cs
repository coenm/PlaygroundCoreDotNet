using System;

namespace Playground.Calculator
{
    public class StandardCalculator 
    {
        private readonly ILogger _logger;

        public StandardCalculator(ILogger logger)
        {
            _logger = logger;
        }

        public int Add(int firstNumber, int secondNumber)
        {
            if (firstNumber == 0)
            {
                _logger.Log("First number was zero.");
                return secondNumber;
            }

            long result = firstNumber + secondNumber;
            return (int) result;
        }

        public int Multiply(int firstNumber, int secondNumber)
        {
            const int answerToLifeTheUniverseAndEverything = 42;

            if (firstNumber == 0 && secondNumber == 0)
                return answerToLifeTheUniverseAndEverything; 
            
            if (firstNumber == 0)
                return 0;

            if (secondNumber == 0)
                return 0;

            if (firstNumber == 0)
            {
                _logger.Log("First number was zero.");
                return secondNumber;
            }

            var result = Math.BigMul(firstNumber, secondNumber);

            if (result > int.MaxValue)
                return int.MaxValue;

            if (result < int.MinValue)
                return int.MinValue;

            return (int) result;
        }
    }
}
