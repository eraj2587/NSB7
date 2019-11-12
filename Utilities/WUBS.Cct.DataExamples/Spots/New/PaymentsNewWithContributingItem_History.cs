using System;
using WUBS.Cct.DataExamples.DataBuilders;
using WUBS.Cct.DataExamples.Enums;
using WUBS.Cct.DataExamples.TestDataContainer;

namespace WUBS.Cct.DataExamples.Spots.New
{
    public class PaymentsNewWithContributingItem_History : AbstractOrderData
    {
        public PaymentsNewWithContributingItem_History()
        {
            var valueDate = DateTime.Now.AddDays(2).Date;

            AddDatabase(new RueschlinkDB());

            AddDatabase(new RLHistoryDB())
                .AddRow(new OrderHeaderBuilder<RLHistoryDB.TRRawHeader.TRRawHeaderRow>().OfType(OrderType.PaymentsNew).WithItemCount(1).WithSettlementMethodId(SettlementMethod.EDebit).Build())
                .AddRow(new LineItemBuilder<RLHistoryDB.trrawdetail.trrawdetailRow>().OfType(ItemType.EftPayment).WithReleaseDate(valueDate).HasContributingItem().Build())
                .AddRow(new ContributingItemBuilder<RLHistoryDB.ContributingItemHistory.ContributingItemHistoryRow>()
                    .IsQuotedWithId(1)
                    .WithRate(new ItemRate(1.4881m, 1, 4, 1, 1))
                    .FundedBy((int)PaymentFundedBy.Drawdown)
                    .IsPredelivery(true)
                    .Build())
                .AddRow(new OrderDetailValueDateBuilder<RueschlinkDB.OrderDetailValueDate.OrderDetailValueDateRow>()
                    .WithRequestedValueDate(valueDate)
                    .Build());

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