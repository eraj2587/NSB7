using ServiceModelEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using WUBS.Infrastructure.Wcf.Security;

namespace WUBS.Infrastructure.Wcf
{
    internal static class ServiceHostEx
    {
        public static void EnableTransactionFlowAndReliableMessaging(this ServiceHost host)
        {
            foreach (var endpoint in host.Description.Endpoints)
            {
                endpoint.Binding.EnableTransactionFlowAndReliableMessaging();
            }
        }

        public static void EnableTransactionFlowAndReliableMessaging(this Binding binding)
        {
            if (binding is NetTcpBinding)
            {
                var netTcpBinding = binding as NetTcpBinding;
                netTcpBinding.TransactionFlow = true;
                netTcpBinding.ReliableSession = new OptionalReliableSession() { Enabled = true, Ordered = true };
            }
            if (binding is WSHttpBinding)
            {
                var httpTcpBinding = binding as WSHttpBinding;
                httpTcpBinding.TransactionFlow = true;
                httpTcpBinding.ReliableSession = new OptionalReliableSession() { Enabled = true };
            }
        }

        public static ServiceEndpoint[] AddServiceEndpoints<T>(this ServiceHost<T> host, ServiceSecurityMode securityMode, EndpointIdentity identity = null)
        {
            if (host.State == CommunicationState.Opened)
            {
                throw new InvalidOperationException("Host is already opened");
            }
            var endpointsCreated = new List<ServiceEndpoint>();
            var serviceInterfaces = typeof(T).GetInterfaces().Where(i => i.GetCustomAttributes(typeof(ServiceContractAttribute), true).Any());
            foreach (var serviceInterface in serviceInterfaces)
            {
                foreach (var baseAddress in host.BaseAddresses)
                {
                    var uriBuilder = new UriBuilder(baseAddress);
                    uriBuilder.Path = string.Format("{0}/{1}", uriBuilder.Path, securityMode.PathExtension);
                    var serviceUri = uriBuilder.Uri;
                    var binding = CreateBindingForUri(baseAddress);
                    binding.SetBindingSecurity(securityMode);
                    var ep = host.AddServiceEndpoint(serviceInterface, binding, string.Empty);
                    ep.Address = identity == null
                        ? new EndpointAddress(serviceUri)
                        : new EndpointAddress(serviceUri, EndpointIdentity.CreateIdentity(identity.IdentityClaim));
                    endpointsCreated.Add(ep);
                }
            }
            return endpointsCreated.ToArray();
        }

        public static Binding CreateBindingForUri(Uri baseAddress)
        {
            switch (baseAddress.Scheme.ToLowerInvariant())
            {
                case "http":
                case "https":
                    return new WSHttpContextBinding();
                case "net.tcp":
                    return new NetTcpContextBinding();
                default:
                    throw new InvalidOperationException(string.Format("Scheme {0} is not supported", baseAddress.Scheme));
            }
        }

        public static void SetServiceHostSecurity(this ServiceHost host, IEnumerable<ServiceSecurityMode> securityModes)
        {
            foreach (var mode in securityModes)
            {
                var certMode = mode as X509CertificateServiceSecurityMode;
                if (certMode != null)
                {
                    host.Credentials.ServiceCertificate.Certificate = certMode.TransportCertificate;
                    host.Credentials.ClientCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.None;
                }
            }
        }

        public static void SetBindingSecurity(this Binding binding, ServiceSecurityMode serviceSecurityMode)
        {
            if (serviceSecurityMode is NoneServiceSecurityMode) SetBindingSecurityForNone(binding);
            else if (serviceSecurityMode is WindowsServiceSecurityMode) SetBindingSecurityForWindows(binding);
            else if (serviceSecurityMode is X509CertificateServiceSecurityMode) SetBindingSecurityForCertificate(binding);
            else throw new ArgumentOutOfRangeException("serviceSecurityMode", serviceSecurityMode, null);
        }

        public static Uri[] GetServiceHostEndpointUrls<T>(this ServiceHost<T> host)
        {
            return host.Description.Endpoints.Select(ep => ep.Address.Uri).ToArray();
        }
        private static void SetBindingSecurityForNone(Binding binding)
        {
            if (binding is NetTcpBinding)
            {
                var tcpBinding = (NetTcpBinding)binding;
                tcpBinding.Security.Mode = SecurityMode.None;
            }
            if (binding is WSHttpBinding)
            {
                var httpBinding = (WSHttpBinding)binding;
                httpBinding.Security.Mode = SecurityMode.None;
            }
        }

        private static void SetBindingSecurityForWindows(Binding binding)
        {
            if (binding is NetTcpBinding)
            {
                var tcpBinding = (NetTcpBinding)binding;
                tcpBinding.Security.Mode = SecurityMode.Transport;
                tcpBinding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;
                tcpBinding.Security.Transport.ProtectionLevel = ProtectionLevel.EncryptAndSign;
                tcpBinding.Security.Message.ClientCredentialType = MessageCredentialType.Windows;
            }
            if (binding is WSHttpBinding)
            {
                var httpBinding = (WSHttpBinding)binding;
                httpBinding.Security.Mode = binding.Scheme == Uri.UriSchemeHttps ? SecurityMode.TransportWithMessageCredential : SecurityMode.Message;
                httpBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Windows;
                httpBinding.Security.Message.ClientCredentialType = MessageCredentialType.Windows;
                httpBinding.Security.Message.EstablishSecurityContext = true;
            }
        }

        private static void SetBindingSecurityForCertificate(Binding binding)
        {
            if (binding is NetTcpBinding)
            {
                var tcpBinding = (NetTcpBinding)binding;
                tcpBinding.Security.Mode = SecurityMode.TransportWithMessageCredential;
                tcpBinding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Certificate;
                tcpBinding.Security.Transport.ProtectionLevel = ProtectionLevel.EncryptAndSign;
                tcpBinding.Security.Message.ClientCredentialType = MessageCredentialType.Certificate;
            }
            if (binding is WSHttpBinding)
            {
                throw new NotImplementedException();
                //var httpBinding = (WSHttpBinding)binding;
                //httpBinding.Security.Mode = binding.Scheme == Uri.UriSchemeHttps ? SecurityMode.TransportWithMessageCredential : SecurityMode.Message;
                //httpBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Certificate;
                //httpBinding.Security.Message.ClientCredentialType = MessageCredentialType.Certificate;
                //httpBinding.Security.Message.NegotiateServiceCredential = false;
                //httpBinding.Security.Message.EstablishSecurityContext = true;
            }
        }
    }
}