using System.ServiceModel;
using NSB.Contracts.Common.Monads;
using NSB.Contracts.Services.DataContracts;
using NSB.Contracts.Services.Faults;

namespace NSB.Contracts.Services
{
    [ServiceContract(Namespace = "http://schema.business.test.com/contracts/")]
    public interface ILimitOrderManager
    {
        [OperationContract]
        [ServiceKnownType(typeof(NewLimitOrderRequest))]
        Validated<LimitOrderBuildResponse> Build(LimitOrderRequest request);

        [OperationContract]
        [ServiceKnownType(typeof(NewLimitOrderRequest))]
        Validated<LimitOrderQuoteResponse> Update(LimitOrderModifyTreasuryRequest request);

        [OperationContract]
        [FaultContract(typeof(InvalidOrderIdFault))]
        Validated<LimitOrderQuoteResponse> Quote(LimitOrderQuoteRequest request);

        [OperationContract]
        Validated<LimitOrderQuoteResponse> Calculate(LimitOrderCalculateRequest request);

        [OperationContract]
        [ServiceKnownType(typeof(LimitOrderSubmitRequest))]
        [FaultContract(typeof(InvalidOrderIdFault))]
        Validated <LimitOrderSubmitResponse> Submit(LimitOrderUpdateRequest request);

        [OperationContract]
        [ServiceKnownType(typeof(LimitOrderApproveRequest))]
        Validated<LimitOrderApproveResponse> Approve(LimitOrderUpdateRequest request);

        [OperationContract]
        [ServiceKnownType(typeof(LimitOrderRejectRequest))]
        Validated<LimitOrderRejectResponse> Reject(LimitOrderUpdateRequest request);

        [OperationContract]
        [ServiceKnownType(typeof(LimitOrderCancelRequest))]
        Validated<LimitOrderCancelResponse> Cancel(LimitOrderUpdateRequest request);

        [OperationContract]
        [ServiceKnownType(typeof(LimitOrderCancelRequest))]
        Validated<LimitOrderCancelResponse> CancelV1(LimitOrderUpdateRequest request, bool isApiCall);

        [OperationContract]
        [ServiceKnownType(typeof(LimitOrderApproveCancelRequest))]
        Validated<LimitOrderCancelResponse> ApproveCancel(LimitOrderUpdateRequest request);

        [OperationContract]
        [ServiceKnownType(typeof(LimitOrderRejectCancelRequest))]
        Validated<LimitOrderCancelResponse> RejectCancel(LimitOrderUpdateRequest request);

        [OperationContract]
        Validated<LimitOrderStatusChangeResponse> ChangeType(string orderId);

        [OperationContract]
        [ServiceKnownType(typeof(LimitOrderFillRequest))]
        Validated<LimitOrderFillResponse> Fill(LimitOrderUpdateRequest request);

        [OperationContract]
        Validated<ReCalculateTriggerRatesResponse> ReCalculateTriggerRates();

        [OperationContract]
        [ServiceKnownType(typeof (BuildAndSubmitLimitOrderRequest))]
        Validated<LimitOrderBuildAndSubmitResponse> BuildandSubmit(BuildAndSubmitLimitOrderRequest request);

        [OperationContract]
        Validated<LimitOrderDeleteResponse> Delete(string orderId);

        [OperationContract]
        [ServiceKnownType(typeof(LimitOrderApproveExpiryRequest))]
        Validated<LimitOrderApproveExpiryResponse> ApproveExpiry(LimitOrderUpdateRequest request);

        [OperationContract]
        [ServiceKnownType(typeof(LimitOrderRejectExpiryRequest))]
        Validated<LimitOrderRejectExpiryResponse>RejectExpiry(LimitOrderRejectExpiryRequest request);
    }
}
