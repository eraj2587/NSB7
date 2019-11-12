using System;

namespace WUBS.Cct.Treasury.Exceptions
{
    public class InvalidCurrencyException : Exception
    {
        public InvalidCurrencyException()
            : base("Invalid Currency.")
        {
        }
    }
}
