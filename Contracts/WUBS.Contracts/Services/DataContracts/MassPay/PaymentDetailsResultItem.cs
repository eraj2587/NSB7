using System;
using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts.MassPay
{
    public class PaymentDetailsResultItem : PaymentDetails
    {
        [DataMember]
        public string GPGBatchId;
        [DataMember]
        public DateTime? OutOfHoldingDate;
        [DataMember]
        public DateTime? LastPaymentDate;
        [DataMember]
        public string StatusReason;
        [DataMember]
        public string StatusReasonCode;
        [DataMember]
        public string RoutingNumber;
        [DataMember]
        public string SwiftCode;
        [DataMember]
        public string BankCountryCode;
        [DataMember]
        public string BatchId;
        [DataMember]
        public string IntoHoldingConfirmationNumber;
        [DataMember]
        public SettlementMethod SettlementMethod;
        [DataMember]
        public string RemitterId;
        [DataMember]
        public BusinessType Type;
        [DataMember]
        public string BusinessName;
        [DataMember]
        public Address RemitterAddress;
        [DataMember]
        public bool IsCoupled;
        [DataMember]
        public string ReturnedCurrencyCode;
        [DataMember]
        public decimal? ReturnedAmount;

        public bool IsReturnedPayment()
        {
            return !string.IsNullOrEmpty(Status) && Status.Equals("Returned");
        }
    }
}
