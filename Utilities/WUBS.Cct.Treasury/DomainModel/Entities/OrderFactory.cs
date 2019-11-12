using System;
using System.Collections.Generic;
using WUBS.Cct.Treasury.DomainModel.Enums;

namespace WUBS.Cct.Treasury.DomainModel.Entities
{
    public static class OrderFactory
    {
        private static readonly HashSet<OrderType> sellOrderTypes = new HashSet<OrderType>
        {
            OrderType.NostroPaymentOrder, 
            OrderType.SellPaymentOrder,
            OrderType.IntoHolding,
            OrderType.FuturePaymentsOrder,
            OrderType.SellForwardContract
        };

        private static readonly HashSet<OrderType> buyOrderTypes = new HashSet<OrderType>
        {
            OrderType.BuyPaymentOrder, 
            OrderType.BuyForwardContract,
            OrderType.CreditNotesOrder,
            OrderType.MatureFuturePaymentsOrderRepurchase
        };

        private static readonly HashSet<OrderType> sellLinkedOrderTypes = new HashSet<OrderType>
        {
            OrderType.IncomingFundsRepurchase,
            OrderType.CreditNotesOrderRepurchase,
            OrderType.MatureForward,
            OrderType.BuyForwardContractRepurchase,
            OrderType.LockInDisbursalOrder
        };

        private static readonly HashSet<OrderType> buyLinkedOrderTypes = new HashSet<OrderType>
        {
            OrderType.IntoHoldingRepurchase,
            OrderType.FuturePaymentsOrderRepurchase,
            OrderType.NostroPaymentOrderRepurchase,
            OrderType.SellPaymentOrderRepurchase,
            OrderType.SellForwardContractRepurchase,
            OrderType.LockInRepurchase
        };

        internal static HashSet<OrderType> repurchaseOrders = new HashSet<OrderType>
        {
            OrderType.BuyForwardContractRepurchase,
            OrderType.CreditNotesOrderRepurchase,
            OrderType.FuturePaymentsOrderRepurchase,
            OrderType.IncomingFundsRepurchase,
            OrderType.IntoHoldingRepurchase,
            OrderType.LockInDisbursalOrderRepurchase,
            OrderType.NostroPaymentOrderRepurchase,
            OrderType.SellForwardContractRepurchase,
            OrderType.SellPaymentOrderRepurchase,
            OrderType.MatureFuturePaymentsOrderRepurchase,
            OrderType.SingleSidedTransactionPayoutRepurchase,
            OrderType.LockInRepurchase
        };
        
        public static Order CreateOrderByOrderType(OrderType orderType)
        {
            return CreateOrderByOrderType(orderType, false);
        }

        public static Order CreateOrderByOrderType(OrderType orderType, bool isReissueOrRepurchase)
        {
            if (orderType == OrderType.LockInDisbursalOrderRepurchase)
                return new LockInDisbursalRepo();

            if (orderType == OrderType.LockIn)
                return new LockIn();

            if (sellOrderTypes.Contains(orderType))
                return CreateInstance<Order>(TradeDirection.Sell, orderType, isReissueOrRepurchase);

            if (buyOrderTypes.Contains(orderType))
                return CreateInstance<Order>(TradeDirection.Buy, orderType, isReissueOrRepurchase);

            if (sellLinkedOrderTypes.Contains(orderType))
                return CreateInstance<LinkedOrder>(TradeDirection.Sell, orderType, isReissueOrRepurchase);

            if (buyLinkedOrderTypes.Contains(orderType))
                return CreateInstance<LinkedOrder>(TradeDirection.Buy, orderType, isReissueOrRepurchase);

            return CreateInstance<Order>(TradeDirection.Sell, orderType, isReissueOrRepurchase);
        }

        private static Order CreateInstance<T>(TradeDirection tradeDirection, OrderType orderType,
            bool isReissueOrRepurchase) where T : Order
        {

            if (isReissueOrRepurchase && !repurchaseOrders.Contains(orderType))
            {
                return new Reissue(tradeDirection, orderType);
            }
            return (T) Activator.CreateInstance(typeof (T), tradeDirection, orderType);
        }
    }
}