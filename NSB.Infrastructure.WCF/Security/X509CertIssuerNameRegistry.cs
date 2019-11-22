using System;
using System.IdentityModel.Tokens;

namespace NSB.Infrastructure.Wcf.Security
{
    internal class X509CertIssuerNameRegistry : IssuerNameRegistry
    {
        public override string GetIssuerName(SecurityToken securityToken)
        {
            if (securityToken == null) throw new ArgumentNullException("securityToken");

            var x509Token = securityToken as X509SecurityToken;
            if (x509Token != null) return x509Token.Certificate.Issuer;

            throw new SecurityTokenException(string.Format("Security token {0} is not supported", securityToken.GetType().FullName));
        }
    }
}