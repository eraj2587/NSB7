using System;
using System.Collections.Generic;
using System.Configuration;
using WUBS.Cct.Treasury.DomainModel.Entities;
using WUBS.Cct.Treasury.Infrastructure.Utilities;
using WUBS.Cct.Treasury.Mappers;
using WUBS.Cct.Treasury.Mappers.Interfaces;
using WUBS.Cct.Treasury.Mappers.Visitors;

namespace WUBS.Cct.Treasury.Services
{
    public interface ICctTreasuryOrderService
    {
        Order GetOrder(int orderId);
        Order GetOrder(int orderId, int[] lineItems);
        Order GetOrderByLineItemId(int lineItemId, bool allLineItems);
    }

    public class CctTreasuryOrderService : ICctTreasuryOrderService
    {
        private readonly IList<OrderVisitor> visitors = new List<OrderVisitor>();
        private IOrderMapper orderMapper;
        private ILineItemMapper lineItemMapper;
        private readonly int loadDepth;

        private static readonly int maximumByLineItemLoadDepth = 4;

        public CctTreasuryOrderService(ILineItemMapper lineItemMapper)
        {
            this.lineItemMapper = lineItemMapper;
            loadDepth = 0;
            Init();
        }

        private CctTreasuryOrderService(ILineItemMapper lineItemMapper, int loadDepth)
        {
            this.lineItemMapper = lineItemMapper;
            this.loadDepth = loadDepth;
            Init();
        }

        private void Init()
        {
            var connectionString = ConfigurationManager.AppSettings["ConnectionString.RueschLINK"];

            var quoteMapper = new QuoteMapper();
            var futurePaymentEventLogMapper = new FuturePaymentEventLogMapper();
            var agingItemMapper = new LineItemToMatureLineItemMapper(connectionString);
            this.orderMapper = new OrderMapper();

            RegisterVisitors(futurePaymentEventLogMapper, agingItemMapper, quoteMapper);
        }

        private void RegisterVisitors(IFuturePaymentEventLogMapper futurePaymentEventLogMapper, ILineItemToMatureLineItemMapper agingItemMapper, IQuoteMapper quoteMapper)
        {
            if (loadDepth < maximumByLineItemLoadDepth)
            {
                var linkedOrderVisitor = new LinkedOrderVisitor(new CctTreasuryOrderService(lineItemMapper, loadDepth + 1));
                visitors.Add(linkedOrderVisitor);
            }

            visitors.Add(new ValueDateVisitor(futurePaymentEventLogMapper, agingItemMapper));
            visitors.Add(new ReissueVisitor(this, this.orderMapper));
            visitors.Add(new LockInDisbursalRepoVisitor());
            visitors.Add(new OrderModifiedVisitor(this));
            visitors.Add(new OrderSplitVisitor(this.orderMapper));
            visitors.Add(new BankListVisitor());
            visitors.Add(new MatureForwardVisitor());
            visitors.Add(new SellPaymentDuplicateLineItemVisitor());
            visitors.Add(new MatureFuturePaymentFundingSourceVisitor(this, agingItemMapper, lineItemMapper, quoteMapper));
            visitors.Add(new ForwardContractFundingSourceVisitor(this, quoteMapper));
            visitors.Add(new NonQuotedMatureFuturePaymentRepoOrderVisitor(this));
        }

        public Order GetOrder(int orderId)
        {
            var order = orderMapper.GetOrder(orderId);

            order.AddLineItems(lineItemMapper.GetLineItemsByOrder(order));

            ApplyVisitors(order);

            return order;
        }

        public Order GetBasicOrder(int orderId)
        {
            throw new NotImplementedException();
            //            var order = orderMapper.GetOrder(orderId);
            //
            //            //Apply limited set of visitors, reduce performance hit
            //
            //            return order;
        }

        public Order GetOrder(int orderId, int[] lineItems)
        {
            throw new NotImplementedException();
        }

        public Order GetOrderByLineItemId(int lineItemId, bool allLineItems)
        {
            var order = orderMapper.GetOrderByLineItemId(lineItemId);

            if (allLineItems)
                order.AddLineItems(lineItemMapper.GetLineItemsByOrder(order));
            else
                order.AddLineItem(lineItemMapper.GetLineItemByItemId(lineItemId));

            ApplyVisitors(order);

            return order;
        }

        public Order GetBasicOrderByLineItemId(int lineItemId, bool allLineItems)
        {
            throw new NotImplementedException();
            //            var order = orderMapper.GetOrderByLineItemId(lineItemId);
            //
            //            //apply limited set of visitors, reduce performance hit
            //
            //            return order;
        }

        private void ApplyVisitors(Order order)
        {
            visitors.ForEach(v => v.Visit(order));
        }
    }
}