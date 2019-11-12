using System;
using WUBS.Cct.DataExamples.DataBuilders;
using WUBS.Cct.DataExamples.Enums;
using WUBS.Cct.DataExamples.TestDataContainer;

namespace WUBS.Cct.DataExamples.Spots.New
{
    public class NostroPayment_Daily : AbstractOrderData
    {
        public NostroPayment_Daily()
        {
            AddDatabase(new RueschlinkDB())
                .AddRow(new OrderHeaderBuilder<RueschlinkDB.ClientOrder.ClientOrderRow>()
                            .OfType(OrderType.NostroPayment)
                            .WithItemCount(1)
                            .SettlementCurrency(CurrencyDefn.GBP)
                            .Build())
                .AddRow(new LineItemBuilder<RueschlinkDB.OrderDetail.OrderDetailRow>()
                            .OfType(ItemType.EftPayment)
                            .WithSettlementAmount(58.13m)
                            .WithTradeAmount(100)
                            .WithTradeCurrency(CurrencyDefn.AUD)
                            .IsQuotedWithId(1)
                            .Build());

            AddDatabase(new RLHistoryDB());

            AddDatabase(new CrsDB())
                .AddRow(new QuoteBuilder<CrsDB.Quote.QuoteRow>()
                    .WithTradeCurrency(CurrencyDefn.AUD)
                    .WithSettlementCurrency(CurrencyDefn.GBP)
                    .WithCustomerRate(0.5813m, 0)
                    .WithCostRate(0.5789m, 0)
                    .WithReutersRate(0.5787m, 0)
                    .WithSettlementRate(1.29265m)
                    .WithReportingRate(1.29265m)
                    .WithReportingCurrency(CurrencyDefn.GBP)
                    .WithChildEffectiveMultiplier(1.004m)
                    .WithCostMarkup(0.3456)
                    .Build());

            AddDatabase(new VMSDB());

        }
    }
}