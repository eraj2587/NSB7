using System.ServiceModel;
using WUBS.Contracts.Common.Monads;
using WUBS.Contracts.Services.DataContracts;
using WUBS.Contracts.Services.DataContracts.Orders;
using WUBS.Contracts.Services.Faults;

namespace WUBS.Contracts.Services
{
    [ServiceContract(Namespace = "http://schema.business.westernunion.com/contracts/")]
    public interface IOrderCaptureManager
    {
        [OperationContract]
        [ServiceKnownType(typeof(NewOrder))]
        [ServiceKnownType(typeof(UpdateOrder))]
        [ServiceKnownType(typeof(RepurchaseOrder))]
        Validated<BuildResponse> Build(BuildRequest buildRequest);

        [OperationContract]
        [FaultContract(typeof(UnableToGetCostPricingSpreadWhenQuotingFault))]
        [FaultContract(typeof(UnableToQuoteFault))]
        [FaultContract(typeof(InvalidOrderIdFault), Action = "InvalidOrderIdFault")]
        Validated<QuoteResponse> Quote(QuoteRequest quoteRequest);

        [OperationContract]
        [FaultContract(typeof(InvalidOrderIdFault), Action = "InvalidOrderIdFault")]
        Validated<CommitResponse> Commit(CommitRequest commitRequest);
    }
}