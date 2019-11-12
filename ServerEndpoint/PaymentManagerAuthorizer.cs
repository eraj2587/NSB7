using System.Security.Claims;
using WUBS.Infrastructure.Wcf.Security;

namespace WUBS.Endpoints.Server
{
    public class PaymentManagerAuthorizer : AbstractServiceAuthorizer<IPaymentManager>
    {
        public override bool CheckAccess(ClaimsPrincipal principal, string resource, string action)
        {
            return true;
        }
    }
}
