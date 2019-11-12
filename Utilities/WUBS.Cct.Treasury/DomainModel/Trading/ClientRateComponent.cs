using System;
using WUBS.Cct.Treasury.DomainModel.Financial;

namespace WUBS.Cct.Treasury.DomainModel.Trading
{
    [Serializable]
    public class ClientRateComponent
    {
        public CostRateComponent CostRateComponent { get; set; }

        public Rate ClientRate { get; set; }

        public decimal MarkupPercentageCostRateConvention
        {
            get
            {
                return MarkupPointsInClientConvention == 0m ? 0m : ComputeMarkupPercentage();
            }
        }

        public decimal MarkupPointsInClientConvention { get; set; }

        private decimal ComputeMarkupPercentage()
        {
            var costRate = CostRateComponent.CostRate;
            if (costRate.RoundedValue == 0m)
                return 0m;

            var clientRateInMarketConvention = costRate.RateConvention == ClientRate.RateConvention
                ? ClientRate
                : new Rate(costRate.UnitCurrency, costRate.RefCurrency, 1 / ClientRate.RoundedValue, costRate.MetaData, costRate.RateConvention);

            return Math.Round(Math.Abs(clientRateInMarketConvention.RoundedValue / costRate.RoundedValue - 1) * 100, 2);
        }
    }
}
