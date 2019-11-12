using System;

namespace WUBS.Cct.Treasury.Exceptions
{
    public class UnableToRetrieveValueDateException : ApplicationException
    {
        public UnableToRetrieveValueDateException(string message)
            : base(message)
        {
        }

        public UnableToRetrieveValueDateException(int lineItemId)
            : base(string.Format("Unable to retrieve ValueDate for lineItemId {0}", lineItemId))
        {
        }

        public UnableToRetrieveValueDateException()
            : base("Unable to get value date.")
        {
        }
    }
}
