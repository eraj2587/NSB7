using System;

namespace WUBS.Cct.Treasury.Exceptions
{
    public class InvalidForwardContractIdException : Exception
    {
        public InvalidForwardContractIdException(string message)
            : base(message)
        {
        }

        public InvalidForwardContractIdException(int id)
            : this(string.Format("Invalid forward contract Id: {0}", id))
        {
        }
    }
}
