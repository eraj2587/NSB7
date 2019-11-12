using System;

namespace WUBS.Cct.Treasury.Infrastructure.Exceptions
{
    public class SqlCommandExecutionException : ApplicationException
    {
        public SqlCommandExecutionException(string message) : base(message)
        {
        }
    }
}
