using System;
using System.ServiceModel;

namespace WUBS.Cct.Treasury.Infrastructure.Exceptions
{
    public class ServiceProviderCommunicationException : ApplicationException
    {
        public ServiceProviderCommunicationException(string message, CommunicationException exception)
            : base(message, exception)
        {
        }
    }
}
