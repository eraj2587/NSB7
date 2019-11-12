using System;
using System.Runtime.Serialization;
using WUBS.Contracts.Services.DataContracts.CurrencyContracts.Time;
using WUBS.Contracts.Services.DataContracts.Orders;

namespace WUBS.Contracts.Services.DataContracts.CurrencyContracts.Pricing
{
    [DataContract]
    [Serializable]
    public class ContractPricingComponent
    {
        [DataMember]
        public TradeDirection TradeDirection { get; set; }
        [DataMember]
        public Money TradeVolume { get; set; }
        [DataMember]
        public Money SettlementVolume { get; set; }
        [DataMember]
        public Rate CustomerSpotRate { get; set; }
        [DataMember]
        public Rate CostSpotRate { get; set; }
        [DataMember]
        public DateRange StartEndDates { get; set; }
        [DataMember]
        public RateDirection RateDirection { get; set; }
        [DataMember]
        public decimal CostForwardPoints { get; set; }
        [DataMember]
        public Rate MarketSpotRate { get; set; }
        [DataMember]
        public bool IsAmountInSettlementCurrency { get; set; }

        public ContractPricingComponent(Money tradeVolume,
            Money settlementVolume,
            Rate customerSpotRate,
            Rate costSpotRate,
            RateDirection rateDirection,
            TradeDirection tradeDirection,
            DateRange startEndDates,
            bool isAmountInSettlementCurrency)
        {
            TradeVolume = tradeVolume;
            SettlementVolume = settlementVolume;
            CustomerSpotRate = customerSpotRate;
            CostSpotRate = costSpotRate;
            RateDirection = rateDirection;
            TradeDirection = tradeDirection;
            StartEndDates = startEndDates;
            IsAmountInSettlementCurrency = isAmountInSettlementCurrency;
        }

        public bool IsTraderBuy
        {
            get { return TradeDirection == TradeDirection.WUBSBuy; }
        }

        public bool IsQuotationDirect
        {
            get { return RateDirection == RateDirection.Direct; }
        }

        internal bool IsTraderSell
        {
            get { return !IsTraderBuy; }
        }

        internal Money unitMoney
        {
            get { return IsQuotationDirect ? TradeVolume : SettlementVolume; }
        }

        internal Money refMoney
        {
            get { return IsQuotationDirect ? SettlementVolume : TradeVolume; }
        }

        public void InvertTradeDirection()
        {
            TradeDirection = TradeDirection == TradeDirection.WUBSBuy ? TradeDirection.WUBSSell : TradeDirection.WUBSBuy;
        }

        public void InvertQuoteConvention()
        {
            RateDirection = RateDirection == RateDirection.Direct ? RateDirection.Indirect : RateDirection.Direct;
        }

        public ContractPricingComponent()
        {
            var now = DateTime.UtcNow;
            StartEndDates = new DateRange(now, now);
            CostSpotRate = Rate.NullRate;
            CustomerSpotRate = Rate.NullRate;
        }

        public ContractPricingComponent(ContractPricingComponent component)
        {
            RateDirection = component.RateDirection;
            TradeVolume = component.TradeVolume;
            CustomerSpotRate = component.CustomerSpotRate;
            CostSpotRate = component.CostSpotRate;
            StartEndDates = component.StartEndDates;
            SettlementVolume = component.SettlementVolume;
            TradeDirection = component.TradeDirection;
            CostForwardPoints = component.CostForwardPoints;
            IsAmountInSettlementCurrency = component.IsAmountInSettlementCurrency;
        }
    }
}
