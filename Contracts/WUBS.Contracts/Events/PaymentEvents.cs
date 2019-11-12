using System;
using System.Collections.Generic;

namespace WUBS.Contracts.Events
{

    [Endpoint("WUBS.Endpoints.Payments")]
    public interface IIncomingPaymentReceived
    {
        string PaymentId { get; set; }
    }

    [Endpoint("WUBS.Endpoints.Payments")]
    public interface IIncomingPaymentReleased
    {
        string PaymentId { get; set; }
    }

    [Endpoint("WUBS.Endpoints.Payments")]
    public interface IOutgoingPaymentReleased
    {
        string PaymentId { get; set; }
    }

    [Endpoint("WUBS.Endpoints.Payments")]
    public interface IOutgoingPaymentCreated
    {
        string PaymentId { get; set; }
        bool IsManualRelease { get; set; }
    }

    [Endpoint("WUBS.Endpoints.Payments")]
    public interface IIncomingPaymentCreated
    {
        string PaymentId { get; set; }
        bool IsManualRelease { get; set; }
    }

    [Endpoint("WUBS.Endpoints.IncomingPaymentFulfillment")]
    public interface ICreateIncomingPaymentInstruction
    {
        string PaymentId { get; set; }
    }

    [Endpoint("WUBS.Endpoints.OutgoingPaymentFulfillment")]
    public interface ICreateOutgoingPaymentInstruction
    {
        string PaymentId { get; set; }
    }

    [Endpoint("WUBS.Endpoints.Payments")]
    public interface ICreditAvailableForPayment
    {
        string PaymentId { get; set; }
    }

    [Endpoint("WUBS.Endpoints.Payments")]
    public interface IComplianceScanComplete
    {
        string PaymentId { get; set; }
        bool IsSuccessful { get; set; }
        string ScanResultMessage { get; set; }
    }

    [Endpoint("WUBS.Adaptor.CCTPayment.Inbound")]
    public interface IProcessCctPaymentEvent
    {
        int OpsEssId { get; set; }
        int CctStatusId { get; set; }
        bool IsIncoming { get; set; }
        int OrderDetailId { get; set; }
        int ClientOrderId { get; set; }
        bool IsPaymentOnHold { get; set; }
        string HoldReason { get; set; }
        string PaymentId { get; set; }
    }

    //TODO : Change to command
    [Endpoint("WUBS.Endpoints.Payments")]
    public interface IHoldPayment
    {
        string PaymentId { get; set; }
        bool IsPaymentOnHold { get; set; }
        string HoldReason { get; set; }
    }

    [Endpoint("WUBS.Endpoints.Payments")]
    public interface ICancelPayment
    {
        string PaymentId { get; set; }
        long PaymentInstructionId { get; set; }
    }

    [Endpoint("WUBS.Endpoints.Payments")]
    public interface ICancelOutgoingPayment
    {
        string PaymentId { get; set; }
    }

    [Endpoint("WUBS.Endpoints.Payments")]
    public interface ICancelIncomingPayment
    {
        string PaymentId { get; set; }
    }

    [Endpoint("WUBS.Endpoints.Payments")]
    public interface IPaymentReadyForRelease
    {
        string PaymentId { get; set; }
    }

    [Endpoint("WUBS.Endpoints.Payments")]
    public interface IManualRelease
    {
        string PaymentId { get; set; }
    }

    [Endpoint("WUBS.Endpoints.OutgoingPaymentFulfillment")]
    public interface IPaymentInstructionCreated
    {
        long InstructionId { get; set; }
        string PaymentId { get; set; }

        bool CompleteSaga { get; set; }
        bool IsManuallyReleased { get; set; }
        bool IsCreditAvailableForPayment { get; set; }
        bool IsComplianceScanComplete { get; set; }

    }


    [Endpoint("WUBS.Endpoints.PaymentRelease")]
    public interface IProcessPaymentsForRelease
    {
        List<long> PaymentInstructionIds { get; set; }
    }

    [Endpoint("WUBS.Endpoints.PaymentRelease")]
    public interface IReleasePaymentBatch
    {
        long PaymentBatchId { get; set; }
    }

    [Endpoint("WUBS.Gateways.GPG")]
    public interface IPaymentBatchReleased
    {
        long PaymentBatchId { get; set; }
        bool IsValid { get; set; }
        string ResponseMessage { get; set; }
        bool IsReleaseViaRbfi { get; set; }
        bool IsSendSuccessful { get; set; }
    }

    [Endpoint("WUBS.Endpoints.PaymentRelease")]
    public interface IPaymentInstructionReleased
    {
        string PaymentId { get; set; }
        bool IsValid { get; set; }
        string ResponseMessage { get; set; }
    }

    [Endpoint("WUBS.Endpoints.Payments")]
    public interface IProcessFulfillmentBatch
    {
        long PaymentBatchId { get; set; }
    }
    [Endpoint("WUBS.Adaptor.CCTPayment.Inbound")]
    public interface ICctOrderCommittedEvent
    {
       int OpsEssId { get; set; }
       int CctStatusId { get; set; }
       bool IsIncoming { get; set; }
       int OrderDetailId { get; set; }
       int ClientOrderId { get; set; }
       bool IsPaymentOnHold { get; set; }
       string HoldReason { get; set; }
       string PaymentId { get; set; }
    }

    [Endpoint("WUBS.Endpoints.Payments")]
    public interface IOutGoingPaymentCancelled
    {
        string PaymentId { get; set; }
    }
    [Endpoint("WUBS.Endpoints.OutgoingPaymentFulfillment")]
    public interface IOutGoingPaymentFulfilled
    {
        string PaymentId { get; set; }
    }
    [Endpoint("WUBS.Endpoints.IncomingPaymentFulfillment")]
    public interface IIncomingPaymentInstructionCreated
    {
        long InstructionId { get; set; }
        string PaymentId { get; set; }
    }

    [Endpoint("WUBS.Endpoints.IncomingPaymentFulfillment")]
    public interface IIncomingPaymentStatusUpdated
    {
        string PaymentId { get; set; }
    }
    [Endpoint("WUBS.Adaptor.CCTPayment.Inbound")]
    public interface ICctOrderReleasedEvent
    {
        int OpsEssId { get; set; }
        int CctStatusId { get; set; }
        bool IsIncoming { get; set; }
        int OrderDetailId { get; set; }
        int ClientOrderId { get; set; }
        bool IsPaymentOnHold { get; set; }
        string HoldReason { get; set; }
        DateTime? CreatedDateTime { get; set; }
        //PYT -3332
        bool IsAutoRelease { get; set; }
    }
    [Endpoint("WUBS.Gateways.GPGOutbound")]
    public interface IPaymentFileBodyGenerated
    {
        long PaymentBatchId { get; set; }
        string QueueName { get; set; }
    }

    //PYT -3332
    [Endpoint("WUBS.Endpoints.Payments")]
    public interface IAutoReleaseOutgoingPaymentCreated
    {
        long PaymentId { get; set; }
        long PaymentInstructionId { get; set; }
        byte PaymentMethodId { get; set; }
        //PYT- 3177
        int? OpsessAccountId { get; set; }
        string BenefeciaryBankCountry { get; set; }
        DateTime? ActualValueDate { get; set; }
        int? NostroBankAccountChannelId { get; set; }
    }

    //PYT- 3276(PlaceHolder)
    [Endpoint("WUBS.Endpoints.PaymentRelease")]
    public interface IReleasePayment
    {
        string PaymentId { get; set; }
        long PaymentInstructionId { get; set; }
        //PYT- 3177
        int? OpsessAccountId { get; set; }
        string BenefeciaryBankCountry { get; set; }
        string ItemType { get; set; }
        DateTime? ActualValueDate { get; set; }
    }
    [Endpoint("WUBS.Endpoints.PaymentReleasePolicy")]
    public interface IPaymentReleaseRulesUpdated
    {
        long PaymentId { get; set; }
        long PaymentInstructionId { get; set; }
        DateTime PaymentReleaseRulesTimeoutExpirationDateTime { get; set; }
        DateTime ActualValueDate { get; set; }
        DateTime AchievablePaymentValueDate { get; set; }
        DateTime AchievablePaymentReleaseStartDateTime { get; set; }
        DateTime AchievablePaymentReleaseDeadline { get; set; }
        int PaymentMethodId { get; set; }
    }

    [Endpoint("WUBS.Endpoints.PaymentReleasePolicy")]
    public interface IAutoReleaseOutgoingPaymentReleasePolicyMet
    {
        long PaymentId { get; set; }
        long PaymentInstructionId { get; set; }
        string PaymentStatus { get; set; }
        string TransactionReference { get; set; }
        DateTime ActualValueDate { get; set; }
        DateTime AchievableValueDate { get; set; }
        DateTime ReleaseDeadline { get; set; }
    }

    [Endpoint("WUBS.Endpoints.PaymentRelease")]
    public interface IPaymentStatusChangedToReleaseInProcess
    {
        long PaymentId { get; set; }
        long PaymentInstructionId { get; set; }
    }

    [Endpoint("WUBS.Endpoints.PaymentRelease")]
    public interface IBatchCreatedForPayment
    {
        long PaymentId { get; set; }
    }

    [Endpoint("WUBS.Endpoints.PaymentRelease")]
    public interface IBatchGeneratedForPayments
    {
        long PaymentBatchId { get; set; }
        string PaymentBatchData { get; set; }
    }

    [Endpoint("WUBS.Gateways.GPGOutbound")]
    public interface IPaymentFileSentToGPG
    {
        long PaymentBatchId { get; set; }
    }

    [Endpoint("WUBS.Gateways.GPG")]
    public interface IPaymentFileReceivedByGPG
    {
        long PaymentBatchId { get; set; }
    }


    [Endpoint("WUBS.Gateways.GPG")]
    public interface IPaymentBatchConfirmed
    {
        long PaymentBatchId { get; set; }
    }

    [Endpoint("WUBS.Endpoints.Client")]
    public interface IPaymentCreatedForTesting
    {
        long PaymentId { get; set; }
    }
}
