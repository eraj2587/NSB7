using System;
using System.Collections.Generic;
using WUBS.Cct.Treasury.DomainModel.Entities;
using WUBS.Cct.Treasury.DomainModel.Enums;

namespace WUBS.Cct.Treasury.DomainModel.FundingSource
{
    [Serializable]
    public class MatureFuturePaymentFundingSource : LineItemFundingSource
    {
        public IList<Order> RelatedFuturePaymentOrders { get; set; }

        public override LineItemFundingMethod FundingMethod
        {
            get { return LineItemFundingMethod.Ruesch; }
        }

        public override int QuoteId { get; set; }
    }
}
