using System;
using WUBS.Cct.DataExamples.DataBuilders;
using WUBS.Cct.DataExamples.Enums;
using WUBS.Cct.DataExamples.TestDataContainer;

namespace WUBS.Cct.DataExamples.Spots.New
{
    public class PaymentsNewWithTwoLineItems_History : AbstractOrderData
    {
        /// <summary>
        /// COTR0232311     
        /// </summary>
        public PaymentsNewWithTwoLineItems_History()
        {
            AddDatabase(new RueschlinkDB());

            AddDatabase(new RLHistoryDB())
                .AddRow(new OrderHeaderBuilder<RLHistoryDB.TRRawHeader.TRRawHeaderRow>()
                    .OfType(OrderType.PaymentsNew)
                    .WithOrderId(33605201)
                    .WithItemCount(2)
                    .Ordered(DateTime.Parse("2017-06-27 14:07:55.307"))
                    .SettlementCurrency(CurrencyDefn.CAD)
                    .WithSettlementMethodId(SettlementMethod.Wire)
                    .ForClient(1425397)
                    .InApp(Application.GlobalPay)
                    .Build())
                .AddRow(new LineItemBuilder<RLHistoryDB.trrawdetail.trrawdetailRow>()
                    .OfType(ItemType.EftPayment)
                    .WithId(56118595)
                    .ForOrderId(33605201)
                    .WithItemNumber(1)
                    .WithTradeCurrency(CurrencyDefn.MXN)
                    .WithTradeAmount(1000)
                    .WithSettlementAmount(76)
                    .FundedBy(80)
                    .WithRate(new ItemRate(0.076m, 0, 4, 1, null))
                    .IsQuotedWithId(72641929)
                    .WithRelatedId(0)
                    .WithWindowLength(0)
                    .WithReleaseDate(DateTime.Parse("2017-06-27 00:00:00.000"))
                    .Build())
                .AddRow(new LineItemBuilder<RLHistoryDB.trrawdetail.trrawdetailRow>()
                    .OfType(ItemType.EftPayment)
                    .WithId(56118596)
                    .ForOrderId(33605201)
                    .WithItemNumber(2)
                    .WithTradeCurrency(CurrencyDefn.ZAR)
                    .WithTradeAmount(42351.36m)
                    .WithSettlementAmount(4455.36m)
                    .FundedBy(80)
                    .WithRate(new ItemRate(0.1052m, 0, 4, 1, null))
                    .IsQuotedWithId(72641930)
                    .WithRelatedId(0)
                    .WithWindowLength(0)
                    .WithReleaseDate(DateTime.Parse("2017-06-27 00:00:00.000"))
                    .Build())
                .AddRow(new OrderDetailValueDateBuilder<RLHistoryDB.TRRawDetailValueDate.TRRawDetailValueDateRow>()
                    .WithOrderDetailId(56118595)
                    .WithRequestedValueDate(DateTime.Parse("2017-06-28 00:00:00.000"))
                    .Build())
                .AddRow(new OrderDetailValueDateBuilder<RLHistoryDB.TRRawDetailValueDate.TRRawDetailValueDateRow>()
                    .WithOrderDetailId(56118596)
                    .WithRequestedValueDate(DateTime.Parse("2017-06-28 00:00:00.000"))
                    .Build());

            AddDatabase(new CrsDB())
                .AddRow(new QuoteBuilder<CrsDB.Quote.QuoteRow>()
                    .WithQuoteId(72641929)
                    .WithTradeCurrency(CurrencyDefn.MXN)
                    .WithSettlementCurrency(CurrencyDefn.CAD)
                    .WithCustomerRate(0.076m, 0)
                    .WithCostRate(13.6283m, 1)
                    .WithForwardPoints(-0.0024m, 1)
                    .WithRateMultiplier(1)
                    .Build())
                .AddRow(new QuoteBuilder<CrsDB.Quote.QuoteRow>()
                    .WithQuoteId(72641930)
                    .WithTradeCurrency(CurrencyDefn.ZAR)
                    .WithSettlementCurrency(CurrencyDefn.CAD)
                    .WithCustomerRate(0.1052m, 0)
                    .WithCostRate(9.8401m, 1)
                    .WithForwardPoints(-0.0019m, 1)
                    .WithRateMultiplier(1)
                    .Build())
                .AddRow(new CrossCurrencyBuilder()
                    .WithTargetCurrency(CurrencyDefn.MXN)
                    .WithBaseCurrency(CurrencyDefn.CAD)
                    .IsPerBase(1)
                    .NDecIn(4)
                    .NDecPer(4)
                    .Build())
                .AddRow(new CrossCurrencyBuilder()
                    .WithTargetCurrency(CurrencyDefn.ZAR)
                    .WithBaseCurrency(CurrencyDefn.CAD)
                    .IsPerBase(1)
                    .NDecIn(4)
                    .NDecPer(4)
                    .Build());

            AddDatabase(new VMSDB());
        }
    }
}