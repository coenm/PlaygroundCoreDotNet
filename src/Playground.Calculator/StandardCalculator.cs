using System;
using System.Threading.Tasks;

namespace Playground.Calculator
{
    public class StandardCalculator 
    {
        private readonly ILogger _logger;

        public StandardCalculator(ILogger logger)
        {
            // check if sonarqube triggers on this piece of code
            var enabled = true;
            _logger = logger;

            if (!enabled)
                _logger = logger;
        }

        public void ThisIsAnUnusedMethod()
        {
            throw new ApplicationException("Never thrown");
        }

        public async Task HeavyCalculation(uint delay)
        {
            await Task.Delay((int)delay);
        }

        public async Task NotSoHeavyCalculation()
        {
            await HeavyCalculation(2);
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
            {
                if (firstNumber != 0)
                {
                    // unreachable code?! check if sonar sees this.
                    return -1;
                }
                return 0;
            }
 

            if (secondNumber == 0)
                return 0;

            var result = Math.BigMul(firstNumber, secondNumber);

            if (result > int.MaxValue)
                return int.MaxValue;

            if (result < int.MinValue)
                return int.MinValue;

            return (int) result;
        }
    }
}
