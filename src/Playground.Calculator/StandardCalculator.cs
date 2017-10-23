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
            // check if sonarqube sees commented code. 

            // HeavyCalculation(23).GetAwaiter().GetResult();

            throw new ApplicationException("Never thrown");
        }

        public async Task HeavyCalculation(uint delay)
        {
            // add some great code to see what sonarqube thinks of this.


            try
            {
                if (delay == 1)
                    await Task.Delay(1);
                else if (delay == 2)
                    await Task.Delay(2);
                else if (delay == 3)
                    await Task.Delay(3);
                else if (delay == 4)
                    await Task.Delay(4);
                else if (delay == 5)
                    await Task.Delay(5);
                else if (delay == 6)
                    await Task.Delay(6);
                else
                    await Task.Delay((int)delay);
            }
            catch (Exception e)
            {
                
            }
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
