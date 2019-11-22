using NSB.Contracts.Services.DataContracts.CurrencyContracts.Pricing;

namespace NSB.Contracts.Services.DataContracts.CurrencyContracts.Events
{
    public interface IPricingComponentChanged
    {
        ContractPricingComponent NewPricingComponent { get; set; }
    }
}
