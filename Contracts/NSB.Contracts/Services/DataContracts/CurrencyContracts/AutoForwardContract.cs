using System;
using System.Runtime.Serialization;
using NSB.Contracts.Services.DataContracts.CurrencyContracts.Pricing;

namespace NSB.Contracts.Services.DataContracts.CurrencyContracts
{
    [DataContract]
    public class AutoForwardContract : ForwardContract
    {
        [DataMember]
        public string ContractId { get; set; }
        [DataMember]
        public ContractType Type { get; set; }
        [DataMember]
        public ContractStatus Status { get; set; }
        [DataMember]
        public Money TradeBalance { get; set; }
        [DataMember]
        public Money SettlementBalance { get; set; }
        [DataMember]
        public string Customer { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
        [DataMember]
        public string Contact { get; set; }
        [DataMember]
        public string ExternalSystem { get; set; }
        [DataMember]
        public string ExternalSystemReference { get; set; }
        [DataMember]
        public string PartnerOrderReference { get; set; }
        [DataMember]
        public Money ExpectedDeposit { get; set; }
        [DataMember]
        public Money DepositPaid { get; set; }
        [DataMember]
        public bool CanPredeliver { get; set; }
        [DataMember]
        public bool CanDrawdown { get; set; }

        public AutoForwardContract(long id, ContractPricingComponent pricingComponent, bool isAggregated)
        : base(id, pricingComponent, isAggregated)
        {
            Id = id;
        }
    }

    [DataContract]
    public class AutoForwardContractDrawdown: AutoContractDrawdown
    {

        [DataMember]
        public string CustomerId { get; set; }
        [DataMember]
        public DateTimeOffset BookedOn { get; set; }
        [DataMember]
        public string BookedBy { get; set; }
        [DataMember]
        public string PartnerSystem { get; set; }
        [DataMember]
        public string PartnerOrderReference { get; set; }
        [DataMember]
        public string PartnerItemReference { get; set; }
        [DataMember]
        public string OderReference { get; set; }
        [DataMember]
        public string ItemReference { get; set; }
        [DataMember]
        public string SettlementMethod { get; set; }
        [DataMember]
        public string PaymentMethod { get; set; }
        [DataMember]
        public string CustomerReference { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public string PayeeId { get; set; }

        public AutoForwardContractDrawdown(long id, string contractId, ContractPricingComponent pricingComponent, Contract parentContract, string orderId, int lineItemId, DateTime valueDate) : base(id, contractId, pricingComponent, parentContract, orderId, lineItemId, valueDate)
        {
            ContractId = contractId;
            OrderId = orderId;
            LineItemId = lineItemId;
            ValueDate = valueDate;
        }

    }

    [DataContract]
    public class ContractActivity
    {
        [DataMember]
        public string ContractId { get; set; }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int RelatedId { get; set; }
        [DataMember]
        public string Activity { get; set; }
        [DataMember]
        public Money ActivityVolume { get; set; }
        [DataMember]
        public string RelatedReferenceNumber { get; set; }
        [DataMember]
        public DateTimeOffset ActivityDate { get; set; }
        [DataMember]
        public string ActivityBy { get; set; }
    }

}
