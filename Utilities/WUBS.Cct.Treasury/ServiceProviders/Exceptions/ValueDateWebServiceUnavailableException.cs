using System.ServiceModel;
using WUBS.Cct.Treasury.Infrastructure.Exceptions;

namespace WUBS.Cct.Treasury.ServiceProviders.Exceptions
{
    public class ValueDateWebServiceUnavailableException : ServiceProviderCommunicationException
    {
        public ValueDateWebServiceUnavailableException(CommunicationException exception)
            : base("Value Date Web Service is unavailable.", exception)
        {
        }
    }
}
