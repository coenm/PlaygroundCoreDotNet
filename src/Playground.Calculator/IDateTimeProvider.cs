namespace Playground.Calculator
{
    using System;

    public interface IDateTimeProvider
    {
        DateTime Now { get; }
    }
}