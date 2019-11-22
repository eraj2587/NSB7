using System;
using System.Linq;
using System.Security.Claims;

namespace NSB.Infrastructure.Wcf.Security
{
    public interface IServiceAuthenticator
    {
        ClaimsPrincipal Authenticate(ClaimsPrincipal incomingPrincipal);
        bool CanAuthenticateForResource(string resource);
        void Initialize(Uri[] addresses);
    }

    public abstract class AbstractServiceAuthenticator<T> : IServiceAuthenticator
    {
        protected string[] resources;

        public abstract ClaimsPrincipal Authenticate(ClaimsPrincipal incomingPrincipal);

        public bool CanAuthenticateForResource(string resource)
        {
            AssertIsInitialized();
            var strippedResource = new Uri(resource).AbsolutePath;
            return resources.Any(res => strippedResource.StartsWith(strippedResource, StringComparison.OrdinalIgnoreCase));
        }

        public void Initialize(Uri[] addresses)
        {
            resources = addresses.Where(a => !a.LocalPath.EndsWith("/mex", StringComparison.OrdinalIgnoreCase)).Select(a => a.LocalPath).ToArray();
        }

        private void AssertIsInitialized()
        {
            if (resources == null) throw new InvalidOperationException("Authenticator was not initialized");
        }

    }
}