using System.ServiceModel;
using WUBS.Contracts.Common.Monads;
using WUBS.Contracts.Services.DataContracts;

namespace WUBS.Contracts.Services
{
    [ServiceContract(Namespace = "http://schema.business.westernunion.com/contracts/")]
    public interface IExternalLimitOrderManager
    {
        [OperationContract]
        [ServiceKnownType(typeof(LimitOrderCancelRequest))]
        Validated<LimitOrderCancelResponse> Cancel(LimitOrderUpdateRequest request);
    }
}
