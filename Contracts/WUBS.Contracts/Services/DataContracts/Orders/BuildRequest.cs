using System;
using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts.Orders
{
    [DataContract]
    [KnownType(typeof(NewOrder))]
    [KnownType(typeof(UpdateOrder))]
    public abstract class BuildRequest
    {
    }

    [DataContract]
    public class NewOrder : BuildRequest
    {
        [DataMember]
        public string CustomerId { get; set; }
        [DataMember]
        public string ContactId { get; set; }
        [DataMember]
        public string UserId { get; set; }
        [DataMember]
        public string CustomerReferenceNumber { get; set; }
        [DataMember]
        public string ExternalReference { get; set; }
        [DataMember]
        public Channel Channel { get; set; }
        [DataMember]
        public NewLineItem[] LineItems { get; set; }
        [DataMember]
        public NewSettlement[] Settlements { get; set; }
    }

    [DataContract]
    public class UpdateOrder : NewOrder
    {
        [DataMember]
        public string OrderId { get; set; }
    }

    [DataContract]
    public class NewLineItem
    {
        [DataMember]
        public int LineItemId { get; set; }
        [DataMember]
        public PaymentMethod PaymentMethod { get; set; }
        [DataMember]
        public string PayeeId { get; set; }
        [DataMember]
        public string TradeCurrency { get; set; }
        [DataMember]
        public string SettlementCurrency { get; set; }
        [DataMember]
        public decimal Amount { get; set; }
        [DataMember]
        public FixedAmountType FixedAmountType { get; set; }
        [DataMember]
        public string CustomerReference { get; set; }
        [DataMember]
        public DateTime? TradeValueDate { get; set; }
        [DataMember]
        public NatureOfTransaction NatureOfTransaction { get; set; }
        [DataMember]
        public ReasonForTransaction ReasonForTransaction { get; set; }
        [DataMember]
        public string ReasonForTransactionText { get; set; }
        [DataMember]
        public string ExternalReference { get; set; }
        [DataMember]
        public string Comment { get; set; }
    }

    [DataContract]
    public class NewSettlement
    {
        [DataMember]
        public int SettlementId { get; set; }
        [DataMember]
        public SettlementMethod SettlementMethod { get; set; }
        [DataMember]
        public string SettlementCurrency { get; set; }
        [DataMember]
        public string CustomerReference { get; set; }
    }

    [DataContract]
    public class RepurchaseOrder : BuildRequest
    {
        [DataMember]
        public string OrderId { get; set; }
        [DataMember]
        public int[] LineItems { get; set; }
        [DataMember]
        public string ContactId { get; set; }
    }
}
