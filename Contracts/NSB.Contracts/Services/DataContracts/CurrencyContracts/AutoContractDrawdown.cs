using System;
using System.Runtime.Serialization;
using NSB.Contracts.Services.DataContracts.CurrencyContracts.Pricing;

namespace NSB.Contracts.Services.DataContracts.CurrencyContracts
{
    [DataContract]
    public class AutoContractDrawdown : Drawdown
    {
        [DataMember]
        public string ContractId { get; set; }
        [DataMember]
        public string OrderId { get; set; }
        [DataMember]
        public int LineItemId { get; set; }
        [DataMember]
        public DateTime ValueDate { get; set; }

        public AutoContractDrawdown() { }

        public AutoContractDrawdown(long id, string contractId, ContractPricingComponent pricingComponent, Contract parentContract, string orderId, int lineItemId, DateTime valueDate) : base(id, pricingComponent, parentContract)
        {
            ContractId = contractId;
            OrderId = orderId;
            LineItemId = lineItemId;
            ValueDate = valueDate;
        }
    }
}