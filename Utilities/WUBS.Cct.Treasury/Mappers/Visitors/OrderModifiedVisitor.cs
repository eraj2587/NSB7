using System.Linq;
using WUBS.Cct.Treasury.DomainModel.Entities;
using WUBS.Cct.Treasury.DomainModel.Enums;
using WUBS.Cct.Treasury.DomainModel.FundingSource;
using WUBS.Cct.Treasury.Infrastructure.Utilities;
using WUBS.Cct.Treasury.Services;

namespace WUBS.Cct.Treasury.Mappers.Visitors
{
    internal class OrderModifiedVisitor : OrderVisitor
    {
        private readonly ICctTreasuryOrderService orderMapper;

        public OrderModifiedVisitor(ICctTreasuryOrderService orderMapper)
        {
            this.orderMapper = orderMapper;
        }

        public override void Visit(Order order)
        {
            if (!OrderIsNostroOrLockInDisbursal(order.OrderType) 
                || !order.RelatedOrderId.HasValue || order.RelatedOrderId == 0
                || !LineItemHasNullFundingSource(order))
            {
                return;
            }

            var relatedOrder = orderMapper.GetOrder(order.RelatedOrderId.Value);

            if (relatedOrder.OrderType != OrderType.LockIn)
                return;

            order.LineItems.Where(li => li.FundingSource is NullLineItemFundingSource)
                .ForEach(li => SetFundingSource(li, relatedOrder));
        }

        private bool OrderIsNostroOrLockInDisbursal(OrderType orderType)
        {
            return orderType == OrderType.NostroPaymentOrder || orderType == OrderType.LockInDisbursalOrder;
        }

        private bool LineItemHasNullFundingSource(Order order)
        {
            return order.LineItems.Any(li => li.FundingSource is NullLineItemFundingSource);
        }

        private void SetFundingSource(LineItem lineItem, Order order)
        {
            var fundingSourceLineItem = order.LineItems.FirstOrDefault(li => li.TradeMoney.Currency == lineItem.TradeMoney.Currency);

            lineItem.FundingSource = fundingSourceLineItem != null
                ? fundingSourceLineItem.FundingSource
                : new NullLineItemFundingSource();
        }
    }
}
