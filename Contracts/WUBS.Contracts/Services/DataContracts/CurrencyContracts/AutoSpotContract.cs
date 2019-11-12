using System.Runtime.Serialization;
using WUBS.Contracts.Services.DataContracts.CurrencyContracts.Pricing;

namespace WUBS.Contracts.Services.DataContracts.CurrencyContracts
{
    [DataContract]
    public class AutoSpotContract : SpotContract
    {
        [DataMember]
        public string ContractId { get; set; }
        [DataMember]
        public ContractType Type { get; set; }
        [DataMember]
        public ContractStatus Status { get; set; }
        [DataMember]
        public ContractExecutionMethod ExecutionMethod { get; set; }
        [DataMember]
        public Money TradeBalance { get; set; }
        [DataMember]
        public Money SettlementBalance { get; set; }

        [DataMember]
        public string Office { get; set; }
        [DataMember]
        public string Customer { get; set; }
        [DataMember]
        public string Contact { get; set; }
        [DataMember]
        public string BookingSource { get; set; }
        [DataMember]
        public string ExternalSystem { get; set; }
        [DataMember]
        public string ExternalSystemReference { get; set; }

        public AutoSpotContract()
        {
        }

        public AutoSpotContract(long id, string contractId, ContractPricingComponent pricingComponent) : base(id, pricingComponent)
        {
            ContractId = contractId;
        }
    }
}
