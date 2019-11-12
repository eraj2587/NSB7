using System;
using System.Collections.Generic;
using WUBS.Cct.Treasury.DomainModel.Enums;
using WUBS.Cct.Treasury.DomainModel.Financial;

namespace WUBS.Cct.Treasury.DomainModel.Entities
{
    [Serializable]
    public class Order
    {
        public readonly TradeDirection TradeDirection;
        public readonly OrderType OrderType;

        public Order(TradeDirection tradeDirection, OrderType orderType)
        {
            TradeDirection = tradeDirection;
            OrderType = orderType;
        }

        protected readonly List<LineItem> lineItems = new List<LineItem>();

        public List<LineItem> LineItems
        {
            get { return lineItems; }
        }

        public virtual void AddLineItem(LineItem lineItem)
        {
            lineItems.Add(lineItem);
        }

        public virtual void AddLineItems(IEnumerable<LineItem> additionalLineItems)
        {
            lineItems.AddRange(additionalLineItems);
        }

        public int NumberOfItems { get { return LineItems.Count; } }

        public string ConfirmationNumber { get; set; }
        public DateTime OrderedAt { get; set; }
        public int Id { get; set; }
        public int ClientId { get; set; }
        public Currency SettlementCurrency { get; set; }

        public int? RelatedOrderId { get; set; }
        public int RueschStaffId { get; set; }
        public int ApplicationId { get; set; }

        public bool ReinstateFundsToForward { get; set; }

        public virtual bool IsReissue
        {
            get { return false; }
        }

        public override string ToString()
        {
            return Id.ToString();
        }

        public string SplitOriginalConfirmationNo { get; set; }

        public string OrderTypeDescription { get; set; }
    }
}
