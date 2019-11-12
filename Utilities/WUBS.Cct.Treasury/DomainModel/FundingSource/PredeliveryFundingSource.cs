
using System;

namespace WUBS.Cct.Treasury.DomainModel.FundingSource
{
    [Serializable]
    public class PredeliveryFundingSource : ForwardContractFundingSource
    {
        private int PredeliveryQuoteId { get; set; }

        public override int QuoteId
        {
            get { return PredeliveryQuoteId; }
            set { PredeliveryQuoteId = value; }
        }
    }
}
