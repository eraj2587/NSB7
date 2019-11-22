using ServiceModelEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace NSB.Infrastructure.Wcf.Security
{
    internal class AuthenticationManager : ClaimsAuthenticationManager
    {
        private readonly IEnumerable<IServiceAuthenticator> authenticators;

        public AuthenticationManager(IEnumerable<IServiceAuthenticator> authenticators, Uri[] baseAddresses)
        {
            this.authenticators = authenticators;
            foreach (var authenticator in this.authenticators)
            {
                authenticator.Initialize(baseAddresses);
            }
        }

        public override ClaimsPrincipal Authenticate(string resourceName, ClaimsPrincipal incomingPrincipal)
        {
            return GetAuthenticatorForResource(resourceName).Authenticate(incomingPrincipal);
        }

        private IServiceAuthenticator GetAuthenticatorForResource(string resourceName)
        {
            var resourceAuthenticator = authenticators.FirstOrDefault(a => a.CanAuthenticateForResource(resourceName));
            return resourceAuthenticator ?? new DefaultTokenAuthenticationManager();
        }

        private class DefaultTokenAuthenticationManager : IServiceAuthenticator
        {
            public ClaimsPrincipal Authenticate(ClaimsPrincipal incomingPrincipal)
            {
                var context = ContextManager.GetContext("security_token");
                if (string.IsNullOrEmpty(context)) return incomingPrincipal;
                var identity = context.CreateIdentityFromToken();
                return new ClaimsPrincipal(identity);
            }

            public bool CanAuthenticateForResource(string resource)
            {
                return true;
            }

            public void Initialize(Uri[] addresses) { }
        }
    }
}
