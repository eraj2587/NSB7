using System;

namespace WUBS.Cct.Treasury.Infrastructure.Exceptions
{
    public class InvalidCacheItemException : ApplicationException
    {
        public InvalidCacheItemException(string cacheName)
            : base("Invalid " + cacheName)
        {
        }
    }
}
