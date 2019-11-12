using System;
using System.Collections.Generic;
using System.Linq;
using WUBS.Cct.Treasury.DomainModel.Enums;
using WUBS.Cct.Treasury.Exceptions;

namespace WUBS.Cct.Treasury.DomainModel.Entities
{
    [Serializable]
    public class LinkedOrder : Order
    {
        public LinkedOrder(TradeDirection tradeDirection, OrderType orderType)
            : base(tradeDirection, orderType)
        {
        }

        public Order RelatedOrder { get; set; }

        public virtual LineItem GetRelatedLineItem(LineItem lineItem)
        {
            var relatedLineItem = RelatedOrder.LineItems.FirstOrDefault(li => li.Id == lineItem.RelatedLineItemId);
            
            if(relatedLineItem == null)        
                throw new UnableToRetrieveRelatedLineItemException(lineItem);

            return relatedLineItem;
        }

        public virtual IEnumerable<LineItem> GetRelatedLineItems(long contractId)
        {
            return RelatedOrder.LineItems
                .Where(l => l.ContractId == contractId);
        }
    }
}
