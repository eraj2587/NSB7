using System;
using WUBS.Cct.Treasury.DomainModel.Enums;

namespace WUBS.Cct.Treasury.DomainModel.FundingSource
{
    [Serializable]
    public class NullLineItemFundingSource : LineItemFundingSource
    {
        public override LineItemFundingMethod FundingMethod
        {
            get { return LineItemFundingMethod.Ruesch; }
        }

        public override int QuoteId { get; set; }
    }
}
