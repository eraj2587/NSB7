using System;
using System.Collections.Generic;
using System.Linq;
using WUBS.Cct.Treasury.DomainModel.Enums;

namespace WUBS.Cct.Treasury.DomainModel.Entities
{
    [Serializable]
    public class LockIn : Order
    {
        public LockIn() : base(TradeDirection.Sell, OrderType.LockIn) { }

        public IEnumerable<LineItem> LockInAdjustments
        {
            get { return LineItems.Where(lineItem => lineItem.LineItemType == ItemType.LockInSaleAdjustment && !lineItem.TradeAndSettlementAmountsAreZero()); }
        }

        public LineItem GetLockInSaleItem(LineItem lockInAdjustment)
        {
            var lockInLineItem = LineItems.FirstOrDefault(
                lineItem => lineItem.TradeMoney.Currency == lockInAdjustment.TradeMoney.Currency &&
                    lineItem.LineItemType != ItemType.LockInSaleAdjustment);

            if (lockInLineItem == null)
                throw new ArgumentException(string.Format(
                    "Unable to retrieve lock-in sale item for lock-in adjustment LineItemId: {0}", lockInAdjustment.Id));

            return lockInLineItem;
        }
    }
}