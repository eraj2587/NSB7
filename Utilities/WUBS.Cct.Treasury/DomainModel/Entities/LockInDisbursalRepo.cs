using System;
using System.Linq;
using WUBS.Cct.Treasury.DomainModel.Enums;
using WUBS.Cct.Treasury.Exceptions;

namespace WUBS.Cct.Treasury.DomainModel.Entities
{
    [Serializable]
    public class LockInDisbursalRepo : LinkedOrder
    {
        public LockInDisbursalRepo() : base(TradeDirection.Buy, OrderType.LockInDisbursalOrderRepurchase)
        {
        }

        public LinkedOrder LockinDisbursalOrder
        { get { return RelatedOrder as LinkedOrder; } }

        public override LineItem GetRelatedLineItem(LineItem lineItem)
        {
            if (LockinDisbursalOrder == null)
                throw new UnableToRetrieveRelatedLineItemException(lineItem, "The LockinDisbursal order not found for this LockInDisbursalRepo.");

            if (LockinDisbursalOrder.RelatedOrder == null)
                throw new UnableToRetrieveRelatedLineItemException(lineItem, "The LockIn order not found for this LockinDisbursal.");

            return LockinDisbursalOrder.RelatedOrder.LineItems.First(li => li.TradeMoney.Currency == lineItem.TradeMoney.Currency);

        }
    }
}
