using System;

namespace WUBS.Cct.Treasury.Exceptions
{
    public class UnableToRetrieveWindowStartDateException : ApplicationException
    {
        public UnableToRetrieveWindowStartDateException(string message)
            : base(message)
        {
        }

        public UnableToRetrieveWindowStartDateException(int lineItemId)
            : base(string.Format("Unable to retrieve WindowStartDate for lineItemId {0}", lineItemId))
        {
        }

        public UnableToRetrieveWindowStartDateException()
            : base("Unable to get WindowStartDate.")
        {
        }
    }
}
