using ServiceModelEx;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Security.Claims;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using NSB.Infrastructure.Wcf.Security;

namespace NSB.Infrastructure.Wcf
{
    public static class ProxyFactory
    {

        private static readonly ConcurrentDictionary<Uri, IChannelFactory> CachedChannelFactories = new ConcurrentDictionary<Uri, IChannelFactory>();
        public static TService CreateProxy<TService>(string uri) where TService : class
        {
            Uri serviceUri;
            if (!Uri.TryCreate(uri, UriKind.RelativeOrAbsolute, out serviceUri)) throw new ArgumentException(string.Format("'{0}' is not a valid uri", uri), "uri");

            return CreateProxy<TService>(serviceUri);
        }

        public static TService CreateProxy<TService>(Uri uri) where TService : class
        {
            if (uri == null) throw new ArgumentNullException("uri");

            var cf = (ChannelFactory<TService>)CachedChannelFactories.GetOrAdd(uri, CreateChannelFactory<TService>);
            IClientChannel channel = (IClientChannel)cf.CreateChannel();
            if (ClaimsPrincipal.Current != null)
            {
                channel.SetCurrentIdentityToken((ClaimsIdentity)ClaimsPrincipal.Current.Identity);
            }
            
            return (TService)channel;
        }
       

        private static IChannelFactory<TService> CreateChannelFactory<TService>(Uri uri) where TService : class
        {
            var binding = (NetTcpBinding)CreateDefaultEndpointBinding(uri);
            var securityMode = ServiceSecurityMode.GetSecurityModeFromConfig();
            binding.SetBindingSecurity(securityMode);
            binding.MaxBufferSize = 2147483647;
            binding.MaxReceivedMessageSize = 65536;
            binding.CloseTimeout = new TimeSpan(0,5,0);
            //updated service RecieveTimeout to 3 minutes instead of default
            binding.ReceiveTimeout = TimeSpan.FromMinutes(3);
#if DEBUG
            binding.SendTimeout = TimeSpan.MaxValue;
            binding.OpenTimeout = TimeSpan.MaxValue;
            binding.ReceiveTimeout = TimeSpan.MaxValue;
            binding.CloseTimeout = TimeSpan.MaxValue;
#endif

            binding.EnableTransactionFlowAndReliableMessaging();
            var serviceUriBuilder = new UriBuilder(uri);
            serviceUriBuilder.Path = string.Format("{0}/{1}", serviceUriBuilder.Path, securityMode.PathExtension);
            var address = CreateEndpointAddress(serviceUriBuilder.Uri, null);

            var cf = new ChannelFactory<TService>(binding, address);
            cf.AddGenericResolver();
            cf.Credentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.None;

            var certMode = securityMode as X509CertificateServiceSecurityMode;
            if (certMode != null)
            {
                cf.Credentials.ClientCertificate.Certificate = certMode.TransportCertificate;
            }
            return cf;
        }

        private static Binding CreateDefaultEndpointBinding(Uri uri)
        {
            return ServiceHostEx.CreateBindingForUri(uri);
        }

        private static EndpointAddress CreateEndpointAddress(Uri uri, EndpointIdentity identity)
        {
            return identity == null
                ? new EndpointAddress(uri)
                : new EndpointAddress(uri, identity);
        }

        private static void SetCurrentIdentityToken(this IClientChannel channel, ClaimsIdentity identity)
        {

            var token = identity.CreateToken();

            var context = new Dictionary<string, string>
            {
                {"security_token", token},
            };
            ContextManager.SetContext(channel, context);
        }
    }
}
