using System.ServiceModel;
using NSB.Contracts.Common.Monads;
using NSB.Contracts.Services.DataContracts;

namespace NSB.Contracts.Services
{
    [ServiceContract(Namespace = "http://schema.business.test.com/contracts/")]
    public interface IExternalLimitOrderManager
    {
        [OperationContract]
        [ServiceKnownType(typeof(LimitOrderCancelRequest))]
        Validated<LimitOrderCancelResponse> Cancel(LimitOrderUpdateRequest request);
    }
}
