using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace NSB.Infrastructure.Wcf.Security
{
    internal class AuthorizationManager : ClaimsAuthorizationManager
    {
        private readonly IEnumerable<IServiceAuthorizer> authorizers;

        public AuthorizationManager(IEnumerable<IServiceAuthorizer> authorizers, Uri[] addresses)
        {
            if (authorizers == null) throw new ArgumentNullException("authorizers");
            if (addresses == null || addresses.Length == 0) throw new ArgumentException("addresses");

            this.authorizers = authorizers;
            foreach (var serviceAuthorizer in this.authorizers)
            {
                serviceAuthorizer.Initialize(addresses);
            }
        }

        public override bool CheckAccess(AuthorizationContext context)
        {
            var resource = context.Resource.First().Value;
            var action = context.Action.First().Value;

            if (resource.EndsWith("/mex", StringComparison.OrdinalIgnoreCase)) return true;

            var result = false;
            foreach (var authorizer in authorizers.Where(a => a.CanCheckFor(resource, action)))
            {
                result = authorizer.CheckAccess(context.Principal, resource, action);
            }
            return result;
        }
    }

}