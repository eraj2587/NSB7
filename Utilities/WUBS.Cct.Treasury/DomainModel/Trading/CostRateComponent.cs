using System;
using WUBS.Cct.Treasury.DomainModel.Financial;

namespace WUBS.Cct.Treasury.DomainModel.Trading
{
    [Serializable]
    public class CostRateComponent
    {
        public Rate SpotRate { get; set; }
        public decimal ForwardPoints { get; set; }
        public Rate ReutersRate { get; set; }
        public decimal SpotRateMarkup { get; set; }
        public Rate CostRate {get { return SpotRate + ForwardPoints; }}
    }
}
