using System;
using WUBS.Cct.DataExamples.DataBuilders;
using WUBS.Cct.DataExamples.Enums;
using WUBS.Cct.DataExamples.TestDataContainer;

namespace WUBS.Cct.DataExamples.Spots.New
{
    /// <summary>
    /// COTR0232370
    /// </summary>
    public class PaymentsNew_History : AbstractOrderData
    {
        public PaymentsNew_History()
        {
            AddDatabase(new RueschlinkDB());

            AddDatabase(new RLHistoryDB())
                .AddRow(new OrderHeaderBuilder<RLHistoryDB.TRRawHeader.TRRawHeaderRow>()
                    .OfType(OrderType.PaymentsNew)
                    .WithOrderId(33607532)
                    .WithItemCount(1)
                    .Ordered(DateTime.Parse("2017-06-27 16:52:33.600"))
                    .SettlementCurrency(CurrencyDefn.CAD)
                    .WithSettlementMethodId(SettlementMethod.Wire)
                    .ForClient(3288348)
                    .InApp(Application.GlobalPay)
                    .Build())
                .AddRow(new LineItemBuilder<RLHistoryDB.trrawdetail.trrawdetailRow>()
                    .OfType(ItemType.EftPayment)
                    .WithId(56123116)
                    .ForOrderId(33607532)
                    .WithItemNumber(1)
                    .WithTradeCurrency(CurrencyDefn.USD)
                    .WithTradeAmount(12000)
                    .WithSettlementAmount(15931.21m)
                    .FundedBy(80)
                    .WithRate(new ItemRate(1.3276m, 0, 4, 1, null))
                    .IsQuotedWithId(72647074)
                    .WithRelatedId(0)
                    .WithWindowLength(0)
                    .WithReleaseDate(DateTime.Parse("2017-06-28 00:00:00.000"))
                    .Build())
                .AddRow(new OrderDetailValueDateBuilder<RLHistoryDB.TRRawDetailValueDate.TRRawDetailValueDateRow>()
                    .WithOrderDetailId(56123116)
                    .WithRequestedValueDate(DateTime.Parse("2017-06-28 00:00:00.000"))
                    .Build());

            AddDatabase(new CrsDB())
                .AddRow(new QuoteBuilder<CrsDB.Quote.QuoteRow>()
                    .WithQuoteId(72636580)
                    .WithTradeCurrency(CurrencyDefn.CAD)
                    .WithSettlementCurrency(CurrencyDefn.USD)
                    .WithCustomerRate(1.3276m, 0)
                    .WithCostRate(1.3208m, 0)
                    .WithForwardPoints(0.0001m, 0)
                    .WithRateMultiplier(1)
                    .Build())
                .AddRow(new CrossCurrencyBuilder()
                    .WithTargetCurrency(CurrencyDefn.CAD)
                    .WithBaseCurrency(CurrencyDefn.USD)
                    .IsPerBase(0)
                    .NDecIn(4)
                    .NDecPer(4)
                    .Build());

            AddDatabase(new VMSDB());
        }
    }
}