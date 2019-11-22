using System.Runtime.Serialization;
using NSB.Contracts.Services.DataContracts.CurrencyContracts.Pricing;

namespace NSB.Contracts.Services.DataContracts.CurrencyContracts.Events
{
    [DataContract]
    public class SpotContractAmended : ContractEvent, IPricingComponentChanged
    {
        [DataMember]
        public ContractPricingComponent NewPricingComponent { get; set; }
    }
}
