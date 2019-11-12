using WUBS.Contracts.Services.DataContracts.CurrencyContracts.Pricing;

namespace WUBS.Contracts.Services.DataContracts.CurrencyContracts.Events
{
    public interface IPricingComponentChanged
    {
        ContractPricingComponent NewPricingComponent { get; set; }
    }
}
