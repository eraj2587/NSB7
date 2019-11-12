using System;
using System.Collections.Generic;
using System.Linq;
using WUBS.Cct.Treasury.DomainModel.Entities;
using WUBS.Cct.Treasury.DomainModel.Enums;
using WUBS.Cct.Treasury.Exceptions;
using WUBS.Cct.Treasury.Mappers.Interfaces;
using WUBS.Cct.Treasury.Services;

namespace WUBS.Cct.Treasury.Mappers.Visitors
{
    internal class LinkedOrderVisitor : OrderVisitor
    {
        private readonly ICctTreasuryOrderService orderMapper;

        private readonly HashSet<OrderType> repurchaseOrderTypes = new HashSet<OrderType>
        {
            OrderType.IncomingFundsRepurchase,
            OrderType.NostroPaymentOrderRepurchase,
            OrderType.IntoHoldingRepurchase,
            OrderType.FuturePaymentsOrderRepurchase,
            OrderType.CreditNotesOrderRepurchase,
            OrderType.SellPaymentOrderRepurchase,
            OrderType.LockInDisbursalOrderRepurchase,
            OrderType.SellForwardContractRepurchase,
            OrderType.BuyForwardContractRepurchase
        };

        public LinkedOrderVisitor(ICctTreasuryOrderService orderMapper)
        {
            this.orderMapper = orderMapper;
        }

        public override void Visit(Order order)
        {
            var linkedOrder = order as LinkedOrder;

            if (linkedOrder == null || linkedOrder.RelatedOrder != null)
                return;

            linkedOrder.RelatedOrder = GetRelatedOrderFromRelatedLineItems(order) ?? GetRelatedOrderFromRelatedOrderId(order);

            if (linkedOrder.RelatedOrder == null)
                throw new UnableToRetrieveRelatedOrderException(linkedOrder);

            if (!linkedOrder.RelatedOrder.LineItems.Any())
            {
#if DEBUG
                Console.WriteLine(" Read related OrderId {0}", (linkedOrder.RelatedOrder.Id));
#endif
                linkedOrder.RelatedOrder = orderMapper.GetOrder(linkedOrder.RelatedOrder.Id);
            }
        }

        private Order GetRelatedOrderFromRelatedOrderId(Order linkedOrder)
        {
            return linkedOrder.RelatedOrderId.GetValueOrDefault(0) > 0 ? orderMapper.GetOrder(linkedOrder.RelatedOrderId.GetValueOrDefault(0)) : null;
        }

        private bool NeedToPopulateAllLineItems(Order linkedOrder)
        {
            return linkedOrder is LockInDisbursalRepo || IsRepurchaseOrderWithMultipleLineItems(linkedOrder) || linkedOrder.IsReissue;
        }

        private bool IsRepurchaseOrderWithMultipleLineItems(Order linkedOrder)
        {
            return repurchaseOrderTypes.Contains(linkedOrder.OrderType) && linkedOrder.LineItems.Count() > 1;
        }

        private Order GetRelatedOrderFromRelatedLineItems(Order linkedOrder)
        {
            if (linkedOrder.OrderType == OrderType.LockInDisbursalOrder)
                return null;

            var relatedLineItemIds = GetRelatedLineItemIds(linkedOrder);

            if (NeedToPopulateAllLineItems(linkedOrder))
            {
                var relatedOrder = relatedLineItemIds.Any() ? orderMapper.GetOrderByLineItemId(relatedLineItemIds[0], true) : null;
                if (relatedOrder == null)
                    throw new UnableToRetrieveRelatedOrderException(linkedOrder);
#if DEBUG
                Console.WriteLine(" Read related OrderId from GetRelatedOrderFromRelatedLineItems {0}", (relatedOrder.Id));
#endif
                return orderMapper.GetOrder(relatedOrder.Id);
            }

            return relatedLineItemIds.Any() ? orderMapper.GetOrderByLineItemId(relatedLineItemIds[0], true) : null;
        }

        private int[] GetRelatedLineItemIds(Order order)
        {
            return order.LineItems
                .Where(lineItem => lineItem.RelatedLineItemId.HasValue && lineItem.RelatedLineItemId.Value > 0)
                .Select(lineItem => lineItem.RelatedLineItemId.Value)
                .ToArray();
        }
    }
}
