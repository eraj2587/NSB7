using System;
using WUBS.Cct.Treasury.DomainModel.Enums;

namespace WUBS.Cct.Treasury.DomainModel.Trading
{
    [Serializable]
    public class MarkupComponent
    {
        private decimal markupInPointsInClientConvention;

        public decimal MarkupPointsInClientConvention
        {
            get
            {
                if ((ClientRateConvention == RateConvention.Indirect && TradeDirection == TradeDirection.Sell) ||
                    ClientRateConvention == RateConvention.Direct && TradeDirection == TradeDirection.Buy)
                    return -markupInPointsInClientConvention;

                return markupInPointsInClientConvention;
            }
            set { markupInPointsInClientConvention = value; }
        }

        public RateConvention ClientRateConvention { get; set; }
        public TradeDirection TradeDirection { get; set; }
    }
}
