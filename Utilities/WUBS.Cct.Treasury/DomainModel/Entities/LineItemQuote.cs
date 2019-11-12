using System;
using WUBS.Cct.Treasury.DomainModel.Enums;
using WUBS.Cct.Treasury.DomainModel.Financial;

namespace WUBS.Cct.Treasury.DomainModel.Entities
{
    [Serializable]
    public class LineItemQuote : Quote
    {
        public decimal ForwardPoints { get; set; }
        public decimal MarkupPct { get; set; }
        public decimal MarkupInPointsInClientConvention { get; set; }

        public Rate SpotRate { get; set; }

        public Rate ClientRate { get; set; }

        public DateTime StartValueDate { get; set; }
        public DateTime EndValueDate { get; set; }

        public TradeDirection TradeDirection { get; set; }
    }
}
