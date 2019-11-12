using System;
using WUBS.Cct.Treasury.DomainModel.Entities;
using WUBS.Cct.Treasury.DomainModel.Enums;

namespace WUBS.Cct.Treasury.DomainModel.FundingSource
{
    [Serializable]
    public class ForwardContractFundingSource : LineItemFundingSource
    {
        public Order ForwardOrderWithContributingLineItem { get; set; }
        
        public override LineItemFundingMethod FundingMethod
        {
            get { return LineItemFundingMethod.Multiple; }
        }

        public override int QuoteId { get; set; }
    }

    [Serializable]
    public class ReplacedByForwardContractFundingSourceVisitor : LineItemFundingSource
    {
        public override LineItemFundingMethod FundingMethod
        {
            get { return LineItemFundingMethod.Multiple; }
        }
        public override int QuoteId { get; set; }
    }
}
