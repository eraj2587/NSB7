using System;
using System.Collections.Generic;
using System.Linq;
using WUBS.Cct.Treasury.DomainModel.Entities;
using WUBS.Cct.Treasury.DomainModel.Enums;
using WUBS.Cct.Treasury.DomainModel.Vms;
using WUBS.Cct.Treasury.Exceptions;
using WUBS.Cct.Treasury.Mappers.Interfaces;
using WUBS.Cct.Treasury.ServiceProviders;

namespace WUBS.Cct.Treasury.Mappers.Visitors
{
    public class ValueDateVisitor : OrderVisitor
    {
        private static readonly HashSet<OrderType> OpenValueDates = new HashSet<OrderType>
        {
            OrderType.SellForwardContract,
            OrderType.SellForwardContractRepurchase,
            OrderType.BuyForwardContract,
            OrderType.BuyForwardContractRepurchase,
            OrderType.LockIn,
            OrderType.LockInDisbursalOrder,
            OrderType.LockInDisbursalOrderRepurchase,
            OrderType.FuturePaymentsOrder,
            OrderType.FuturePaymentsOrderRepurchase,
            OrderType.CreditNotesOrder,
            OrderType.CreditNotesOrderRepurchase
        };

        private static readonly HashSet<OrderType> RepurchaseOrderTypes = new HashSet<OrderType>
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

        private readonly IFuturePaymentEventLogMapper futurePaymentEventLogMapper;
        private readonly ILineItemToMatureLineItemMapper agingItemMapper;


        public ValueDateVisitor(IFuturePaymentEventLogMapper futurePaymentEventLogMapper, ILineItemToMatureLineItemMapper agingItemMapper)
        {
            this.futurePaymentEventLogMapper = futurePaymentEventLogMapper;
            this.agingItemMapper = agingItemMapper;
        }
        
        public override void Visit(Order order)
        {
            foreach (var lineItem in order.LineItems.Where(li => li.LineItemType != ItemType.LockInSaleAdjustment && !IsDisbursalIntoHoldingItem(order, li)))
            {
                if (OpenValueDates.Contains(order.OrderType))
                {
                    SetOpenValueDate(order, lineItem);
                }
                else
                {
                    lineItem.ValueDate = GetValueDate(order, lineItem);
                }

                //ensure value date doesn't contain seconds or milliseconds since this may affect aggregation
                if (lineItem.ValueDate.HasValue)
                    lineItem.ValueDate = lineItem.ValueDate.Value.Date;
            }
        }

        private bool IsDisbursalIntoHoldingItem(Order order, LineItem lineItem)
        {
            return order.OrderType == OrderType.LockInDisbursalOrder && lineItem.LineItemType == ItemType.IntoHolding;
        }

        private void SetOpenValueDate(Order order, LineItem lineItem)
        {
            if (IsRepurchaseOrderType(order))
            {
                SetWindowStartAndLengthFromRelatedLineItem(order as LinkedOrder, lineItem);
            }
            else if (IsFuturePaymentOrCreditNote(order))
            {
                SetFuturePaymentOrCreditNoteWindow(order, lineItem);
            }
            else if (order.OrderType == OrderType.LockIn)
            {
                SetLockInWindow(order, lineItem);
            }
            else
            {
                lineItem.WindowStartDate = GetWindowStartDate(lineItem.WindowStartDate, lineItem.Id);
            }
        }

        private bool IsRepurchaseOrderType(Order order)
        {
            return RepurchaseOrderTypes.Contains(order.OrderType);
        }

        private bool IsFuturePaymentOrCreditNote(Order order)
        {
            return order.OrderType == OrderType.FuturePaymentsOrder || order.OrderType == OrderType.CreditNotesOrder;
        }

        private void SetWindowStartAndLengthFromRelatedLineItem(LinkedOrder repurchase, LineItem lineItem)
        {
            if (repurchase.RelatedOrder == null) return;

            var relatedLineItem = GetRelatedLineItem(repurchase, lineItem);
            lineItem.WindowStartDate = GetWindowStartDate(relatedLineItem.WindowStartDate, relatedLineItem.Id);
            lineItem.WindowLength = relatedLineItem.WindowLength;
        }

        private void SetFuturePaymentOrCreditNoteWindow(Order order, LineItem lineItem)
        {
            lineItem.WindowLength = GetWindowLengthForFuturePaymentOrCreditNoteLineItem(order, lineItem);
            lineItem.WindowStartDate = order.OrderedAt;
        }

        private void SetLockInWindow(Order order, LineItem lineItem)
        {
            if (!lineItem.WindowEndDate.HasValue)
                throw new ArgumentNullException("lineItem",
                    string.Format("LockIn lineItemId {0} does not have a window end date.", lineItem.Id));

            lineItem.WindowLength = (lineItem.WindowEndDate.Value.Date - order.OrderedAt.Date).Days;
            lineItem.WindowStartDate = order.OrderedAt;
        }

        private int GetWindowLengthForFuturePaymentOrCreditNoteLineItem(Order order, LineItem lineItem)
        {
            if (!lineItem.WindowStartDate.HasValue)
                throw new ArgumentNullException("lineItem",
                    string.Format("Future payments lineItemId {0} does not have a window start date.", lineItem.Id));

            var latestWindowStartDate = GetLatestWindowStartDate(lineItem);

            return latestWindowStartDate.Value.Date < order.OrderedAt.Date
                ? (DateTime.Now.Date - order.OrderedAt.Date).Days
                : (latestWindowStartDate.Value.Date - order.OrderedAt.Date).Days;
        }

        private DateTime? GetLatestWindowStartDate(LineItem lineItem)
        {
            var fpEventLog = futurePaymentEventLogMapper.GetByLineItemId(lineItem.Id);
            if (fpEventLog != null && fpEventLog.Status == RecordStatus.Success)
                return fpEventLog.NewReleaseDate;

            if (fpEventLog == null)
            {
                var agingReleaseDate = agingItemMapper.GetAgingReleaseDateByItemId(lineItem.Id);
                if (agingReleaseDate.HasValue)
                    return agingReleaseDate.Value;
            }

            return lineItem.WindowStartDate;
        }

        private static DateTime GetWindowStartDate(DateTime? valueDate, int lineItemId)
        {
            try
            {
                return valueDate ?? ValueDateServiceProvider.Instance.GetPaymentValueDate(lineItemId);
            }
            catch
            {
                throw new UnableToRetrieveWindowStartDateException(lineItemId);
            }
        }

        private DateTime GetValueDateFromRelatedLineItem(LinkedOrder repurchase, LineItem lineItem)
        {
            var relatedLineItem = GetRelatedLineItem(repurchase, lineItem);
            return GetValueDate(relatedLineItem.ValueDate, relatedLineItem.Id);
        }

        private LineItem GetRelatedLineItem(LinkedOrder repurchase, LineItem lineItem)
        {
            if (repurchase == null)
                throw new ArgumentException("Repurchase is not a valid linked order.");

            return repurchase.GetRelatedLineItem(lineItem);
        }

        private DateTime GetValueDate(Order order, LineItem lineItem)
        {
            if (order.OrderType == OrderType.SellPaymentOrder)
                return GetSellPaymentLineItemValueDate(order, lineItem);

            return GetValueDate(lineItem.ValueDate, lineItem.Id);
        }

        private DateTime GetSellPaymentLineItemValueDate(Order sellPaymentOrder, LineItem lineItem)
        {
            if (lineItem.WindowStartDate.HasValue)
                return GetWindowStartDate(lineItem.WindowStartDate, lineItem.Id);

            if (lineItem.ValueDate.HasValue)
                return GetValueDate(lineItem.ValueDate, lineItem.Id);

            if (lineItem.LineItemType == ItemType.IntoHolding)
                return sellPaymentOrder.OrderedAt;

            var relatedOrder = sellPaymentOrder as LinkedOrder;
            if (relatedOrder != null)
                return GetValueDateFromRelatedLineItem(relatedOrder, lineItem);

            return GetValueDate(lineItem.ValueDate, lineItem.Id);            
        }

        private static DateTime GetValueDate(DateTime? valueDate, int lineItemId)
        {
            try
            {
                return valueDate ?? ValueDateServiceProvider.Instance.GetPaymentValueDate(lineItemId);
            }
            catch
            {
                return DateTime.Today;
            }
        }
    }
}