using System;
using WUBS.Cct.Treasury.DomainModel.Enums;
using WUBS.Cct.Treasury.DomainModel.Trading;

namespace WUBS.Cct.Treasury.DomainModel.FundingSource
{
    [Serializable]
    public abstract class LineItemFundingSource
    {
        public abstract LineItemFundingMethod FundingMethod { get; }
        public abstract int QuoteId { get; set; }
        public ClientRateComponent ClientRateComponent { get; set; }
        public bool IsQuoted { get { return QuoteId > 0; } }
    }
}
