using System;
using System.Runtime.Serialization;
using NSB.Contracts.Services.DataContracts.CurrencyContracts.Time;
using NSB.Contracts.Services.DataContracts.Orders;

namespace NSB.Contracts.Services.DataContracts.CurrencyContracts.Pricing
{
    [DataContract]
    public class AutoSpotContractPricingComponent : ContractPricingComponent
    {
        [DataMember]
        public QuoteType QuoteType { get; set; }
        [DataMember]
        public byte? ManualQuoting { get; set; } // TODO: Change to enum
        [DataMember]
        public decimal CustomerMarkup { get; set; }
        [DataMember]
        public decimal CustomerForwardPoints { get; set; }
        [DataMember]
        public CustomerRatePricingModel? CustomerRatePricingModel { get; set; }
        [DataMember]
        public decimal MarketForwardPoints { get; set; }
        [DataMember]
        public decimal CostSpread { get; set; }
        [DataMember]
        public DateTime CostRateCalculatedOn { get; set; }
        [DataMember]
        public decimal? Profit { get; set; }
        [DataMember]
        public Currency ReportingCurrency { get; set; }
        [DataMember]
        public Pricing.Rate SettlementCurrencyToUsdRate { get; set; }
        [DataMember]
        public Pricing.Rate ReportingCurrencyToUsdRate { get; set; }
        [DataMember]
        public DateTimeOffset? RateExpiration { get; set; }

        public AutoSpotContractPricingComponent()
        {
            
        }

        public AutoSpotContractPricingComponent(Money tradeVolume, Money settlementVolume, Pricing.Rate customerSpotRate, Pricing.Rate costSpotRate, RateDirection rateDirection, TradeDirection tradeDirection, DateRange startEndDates, bool isAmountInSettlementCurrency) : base(tradeVolume, settlementVolume, customerSpotRate, costSpotRate, rateDirection, tradeDirection, startEndDates, isAmountInSettlementCurrency)
        {
            
        }

    }
}