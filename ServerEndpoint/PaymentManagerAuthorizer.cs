using System.Security.Claims;
using NSB.Infrastructure.Wcf.Security;

namespace NSB.Endpoints.Server
{
    public class PaymentManagerAuthorizer : AbstractServiceAuthorizer<IPaymentManager>
    {
        public override bool CheckAccess(ClaimsPrincipal principal, string resource, string action)
        {
            return true;
        }
    }
}
