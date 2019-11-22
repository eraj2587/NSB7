using System;
using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts
{
    [DataContract]
    public class VirtualAccountActivity
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public int VirtualAccountId { get; set; }

        [DataMember]
        public int LineItemId { get; set; }

        [DataMember]
        public string OrderId { get; set; }

        [DataMember]
        public DateTimeOffset TransactionDate { get; set; }

        [DataMember]
        public string TransactionReferenceNumber { get; set; }

        [DataMember]
        public Currency Currency { get; set; }

        [DataMember]
        public string ClientId { get; set; }

        [DataMember]
        public string Payer { get; set; }

        [DataMember]
        public string Payee { get; set; }

        [DataMember]
        public int TransactionTypeId { get; set; }

        [DataMember]
        public string TransactionDescription { get; set; }

        [DataMember]
        public string SettlementMethod { get; set; }

        [DataMember]
        public string DeliveryMethod { get; set; }

        [DataMember]
        public decimal Amount { get; set; }

        [DataMember]
        public decimal Rate { get; set; }

        [DataMember]
        public string OriginalOrderingSystem { get; set; }

        [DataMember]
        public string OriginalOrderId { get; set; }

        [DataMember]
        public string OriginalPaymentId { get; set; }

        [DataMember]
        public decimal BookBalance { get; set; }

        [DataMember]
        public decimal AvailableBalance { get; set; }

        [DataMember]
        public decimal PendingBalance { get; set; }

        [DataMember]
        public decimal ReserveBalance { get; set; }

        [DataMember]
        public bool Credit { get; set; }

        [DataMember]
        public bool Debit { get; set; }

        [DataMember]
        public int StatusId { get; set; }

        [DataMember]
        public string UserId { get; set; }

        [DataMember]
        public DateTimeOffset ActivityDate { get; set; }

        [DataMember]
        public string Platform { get; set; }
    }
}
