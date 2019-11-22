using System;
using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts.MassPay
{
    [DataContract(Namespace = "http://schemas.business.test.com/2015/10/Opp")]
    public class PaymentDetails
    {
        [DataMember]
        public int Id;
        [DataMember]
        public string InstructionId;
        [DataMember]
        public string CustomerPaymentId;
        [DataMember]
        public string PartnerCustomerId;
        [DataMember]
        public string BeneficiaryName;
        [DataMember]
        public string BankAccountNumber;
        [DataMember]
        public string OutOfHoldingConfirmationId;
        [DataMember]
        public decimal Amount;
        [DataMember]
        public string CurrencyCode;
        [DataMember]
        public DateTime CreatedDate;
        [DataMember]
        public string PartnerName;
        [DataMember]
        public SettlementMethod Method;
        [DataMember]
        public string Status;
        [DataMember]
        public string CustomerAccount;
    }
}
