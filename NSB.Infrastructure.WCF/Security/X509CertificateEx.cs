using System.Security.Cryptography.X509Certificates;

namespace NSB.Infrastructure.Wcf.Security
{
    public static class X509CertificateEx
    {
        public static X509Certificate2 ReadFromLocalStoreBySerialNumber(string serial)
        {
            if (string.IsNullOrWhiteSpace(serial)) return null;
            var store = new X509Store(StoreLocation.LocalMachine);

            store.Open(OpenFlags.ReadOnly);
            var certs = store.Certificates.Find(X509FindType.FindBySerialNumber, serial, true);
            store.Close();

            return certs.Count > 0 ? certs[0] : null;
        }
    }
}