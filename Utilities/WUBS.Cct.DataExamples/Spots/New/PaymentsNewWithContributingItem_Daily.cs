using System;
using WUBS.Cct.DataExamples.DataBuilders;
using WUBS.Cct.DataExamples.Enums;
using WUBS.Cct.DataExamples.TestDataContainer;

namespace WUBS.Cct.DataExamples.Spots.New
{
    public class PaymentsNewWithContributingItem_Daily : AbstractOrderData
    {
        public PaymentsNewWithContributingItem_Daily()
        {
            var valueDate = DateTime.Now.AddDays(2).Date;

            AddDatabase(new RueschlinkDB())
                .AddRow(new OrderHeaderBuilder<RueschlinkDB.ClientOrder.ClientOrderRow>().OfType(OrderType.PaymentsNew).WithItemCount(1).WithSettlementMethodId(SettlementMethod.EDebit).Build())
                .AddRow(new LineItemBuilder<RueschlinkDB.OrderDetail.OrderDetailRow>().OfType(ItemType.EftPayment).WithReleaseDate(valueDate).HasContributingItem().Build())
                .AddRow(new ContributingItemBuilder<RueschlinkDB.ContributingItem.ContributingItemRow>()
                    .IsQuotedWithId(1)
                    .WithRate(new ItemRate(1.4881m, 1, 4, 1, 1))
                    .FundedBy((int)PaymentFundedBy.Drawdown)
                    .IsPredelivery(true)
                    .Build())
                .AddRow(new OrderDetailValueDateBuilder<RueschlinkDB.OrderDetailValueDate.OrderDetailValueDateRow>()
                    .WithRequestedValueDate(valueDate)
                    .Build());

            AddDatabase(new RLHistoryDB());

            AddDatabase(new CrsDB())
                .AddRow(new QuoteBuilder<CrsDB.Quote.QuoteRow>()
                    .WithCustomerRate(1.4881m, 1)
                    .WithCostRate(1.4653m, 1)
                    .WithForwardPoints(0, 1)
                    .Build())
                .AddRow(new CrossCurrencyBuilder().Build());

            AddDatabase(new VMSDB());
        }
    }
}