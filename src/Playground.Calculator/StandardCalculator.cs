using System;

namespace Playground.Calculator
{

    public interface ILogger
    {
        void Log(string message);
    }

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
    }
}
