using WUBS.Cct.Treasury.DomainModel.Entities;
using WUBS.Cct.Treasury.DomainModel.FundingSource;
using WUBS.Cct.Treasury.Mappers.Factories;
using WUBS.Cct.Treasury.Mappers.Interfaces;

namespace WUBS.Cct.Treasury.Mappers.Visitors
{
    public class NonQuotedLineItemVisitor : LineItemVisitor
    {
        private readonly IQuoteMapper quoteMapper;
        private readonly ILineItemMapper lineItemMapper;

        public NonQuotedLineItemVisitor(ILineItemMapper lineItemMapper, IQuoteMapper quoteMapper)
        {
            this.lineItemMapper = lineItemMapper;
            this.quoteMapper = quoteMapper;
        }

        public override void Visit(LineItem lineItem)
        {
            if (lineItem.FundingSource == null || lineItem.FundingSource is NullLineItemFundingSource)
                lineItem.FundingSource = GetFundingSourceByRelatedItem(lineItem);
        }

        private LineItemFundingSource GetFundingSourceByRelatedItem(LineItem lineItem)
        {
            var origQuoteId = GetRelatedQuoteId(lineItem);

            if (origQuoteId > 0)
            {
                var clientRateComponent = FundingSourceFactoryHelper.CreateClientRateComponent(quoteMapper.GetLineItemQuote(origQuoteId));

                var originatingFundingSource = FundingSourceFactoryHelper.CreateFxFundingSource(origQuoteId, clientRateComponent);

                return lineItem.ItemRateValue > 0 ? GetUpdatedFundingSource(originatingFundingSource, lineItem.ItemRateValue) : originatingFundingSource;

            }
            return new NullLineItemFundingSource();
        }

        private int GetRelatedQuoteId(LineItem lineItem)
        {
            var origQuoteId = 0;

            if (lineItem.RelatedLineItemId.HasValue && lineItem.RelatedLineItemId > 0)
                origQuoteId = lineItemMapper.GetQuoteIdByRelatedItemId(lineItem.RelatedLineItemId.Value);
            
            if (origQuoteId == 0 && lineItem.ContributingItemId > 0)
                origQuoteId = lineItemMapper.GetQuoteIdByRelatedItemId(lineItem.ContributingItemId);
            
            return origQuoteId;
        }

        private LineItemFundingSource GetUpdatedFundingSource(LineItemFundingSource originatingFundingSource, decimal itemRateValue)
        {
            return
                FundingSourceFactoryHelper.CreateFxFundingSource(originatingFundingSource.QuoteId,
                    FundingSourceFactoryHelper.CreateClientRateComponent(
                        quoteMapper.GetRepurchaseLineItemQuote(itemRateValue,
                            originatingFundingSource.ClientRateComponent)));
        }
    }
}
