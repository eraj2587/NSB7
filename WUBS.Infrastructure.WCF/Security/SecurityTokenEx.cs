using System;
using System.IdentityModel.Protocols.WSTrust;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using WUBS.Contracts.Services.DataContracts.Authentication;

namespace WUBS.Infrastructure.Wcf.Security
{
    internal static class SecurityTokenEx
    {
        private const string Issuer = "self";
        private const string Audience = "http://services.business.westernunion.com";
        private const int LifeTimeInSeconds = 5 * 60;//5 minutes

        public static string CreateToken(this ClaimsIdentity identity, X509Certificate2 signingCertificate = null)
        {
            if (identity == null) throw new ArgumentNullException("identity");

            var tokenHandler = new JwtSecurityTokenHandler();
            var now = DateTime.UtcNow;
            var tokenDescriptor = new System.IdentityModel.Tokens.SecurityTokenDescriptor
            {
                Subject = identity,
                TokenIssuerName = Issuer,
                AppliesToAddress = Audience,
                Lifetime = new Lifetime(now, now.AddMinutes(LifeTimeInSeconds)),
                SigningCredentials = signingCertificate == null ? null : new System.IdentityModel.Tokens.X509SigningCredentials(signingCertificate)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }

        public static ClaimsIdentity CreateIdentityFromToken(this string token, X509Certificate2 certificate = null)
        {
            if (token == null) throw new ArgumentNullException("token");

            var tokenHandler = new JwtSecurityTokenHandler();
            if (certificate != null)
            {
                var x509SecurityToken = new X509SecurityToken(certificate);
                var validationParameters = new System.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidAudience = Audience,
                    IssuerSigningToken = x509SecurityToken,
                    ValidIssuer = Issuer,
                };

                System.IdentityModel.Tokens.SecurityToken validatedToken;
                var claimsPrincipal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
                return claimsPrincipal.Identity as ClaimsIdentity;
            }
            var jwtToken = (JwtSecurityToken)tokenHandler.ReadToken(token);
            return new ClaimsIdentity(jwtToken.Claims, Issuer, JwtRegisteredClaimNames.UniqueName, CustomClaimTypes.Task);
        }
    }
}