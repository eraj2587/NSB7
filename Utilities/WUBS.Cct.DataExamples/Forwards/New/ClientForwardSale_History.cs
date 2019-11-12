using System;
using WUBS.Cct.DataExamples.DataBuilders;
using WUBS.Cct.DataExamples.Enums;
using WUBS.Cct.DataExamples.Spots.New;
using WUBS.Cct.DataExamples.TestDataContainer;

namespace WUBS.Cct.DataExamples.Forwards.New
{
    public class ClientForwardSale_History : AbstractOrderData
    {
        public ClientForwardSale_History()
        {
            var quote_ID = 1;
            var tradeAmt = 1000m;
            var tradeCur = CurrencyDefn.EUR;
            var settleAmt = 4791.57m;
            var settleCur = CurrencyDefn.MYR;

            AddDatabase(new RLHistoryDB())
                .AddRow(new OrderHeaderBuilder<RLHistoryDB.TRRawHeader.TRRawHeaderRow>()
                            .OfType(OrderType.ClientForwardSale)
                            .WithItemCount(1)
                            .SettlementCurrency(settleCur)
                            .Build())
                .AddRow(new LineItemBuilder<RLHistoryDB.trrawdetail.trrawdetailRow>()
                            .OfType(ItemType.ClientForwardSale)
                            .WithSettlementAmount(settleAmt)
                            .WithTradeAmount(tradeAmt)
                            .WithTradeCurrency(tradeCur)
                            .IsQuotedWithId(quote_ID)
                            .Build());

            AddDatabase(new RueschlinkDB());

            AddDatabase(new CrsDB())
                .AddRow(new QuoteBuilder<CrsDB.Quote.QuoteRow>()
                            .WithCustomerRate(0.2087m, 1)
                            .WithCostRate(0.2088m, 1)
                            .WithReutersRate(0.2088m, 1)
                            .WithSettlementRate(4.2685m)
                            .WithReportingRate(7.79435m)
                            .WithForwardPoints(-0.0001m, 1)
                            .WithSettlementCurrency(settleCur)
                            .WithTradeCurrency(tradeCur)
                            .WithReportingCurrency(CurrencyDefn.HKD)
                            .Build());

            AddDatabase(new VMaRSDB());
        }
    }
}