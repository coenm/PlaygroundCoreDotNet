using System;

namespace Playground.Calculator
{
    public class StandardCalculator 
    {
        public int Add(int firstNumber, int secondNumber)
        {
            if (firstNumber == 0)
            {
                return secondNumber;
            }

            return firstNumber + secondNumber;
        }
    }
}
