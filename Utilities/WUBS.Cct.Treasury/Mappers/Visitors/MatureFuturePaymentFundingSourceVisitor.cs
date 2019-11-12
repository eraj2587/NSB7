using System;
using System.Collections.Generic;
using System.Linq;
using WUBS.Cct.Treasury.DomainModel.Entities;
using WUBS.Cct.Treasury.DomainModel.Enums;
using WUBS.Cct.Treasury.DomainModel.Financial;
using WUBS.Cct.Treasury.DomainModel.FundingSource;
using WUBS.Cct.Treasury.DomainModel.Trading;
using WUBS.Cct.Treasury.Infrastructure.Utilities;
using WUBS.Cct.Treasury.Mappers.Factories;
using WUBS.Cct.Treasury.Mappers.Interfaces;
using WUBS.Cct.Treasury.Services;

namespace WUBS.Cct.Treasury.Mappers.Visitors
{
    internal class MatureFuturePaymentFundingSourceVisitor : OrderVisitor
    {
        private readonly ILineItemToMatureLineItemMapper lineItemToMatureLineItemMapper;
        private readonly ICctTreasuryOrderService orderMapper;
        private readonly ILineItemMapper lineItemMapper;
        private readonly IQuoteMapper quoteMapper;

        public MatureFuturePaymentFundingSourceVisitor(
            ICctTreasuryOrderService orderMapper, 
            ILineItemToMatureLineItemMapper lineItemToMatureLineItemMapper,
            ILineItemMapper lineItemMapper,
            IQuoteMapper quoteMapper)
        {
            this.lineItemToMatureLineItemMapper = lineItemToMatureLineItemMapper;
            this.orderMapper = orderMapper;
            this.lineItemMapper = lineItemMapper;
            this.quoteMapper = quoteMapper;
        }

        public override void Visit(Order order)
        {
            if (order.OrderType == OrderType.MatureFuturePaymentsOrder)
            {
                var mappings = lineItemToMatureLineItemMapper.GetLineItemMatureLineItemMappingsByMatureOrderId(order.Id);

                order.LineItems
                    .Where(li => li.FundingSource == null || li.FundingSource is NullLineItemFundingSource)
                    .ForEach(li =>
                    {
                        var relatedLineItemQuoteId = GetRelatedLineItemQuoteId(li.RelatedLineItemId);

                        li.FundingSource = relatedLineItemQuoteId > 0 
                            ? GetFundingSource(li, relatedLineItemQuoteId) 
                            : GetFundingSource(li, mappings.Where(m => m.RelatedMatureOrderLineItemId == li.Id));
                    });
                
                order.LineItems.Where(li => li.FundingSource is FxFundingSource).ForEach(ConvertFxFundingSourceToMatureFuturePaymentFundingSource);
            }
            else if (IsReissuedMatureFuturePaymentsOrder(order as LinkedOrder))
            {
                var mappings = lineItemToMatureLineItemMapper.GetLineItemMatureLineItemMappingsByMatureOrderId(((LinkedOrder)order).RelatedOrder.Id);

                order.LineItems
                    .Where(li => li.FundingSource == null || li.FundingSource is NullLineItemFundingSource)
                    .ForEach(li =>
                    {
                        var relatedLineItemQuoteId = GetRelatedLineItemQuoteId(li.RelatedLineItemId);

                        li.FundingSource = relatedLineItemQuoteId > 0 
                            ? GetFundingSource(li, relatedLineItemQuoteId) 
                            : GetFundingSource(li, mappings.Where(m => m.RelatedMatureOrderLineItemId == li.RelatedLineItemId.Value));
                    });
            }
        }

        private void ConvertFxFundingSourceToMatureFuturePaymentFundingSource(LineItem mfpLineItem)
        {
            if (mfpLineItem.RelatedLineItemId.HasValue == false)
                throw new ArgumentException(string.Format("Can't find related future payment order for mature line item id '{0}'", mfpLineItem.Id));

            mfpLineItem.FundingSource = new MatureFuturePaymentFundingSource
            {
                RelatedFuturePaymentOrders = new List<Order> { orderMapper.GetOrderByLineItemId(mfpLineItem.RelatedLineItemId.Value, false) },
                ClientRateComponent = mfpLineItem.FundingSource.ClientRateComponent,
                QuoteId = mfpLineItem.FundingSource.QuoteId
            };
        }

        private bool IsReissuedMatureFuturePaymentsOrder(LinkedOrder order)
        {
            return order != null && order.IsReissue && order.RelatedOrder != null 
                && order.RelatedOrder.OrderType == OrderType.MatureFuturePaymentsOrder;
        }

        private int GetRelatedLineItemQuoteId(int? relatedLineItemId)
        {
            return relatedLineItemId.HasValue && relatedLineItemId.Value > 0
                ? lineItemMapper.GetQuoteIdByRelatedItemId(relatedLineItemId.Value)
                : 0;
        }

        private LineItemFundingSource GetFundingSource(LineItem mfpLineItem, int relatedLineItemQuoteId)
        {
            var clientRateComponent = FundingSourceFactoryHelper.CreateClientRateComponent(quoteMapper.GetLineItemQuote(relatedLineItemQuoteId));

            var originalFundingSource = FundingSourceFactoryHelper.CreateFxFundingSource(relatedLineItemQuoteId, clientRateComponent);

            return mfpLineItem.ItemRateValue > 0 
                ? GetFundingSourceUpdatedWithItemRate(originalFundingSource, mfpLineItem.ItemRateValue) 
                : originalFundingSource;
        }

        private LineItemFundingSource GetFundingSourceUpdatedWithItemRate(LineItemFundingSource originatingFundingSource, decimal itemRateValue)
        {
            return
                FundingSourceFactoryHelper.CreateFxFundingSource(originatingFundingSource.QuoteId,
                    FundingSourceFactoryHelper.CreateClientRateComponent(
                        quoteMapper.GetRepurchaseLineItemQuote(itemRateValue,
                            originatingFundingSource.ClientRateComponent)));
        }

        private LineItemFundingSource GetFundingSource(LineItem mfpLineItem, IEnumerable<LineItemToMatureLineItemMapping> relatedFuturePaymentLineItemMappings)
        {
            if (relatedFuturePaymentLineItemMappings.Any())
            {
                var relatedFuturePaymentOrders = GetRelatedFuturePaymentOrders(relatedFuturePaymentLineItemMappings);

                if (relatedFuturePaymentOrders.Any())
                {
                    return new MatureFuturePaymentFundingSource
                    {
                        RelatedFuturePaymentOrders = relatedFuturePaymentOrders,
                        ClientRateComponent = GetWeightedAverageClientRateComponent(mfpLineItem,
                                GetRelatedFuturePaymentLineItems(relatedFuturePaymentOrders,
                                    relatedFuturePaymentLineItemMappings))
                    };
                }
            }

            return new NullLineItemFundingSource();
        }

        private List<Order> GetRelatedFuturePaymentOrders(IEnumerable<LineItemToMatureLineItemMapping> relatedFuturePaymentLineItems)
        {
            var futurePaymentOrders = new List<Order>();

            if (!relatedFuturePaymentLineItems.Any())
                return futurePaymentOrders;

            relatedFuturePaymentLineItems.ForEach(i => futurePaymentOrders.Add(orderMapper.GetOrderByLineItemId(i.OriginalLineItemId, false)));

            return futurePaymentOrders;
        }

        private IEnumerable<LineItem> GetRelatedFuturePaymentLineItems(List<Order> relatedFuturePaymentOrders, IEnumerable<LineItemToMatureLineItemMapping> relatedFuturePaymentLineItemMappings)
        {
            return relatedFuturePaymentOrders.SelectMany(
                o =>
                    o.LineItems.Where(
                        li => relatedFuturePaymentLineItemMappings.Select(m => m.OriginalLineItemId).Contains(li.Id))
                        .Select(li => li));
        }

        private ClientRateComponent GetWeightedAverageClientRateComponent(LineItem mfpLineItem, IEnumerable<LineItem> relatedFuturePaymentLineItems)
        {
            return CreateClientRateComponent(GetWeightedAverageClientRate(mfpLineItem, relatedFuturePaymentLineItems),
                GetWeightedAverageSpotRate(mfpLineItem, relatedFuturePaymentLineItems),
                CalculateWeightedAverageForwardPoints(mfpLineItem.TradeMoney.Amount, relatedFuturePaymentLineItems));
        }

        private Rate GetWeightedAverageClientRate(LineItem mfpLineItem, IEnumerable<LineItem> relatedFuturePaymentLineItems)
        {
            var firstOriginalFPLineItem = relatedFuturePaymentLineItems.First();

            return Rate.CreateRate(mfpLineItem.TradeMoney.Currency,
                mfpLineItem.SettlementMoney.Currency,
                CalculateWeightedAverageClientRate(mfpLineItem.TradeMoney.Amount, relatedFuturePaymentLineItems),
                false,
                firstOriginalFPLineItem.FundingSource.ClientRateComponent.ClientRate.MetaData,
                firstOriginalFPLineItem.FundingSource.ClientRateComponent.ClientRate.RateConvention);
        }

        private decimal CalculateWeightedAverageClientRate(decimal mfpTradeAmount, IEnumerable<LineItem> relatedFuturePaymentLineItems)
        {
            return
                relatedFuturePaymentLineItems.Sum(
                    fpLineItem =>
                        (fpLineItem.TradeMoney.Amount / mfpTradeAmount) * fpLineItem.FundingSource.ClientRateComponent.ClientRate.RoundedValue);
        }

        private Rate GetWeightedAverageSpotRate(LineItem mfpLineItem, IEnumerable<LineItem> relatedFuturePaymentLineItems)
        {
            var firstOriginalFPLineItem = relatedFuturePaymentLineItems.First();

            return Rate.CreateRate(mfpLineItem.TradeMoney.Currency,
                mfpLineItem.SettlementMoney.Currency,
                CalculateWeightedAverageSpotRate(mfpLineItem.TradeMoney.Amount, relatedFuturePaymentLineItems),
                false,
                firstOriginalFPLineItem.FundingSource.ClientRateComponent.CostRateComponent.SpotRate.MetaData,
                firstOriginalFPLineItem.FundingSource.ClientRateComponent.CostRateComponent.SpotRate.RateConvention);
        }

        private decimal CalculateWeightedAverageSpotRate(decimal mfpTradeAmount, IEnumerable<LineItem> relatedFuturePaymentLineItems)
        {
            return
                relatedFuturePaymentLineItems.Sum(
                    fpLineItem =>
                        (fpLineItem.TradeMoney.Amount / mfpTradeAmount) * fpLineItem.FundingSource.ClientRateComponent.CostRateComponent.SpotRate.RoundedValue);
        }

        private decimal CalculateWeightedAverageForwardPoints(decimal mfpTradeAmount, IEnumerable<LineItem> relatedFuturePaymentLineItems)
        {
            return
                relatedFuturePaymentLineItems.Sum(
                    fpLineItem =>
                        (fpLineItem.TradeMoney.Amount / mfpTradeAmount) * fpLineItem.FundingSource.ClientRateComponent.CostRateComponent.ForwardPoints);
        }

        private ClientRateComponent CreateClientRateComponent(Rate clientRate, Rate spotRate, decimal forwardPoints)
        {
            return new ClientRateComponent
            {
                ClientRate = clientRate,
                CostRateComponent = new CostRateComponent
                {
                    SpotRate = spotRate,
                    ForwardPoints = forwardPoints
                }
            };
        }
    }
}