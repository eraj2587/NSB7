using System;
using System.Collections.Generic;
using System.Linq;
using WUBS.Cct.Treasury.DomainModel.Enums;

namespace WUBS.Cct.Treasury.DomainModel.Entities
{
    [Serializable]
    public class LockInRepurchase : Order
    {
        public LockInRepurchase() : base(TradeDirection.Buy, OrderType.LockInRepurchase) { }
        
    }
}