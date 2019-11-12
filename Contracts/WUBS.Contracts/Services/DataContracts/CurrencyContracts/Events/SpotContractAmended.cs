using System.Runtime.Serialization;
using WUBS.Contracts.Services.DataContracts.CurrencyContracts.Pricing;

namespace WUBS.Contracts.Services.DataContracts.CurrencyContracts.Events
{
    [DataContract]
    public class SpotContractAmended : ContractEvent, IPricingComponentChanged
    {
        [DataMember]
        public ContractPricingComponent NewPricingComponent { get; set; }
    }
}
