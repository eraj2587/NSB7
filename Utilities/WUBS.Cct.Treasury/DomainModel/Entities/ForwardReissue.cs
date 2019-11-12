using System;
using System.Linq;
using WUBS.Cct.Treasury.DomainModel.Enums;

namespace WUBS.Cct.Treasury.DomainModel.Entities
{
    [Serializable]
    public class Reissue: LinkedOrder
    {
        public Reissue(TradeDirection tradeDirection, OrderType orderType)
            : base(tradeDirection, orderType)
        {
        }

        public Order Repurchase { get; set; }

        public LineItem GetRepurchaseLineItem(int forwardLineItemId)
        {
            return Repurchase.LineItems.First(l => l.RelatedLineItemId == forwardLineItemId);
        }

        public override bool IsReissue
        {
            get { return true; }
        }
    }
}
