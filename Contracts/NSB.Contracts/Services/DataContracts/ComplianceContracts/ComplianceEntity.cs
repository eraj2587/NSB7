using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts.ComplianceContracts
{
    [DataContract]
    [KnownType(typeof(CompliancePayment))]
    [KnownType(typeof(ComplianceClient))]
    public class ComplianceEntity { }

    [DataContract]
    public class CompliancePayment : ComplianceEntity
    {
        [DataMember]
        [JsonProperty(PropertyName = "sourcePaymentID")]
        public string SourcePaymentId { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "platform")]
        public string PaymentPlatform { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "sourcePlatformID")]
        public string SourcePlatformId { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "bookingSystemOrderID")]
        public string BookingSystemOrderId { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "bookingSystemName")]
        public string BookingSystemName { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "orderID")]
        public string OrderId { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "amount")]
        public string Amount { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "feeAmount")]
        public string FeeAmount { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "feeCurrency")]
        public string FeeCurrency { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "creationDate")]
        public string PaymentCreationDate { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "creationDateUTC")]
        public string PaymentCreationDateUtc { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "orderTypeName")]
        public string OrderTypeName { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "itemTypeName")]
        public string ItemTypeName { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "lineItemID")]
        public string LineItemId { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "confirmationNumber")]
        public string ConfirmationNumber { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "lastUpdated")]
        public string PaymentLastUpdated { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "lastUpdatedUTC")]
        public string PaymentLastUpdatedUtc { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "method")]
        public string PaymentMethod { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "reasonForTransaction")]
        public string PaymentReasonForTransaction { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "orderReasonForTransaction")]
        public string OrderReasonForTransaction { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "receiverInformationText")]
        public string ReceiverInformationText { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "reference")]
        public string Reference { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "expectedValueDate")]
        public string ExpectedValueDate { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "deadlineDate")]
        public string DeadlineDate { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "isDoddFrank")]
        public string IsDoddFrank { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "notifiedPerson")]
        public NotifiedPerson NotifiedPerson { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "byOrderOf")]
        public string ByOrderOf { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "BIC")]
        public string Bic { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "yourID")]
        public string YourId { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "WUReceiver")]
        public ComplianceReceiverInformation WuReceiver { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "lineItemNo")]
        public string LineItemNo { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "settlementCurrency")]
        public string SettlementCurrency { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "buySell")]
        public string BuySell { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "isOutgoing")]
        public string IsOutgoing { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "branchID")]
        public string BranchId { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "delivery")]
        public ComplianceDelivery Delivery { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "recipient")]
        public ComplianceCategory Recipient { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "sender")]
        public ComplianceCategory Sender { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "thirdPartyRemitter")]
        public ComplianceCategory ThirdPartyRemitter { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "thirdPartyInstructorID")]
        public string ThirdPartyInstructorId { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "beneficiaryRemitter")]
        public ComplianceCategory BeneficiaryRemitter { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "authorizedUser")]
        public ComplianceCategory AuthorizedUser { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "customerID")]
        public string CustomerId { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "senderBankAccountID")]
        public string SenderBankAccountId { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "recipientBankAccountID")]
        public string RecipientBankAccountId { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "remitterBankAccountID")]
        public string RemitterBankAccountId { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "intermediaryBankAccountID")]
        public string IntermediaryBankAccountId { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "initiator")]
        public string Initiator { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "parties")]
        public List<ComplianceParty> ComplianceParties { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "bankDetails")]
        public List<ComplianceBankAccount> ComplianceBankAccounts { get; set; }
    }

    [DataContract]
    public class ComplianceClient : ComplianceEntity { }
}
