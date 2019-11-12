using NServiceBus;

namespace WUBS.Infrastructure.Messaging.Configurations
{
    public interface IEndpointConfig
    {
        #region Methods

        EndpointConfiguration BuildConfig();

        #endregion
    }
}
