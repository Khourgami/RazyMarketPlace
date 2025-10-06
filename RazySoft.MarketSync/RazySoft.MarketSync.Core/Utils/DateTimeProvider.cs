using System;

namespace RazySoft.MarketSync.Core.Utils
{
    /// <summary>
    /// Abstraction over DateTime to make code testable.
    /// </summary>
    public interface IDateTimeProvider
    {
        DateTime UtcNow { get; }
    }

    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
