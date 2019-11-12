using System;

namespace WUBS.Cct.Treasury.Exceptions
{
    public class InvalidFundingSourceException : Exception
    {
        public InvalidFundingSourceException(string message)
            : base(message)
        {
        }

        public InvalidFundingSourceException(int id)
            : this(string.Format("Invalid funding source for line item Id: {0}", id))
        {
        }
    }
}
