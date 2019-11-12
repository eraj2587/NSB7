using System.ServiceModel;

namespace WUBS.Cct.Treasury.Infrastructure.ServiceProviders
{
    public delegate void UseServiceDelegate<T>(T proxy);
    public abstract class ServiceProvider<T>
    {
        public abstract IClientChannel CreateProxy();

        public void CallRemoteProcedure(UseServiceDelegate<T> codeBlock)
        {
            var proxy = CreateProxy();
            bool success = false;
            try
            {
                codeBlock((T)proxy);
                proxy.Close();
                success = true;
            }
            finally
            {
                if (!success)
                {
                    proxy.Abort();
                }
            }
        }
    }
}
