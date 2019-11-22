using System.ServiceModel;
using NSB.Contracts.Common.Monads;
using NSB.Contracts.Services.DataContracts;
using NSB.Contracts.Services.DataContracts.Orders;
using NSB.Contracts.Services.Faults;

namespace NSB.Contracts.Services
{
    [ServiceContract(Namespace = "http://schema.business.test.com/contracts/")]
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