using ServiceModelEx;
using System;
using System.Linq;
using System.Security.Claims;
using System.ServiceModel.Description;

namespace NSB.Infrastructure.Wcf.Security
{
    public interface IServiceAuthorizer
    {

        bool CanCheckFor(string resource, string action);
        bool CheckAccess(ClaimsPrincipal principal, string resource, string action);
        void Initialize(Uri[] addresses);
    }

    public abstract class AbstractServiceAuthorizer<T> : IServiceAuthorizer
    {

        protected string[] resources;
        protected string[] actions;
        private string actionPrefix;


        public void Initialize(Uri[] addresses)
        {
            var description = CreatefromServiceContract(typeof(T));
            actionPrefix = string.Format("{0}{1}", EnsureTrailingSlash(description.Namespace), EnsureTrailingSlash(description.Name));
            resources = addresses.Where(a => !a.LocalPath.EndsWith("/mex", StringComparison.OrdinalIgnoreCase)).Select(a => a.LocalPath).ToArray();
            actions = description.Operations.Select(op => PrefixAction(op.Name)).ToArray();
        }

        public abstract bool CheckAccess(ClaimsPrincipal principal, string resource, string action);

        public virtual bool CanCheckFor(string resource, string action)
        {
            AssertIsInitialized();
            Uri resourceUri;
            if (!Uri.TryCreate(resource, UriKind.RelativeOrAbsolute, out resourceUri)) throw new InvalidOperationException(string.Format("'{0}' is not a valid resource", resource));
            resource = resourceUri.LocalPath;
            return resources.Any(res => resource.StartsWith(res, StringComparison.OrdinalIgnoreCase)) && actions.Any(a => a.Equals(action, StringComparison.OrdinalIgnoreCase));
        }

        private void AssertIsInitialized()
        {
            if (resources == null || actions == null) throw new InvalidOperationException("Authorizer was not initialized");
        }

        private static ContractDescription CreatefromServiceContract(Type serviceContract)
        {
            return ContractDescription.GetContract(serviceContract);
        }

        private static string EnsureTrailingSlash(string s)
        {
            return s.EndsWith("/")
                ? s
                : s + "/";
        }

        private string PrefixAction(string action)
        {
            return string.Format("{0}{1}", actionPrefix, action);
        }

        protected string StripPrefixFromAction(string action)
        {
            if (!action.StartsWith(actionPrefix)) throw new InvalidOperationException(string.Format("{0} doesn't have prefix {1}", action, actionPrefix));
            return action.Remove(0, actionPrefix.Length);
        }

    }


}