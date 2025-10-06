using System;

namespace RazySoft.MarketSync.Core.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException() { }
        public DomainException(string message) : base(message) { }
        public DomainException(string message, Exception inner) : base(message, inner) { }
    }

    public class SyncException : DomainException
    {
        public SyncException() { }
        public SyncException(string message) : base(message) { }
        public SyncException(string message, Exception inner) : base(message, inner) { }
    }
}
