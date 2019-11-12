using System;
using System.Linq;
using WUBS.Cct.Treasury.DomainModel.Entities;
using WUBS.Cct.Treasury.DomainModel.Enums;
using WUBS.Cct.Treasury.DomainModel.FundingSource;
using WUBS.Cct.Treasury.Services;

namespace WUBS.Cct.Treasury.Mappers.Visitors
{
    public class NonQuotedMatureFuturePaymentRepoOrderVisitor : OrderVisitor
    {
        private readonly ICctTreasuryOrderService orderMapper;

        public NonQuotedMatureFuturePaymentRepoOrderVisitor(ICctTreasuryOrderService orderMapper)
        {
            this.orderMapper = orderMapper;
        }

        public override void Visit(Order order)
        {
            if (order.OrderType == OrderType.MatureFuturePaymentsOrderRepurchase)
            {
                order.LineItems.ForEach(SetFundingSource);
            }
        }

        private void SetFundingSource(LineItem lineItem)
        {
            if (lineItem.FundingSource == null || lineItem.FundingSource is NullLineItemFundingSource)
                lineItem.FundingSource = GetFundingSource(lineItem);
        }

        private LineItemFundingSource GetFundingSource(LineItem mfpRepoLineItem)
        {
            if (mfpRepoLineItem.RelatedLineItemId.HasValue && mfpRepoLineItem.RelatedLineItemId > 0)
            {
                var relatedOrder = orderMapper.GetOrderByLineItemId(mfpRepoLineItem.RelatedLineItemId.Value, false);
                var relatedLineItem = relatedOrder.LineItems.FirstOrDefault(li => li.Id == mfpRepoLineItem.RelatedLineItemId.Value);

                if (relatedLineItem == null)
                    throw new ArgumentNullException(string.Format("Can't find related MFP line item '{0}'", relatedLineItem.Id));
                
                if (relatedLineItem.FundingSource != null)
                    return relatedLineItem.FundingSource;
            }

            return new NullLineItemFundingSource();
        }
    }
}