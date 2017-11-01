using System;

namespace Playground.Calculator
{
    public interface IDateTimeProvider
    {
        DateTime Now { get; }
    }
}