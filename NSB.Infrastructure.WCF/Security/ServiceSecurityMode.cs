using ServiceModelEx;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace NSB.Infrastructure.Wcf.Security
{

    internal abstract class ServiceSecurityMode
    {
        private static readonly ServiceSecurityMode None = new NoneServiceSecurityMode();
        private static readonly ServiceSecurityMode Windows = new WindowsServiceSecurityMode();
        private static readonly ServiceSecurityMode Certificate = new X509CertificateServiceSecurityMode();

        private readonly string mode;

        protected ServiceSecurityMode(string mode)
        {
            this.mode = mode;
        }

        public abstract string PathExtension { get; }

        public override string ToString()
        {
            return mode;
        }

        protected virtual void LoadFromConfiguration(NameValueCollection configuration) { }

        public static ServiceSecurityMode GetSecurityModeFromConfig()
        {
            var modes = ConfigurationManager.AppSettings["Transport.Security.Mode"];
            var modesFromConfig = GetModesFromConfig(modes);
            if (modesFromConfig.Length != 1) throw new InvalidOperationException(string.Format("Transport.Security.Mode for client can only have one value but was: {0}", modes));
            return CreateServiceSecurityMode(modesFromConfig[0]);
        }

        public static ServiceSecurityMode[] GetSecurityModesFromConfig()
        {
            var modes = ConfigurationManager.AppSettings["Transport.Security.Mode"];
            var modesFromConfig = GetModesFromConfig(modes);
            if (modesFromConfig.Length == 0) throw new InvalidOperationException(string.Format("Transport.Security.Mode incorrect values in the config files: {0}", modes));

            if (string.IsNullOrWhiteSpace(modes)) return new ServiceSecurityMode[0];
            List<ServiceSecurityMode> parsedModes = new List<ServiceSecurityMode>();
            foreach (var mode in modesFromConfig)
            {
                parsedModes.Add(CreateServiceSecurityMode(mode));
            }
            return parsedModes.ToArray();
        }

        private static string[] GetModesFromConfig(string modes)
        {
            if (string.IsNullOrWhiteSpace(modes)) return new string[0];
            return modes.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(m => m.Trim()).ToArray();
        }

        private static ServiceSecurityMode CreateServiceSecurityMode(string mode)
        {
            ServiceSecurityMode serviceSecurityMode = null;
            if (string.IsNullOrWhiteSpace(mode)) serviceSecurityMode = Windows;
            else if (mode.Equals(None.mode, StringComparison.OrdinalIgnoreCase)) serviceSecurityMode = None;
            else if (mode.Equals(Windows.mode, StringComparison.OrdinalIgnoreCase)) serviceSecurityMode = Windows;
            else if (mode.Equals(Certificate.mode, StringComparison.OrdinalIgnoreCase)) serviceSecurityMode = Certificate;
            else throw new InvalidOperationException(string.Format("'{0}' is not a valid transport security mode", mode));

            serviceSecurityMode.LoadFromConfiguration(ConfigurationManager.AppSettings);

            return serviceSecurityMode;
        }
    }

    internal class WindowsServiceSecurityMode : ServiceSecurityMode
    {
        public WindowsServiceSecurityMode() : base("Windows") { }

        public override string PathExtension
        {
            get { return "win"; }
        }
    }

    internal class NoneServiceSecurityMode : ServiceSecurityMode
    {
        public NoneServiceSecurityMode() : base("None") { }

        public override string PathExtension
        {
            get { return ""; }
        }
    }

    internal class X509CertificateServiceSecurityMode : ServiceSecurityMode
    {

        public X509Certificate2 TransportCertificate { get; private set; }

        public X509CertificateServiceSecurityMode() : base("X509Certificate") { }

        protected override void LoadFromConfiguration(NameValueCollection configuration)
        {
            var certSn = configuration["Transport.Security.X509Certificate.Serial"];
            var cert = X509CertificateEx.ReadFromLocalStoreBySerialNumber(certSn);
            TransportCertificate = cert;
        }

        public override string PathExtension
        {
            get { return "ssl"; }
        }
    }
}