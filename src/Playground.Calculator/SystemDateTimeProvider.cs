namespace Playground.Calculator
{
    using System;

    public class SystemDateTimeProvider : IDateTimeProvider
    {
        private SystemDateTimeProvider()
        {
        }

        public static SystemDateTimeProvider Instance { get; } = new SystemDateTimeProvider();

        public DateTime Now => DateTime.Now;
    }
}