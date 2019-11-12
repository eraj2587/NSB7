using System;
using System.Linq;
using WUBS.Cct.Treasury.DomainModel.Entities;
using WUBS.Cct.Treasury.DomainModel.Enums;
using WUBS.Cct.Treasury.DomainModel.FundingSource;
using WUBS.Cct.Treasury.Exceptions;
using WUBS.Cct.Treasury.Mappers.Factories;
using WUBS.Cct.Treasury.Mappers.Interfaces;
using WUBS.Cct.Treasury.Services;

namespace WUBS.Cct.Treasury.Mappers.Visitors
{
    internal class ForwardContractFundingSourceVisitor : OrderVisitor
    {
        private readonly IQuoteMapper quoteMapper;
        private readonly ICctTreasuryOrderService orderMapper;

        public ForwardContractFundingSourceVisitor(ICctTreasuryOrderService orderMapper, IQuoteMapper quoteMapper)
        {
            this.orderMapper = orderMapper;
            this.quoteMapper = quoteMapper;
        }

        public override void Visit(Order order)
        {
            if (order.OrderType == OrderType.SellPaymentOrder || order.OrderType == OrderType.SellPaymentOrderRepurchase)
            {
                order.LineItems.ForEach(SetFundingSource);
            }
        }

        private void SetFundingSource(LineItem lineItem)
        {
            if (lineItem.FundingSource is ReplacedByForwardContractFundingSourceVisitor)
                lineItem.FundingSource = CreateDrawdownFundingSource(lineItem);
        }

        private LineItemFundingSource CreateDrawdownFundingSource(LineItem lineItem)
        {
            var forwardOrder = orderMapper.GetOrderByLineItemId(lineItem.ContributingItemId, false);

            if (forwardOrder == null)
                throw new InvalidFundingSourceException(lineItem.Id);

            var forwardLineItem = forwardOrder.LineItems.SingleOrDefault();

            if (forwardLineItem == null || forwardLineItem.FundingSource == null || forwardLineItem.FundingSource.ClientRateComponent == null)
                throw new InvalidFundingSourceException(lineItem.Id);

            return IsPredelivery(lineItem, forwardLineItem.WindowStartDate)
                       ? CreatePredeliveryFundingSource(lineItem.QuoteId, forwardOrder)
                       : CreateForwardContractFundingSource(forwardOrder, forwardLineItem);
        }

        private PredeliveryFundingSource CreatePredeliveryFundingSource(int quoteId, Order forwardOrderWithContributingLineItem)
        {
            return FundingSourceFactoryHelper.CreatePredeliveryFundingSource(
                quoteId,
                forwardOrderWithContributingLineItem,
                FundingSourceFactoryHelper.CreateClientRateComponent(quoteMapper.GetLineItemQuote(quoteId)));
        }

        private static ForwardContractFundingSource CreateForwardContractFundingSource(Order forwardOrderWithContributingLineItem, LineItem forwardLineItem)
        {
            return FundingSourceFactoryHelper.CreateForwardContractFundingSource(
                forwardLineItem.FundingSource.QuoteId,
                forwardOrderWithContributingLineItem,
                forwardLineItem.FundingSource.ClientRateComponent);
        }

        internal bool IsPredelivery(LineItem lineItem, DateTime? forwardWindowStartDate)
        {
            var valueDate = lineItem.WindowStartDate ?? lineItem.ValueDate;

            if (!valueDate.HasValue || !forwardWindowStartDate.HasValue)
                throw new UnableToRetrieveValueDateException(string.Format("Can't determine predelivery status for line item id: '{0}'", lineItem.Id));

            return valueDate.Value.Date < forwardWindowStartDate.Value.Date;
        }
    }
}
