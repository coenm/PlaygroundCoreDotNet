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

            Int64 result = firstNumber + secondNumber;
            return (int) result;
        }
    }
}
