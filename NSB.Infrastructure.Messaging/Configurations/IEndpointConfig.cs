using NServiceBus;

namespace NSB.Infrastructure.Messaging.Configurations
{
    public interface IEndpointConfig
    {
        #region Methods

        EndpointConfiguration BuildConfig();

        #endregion
    }
}
