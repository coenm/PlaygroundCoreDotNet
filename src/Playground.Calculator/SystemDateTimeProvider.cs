using System;

namespace Playground.Calculator
{
    public class SystemDateTimeProvider : IDateTimeProvider
    {
        public static SystemDateTimeProvider Instance { get; } = new SystemDateTimeProvider();

        private SystemDateTimeProvider()
        {
        }

        public DateTime Now => DateTime.Now;
    }
}