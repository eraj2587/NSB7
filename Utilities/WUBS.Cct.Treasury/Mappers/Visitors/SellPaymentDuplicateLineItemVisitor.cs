using System.Collections.Generic;
using System.Linq;
using WUBS.Cct.Treasury.DomainModel.Entities;
using WUBS.Cct.Treasury.DomainModel.Enums;

namespace WUBS.Cct.Treasury.Mappers.Visitors
{
    public class SellPaymentDuplicateLineItemVisitor : OrderVisitor
    {
        public SellPaymentDuplicateLineItemVisitor()
        {}

        public override void Visit(Order order)
        {
            if (order.OrderType != OrderType.SellPaymentOrder) return;

            if (HasDuplicateLineItems(order.LineItems))
            {
                RemoveDuplicateLineItems(order);
            }
        }

        private bool HasDuplicateLineItems(IEnumerable<LineItem> lineItems)
        {
            var lineItemCount = lineItems.Count();

            if (lineItemCount < 2)
                return false;

            return lineItems.GroupBy(li => li.Id).Count() != lineItemCount;
        }

        private void RemoveDuplicateLineItems(Order order)
        {
            order.LineItems.RemoveAll(li => li.TradeMoney.Amount == 0 && li.SettlementMoney.Amount == 0);
        }
    }
}