using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using WUBS.Contracts.Services.DataContracts;

namespace WUBS.Contracts.Services
{
    [ServiceContract(Namespace = "http://schema.business.westernunion.com/contracts/")]
    public interface IPaymentManager
    {
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void ApplyHoldingBalanceChange(ApplyHoldingBalanceChangeRequest request);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        ProcessPaymentResponse ProcessPayments(ProcessPaymentRequest request);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void ApplyValueDateChange(ApplyValueDateChangeRequest request);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void ResendPaymentBatch(ResendPaymentBatchRequest request);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void UpdatePaymentToAr(List<PostPaymentRequest> request);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        PaymentCaseResponse StorePaymentCase(PaymentCaseRequest paymentCaseRequest);  
    }
    
    [DataContract]
    public class ApplyHoldingBalanceChangeRequest
    {
        [DataMember]
        public string PaymentId { get; set; }
        [DataMember]
        public Money Amount { get; set; }
        [DataMember]
        public string CustomerId { get; set; }
        [DataMember]
        public bool IsCredit { get; set; }
    }


    [DataContract]
    public class ApplyValueDateChangeRequest
    {
        [DataMember]
        public string PaymentId { get; set; }
        [DataMember]
        public DateTime ValueDate { get; set; }
    }

    [DataContract]
    [KnownType(typeof(ProcessCommittedPaymentRequest))]
    [KnownType(typeof(AvailableForReleaseRequest))]
    [KnownType(typeof(HoldPaymentRequest))]
    [KnownType(typeof(ManualReleaseRequest))]
    [KnownType(typeof(DeletePaymentRequest))]
    [KnownType(typeof(UnsendPaymentRequest))]
    public abstract class ProcessPaymentRequest
    {
        [DataMember]
        public int OpsEssId { get; set; }
        [DataMember]
        public bool IsIncoming { get; set; }
        [DataMember]
        public int OrderDetailId { get; set; }
        [DataMember]
        public int ClientOrderId { get; set; }
    }

    [DataContract]
    public class ProcessPaymentResponse
    {
        [DataMember]
        public string PaymentId { get; set; }
    }

    [DataContract]
    public class ProcessCommittedPaymentRequest : ProcessPaymentRequest { }

    [DataContract]
    public class AvailableForReleaseRequest : ProcessPaymentRequest
    {
        [DataMember]
        public bool IsSuccessful { get; set; }
        [DataMember]
        public string ScanResultMessage { get; set; }
    }

    [DataContract]
    public class HoldPaymentRequest : ProcessPaymentRequest
    {
        [DataMember]
        public bool IsPaymentOnHold { get; set; }
        [DataMember]
        public string HoldReason { get; set; }
    }

    [DataContract]
    public class ManualReleaseRequest : ProcessPaymentRequest { }

    [DataContract]
    public class DeletePaymentRequest : ProcessPaymentRequest { }

    [DataContract]
    public class UnsendPaymentRequest : ProcessPaymentRequest { }

    public class ResendPaymentBatchRequest
    {
        [DataMember]
        public long PaymentBatchId { get; set; }
    }

    [DataContract]

    public class PostPaymentRequest
    {
        [DataMember]
        public long PaymentBatchId { get; set; }

        [DataMember]
        public string PaymentBatchDetailIds { get; set; }

        [DataMember]
        public string EssIds { get; set; }

        [DataMember]
        public string paymentBatchDetailIdsAll { get; set; }

        [DataMember]
        public int UserId { get; set; }

    }
}