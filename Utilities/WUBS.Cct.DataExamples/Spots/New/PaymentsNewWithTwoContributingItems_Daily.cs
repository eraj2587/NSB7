using System;
using WUBS.Cct.DataExamples.DataBuilders;
using WUBS.Cct.DataExamples.Enums;
using WUBS.Cct.DataExamples.TestDataContainer;

namespace WUBS.Cct.DataExamples.Spots.New
{
    public class PaymentsNewWithTwoContributingItems_Daily : AbstractOrderData
    {
        public PaymentsNewWithTwoContributingItems_Daily()
        {
            var lineItemValueDate = DateTime.Now.AddDays(2).Date;

            AddDatabase(new RueschlinkDB())
                .AddRow(new OrderHeaderBuilder<RueschlinkDB.ClientOrder.ClientOrderRow>().OfType(OrderType.PaymentsNew).WithItemCount(1).Build())
                .AddRow(new LineItemBuilder<RueschlinkDB.OrderDetail.OrderDetailRow>().OfType(ItemType.EftPayment).HasContributingItem().Build())
                .AddRow(new ContributingItemBuilder<RueschlinkDB.ContributingItem.ContributingItemRow>()
                    .IsItemNumber(1)
                    .IsQuotedWithId(1)
                    .WithTradeAmount(100m)
                    .WithSettlementAmount(66.67m)
                    .WithRate(new ItemRate(1.50m, 1, 4, 1, 1))
                    .IsPredelivery(true)
                    .Build())
                .AddRow(new ContributingItemBuilder<RueschlinkDB.ContributingItem.ContributingItemRow>()
                    .IsItemNumber(2)
                    .IsQuotedWithId(2)
                    .WithTradeAmount(200m)
                    .WithSettlementAmount(125m)
                    .WithRate(new ItemRate(1.60m, 1, 4, 1, 1))
                    .FundedBy((int) PaymentFundedBy.Drawdown)
                    .IsPredelivery(false)
                    .Build())
                .AddRow(new OrderDetailValueDateBuilder<RueschlinkDB.OrderDetailValueDate.OrderDetailValueDateRow>()
                    .WithRequestedValueDate(lineItemValueDate)
                    .Build());

            AddDatabase(new RLHistoryDB());

            AddDatabase(new CrsDB())
                .AddRow(new QuoteBuilder<CrsDB.Quote.QuoteRow>()
                    .WithQuoteId(1)
                    .WithCustomerRate(1.50m, 1)
                    .WithCostRate(1.48m, 1)
                    .WithForwardPoints(0, 1)
                    .Build())
                .AddRow(new QuoteBuilder<CrsDB.Quote.QuoteRow>()
                    .WithQuoteId(2)
                    .WithCustomerRate(1.60m, 1)
                    .WithCostRate(1.58m, 1)
                    .WithForwardPoints(0, 1)
                    .Build())
                .AddRow(new CrossCurrencyBuilder().Build()); 

            AddDatabase(new VMSDB());
        }
    }
}