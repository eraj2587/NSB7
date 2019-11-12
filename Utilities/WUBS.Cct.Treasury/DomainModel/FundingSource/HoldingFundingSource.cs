using System;
using WUBS.Cct.Treasury.DomainModel.Enums;

namespace WUBS.Cct.Treasury.DomainModel.FundingSource
{
    [Serializable]
    public class HoldingFundingSource : LineItemFundingSource, IClientRateComponentProvider
    {
        public override LineItemFundingMethod FundingMethod
        {
            get { return LineItemFundingMethod.Holding; }
        }
        public override int QuoteId { get; set; }
    }
}
