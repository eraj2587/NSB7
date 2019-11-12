using System;
using WUBS.Cct.DataExamples.DataBuilders;
using WUBS.Cct.DataExamples.Enums;
using WUBS.Cct.DataExamples.TestDataContainer;

namespace WUBS.Cct.DataExamples.Spots.New
{
    /// <summary>
    /// UOTR4252151     
    /// </summary>
    public class PaymentsNew_Daily : AbstractOrderData
    {
        public PaymentsNew_Daily()
        {
            AddDatabase(new RueschlinkDB())
                .AddRow(new OrderHeaderBuilder<RueschlinkDB.ClientOrder.ClientOrderRow>()
                    .OfType(OrderType.PaymentsNew)
                    .WithOrderId(33603787)
                    .WithItemCount(1)
                    .Ordered(DateTime.Parse("2017-06-27 12:31:30.180"))
                    .SettlementCurrency(CurrencyDefn.GBP)
                    .WithSettlementMethodId(SettlementMethod.EDebit)
                    .ForClient(2677778)
                    .InApp(Application.GlobalPay)
                    .Build())
                .AddRow(new LineItemBuilder<RueschlinkDB.OrderDetail.OrderDetailRow>()
                    .OfType(ItemType.EftPayment)
                    .WithId(56115306)
                    .ForOrderId(33603787)
                    .WithItemNumber(1)
                    .WithTradeCurrency(CurrencyDefn.AUD)
                    .WithTradeAmount(957)
                    .WithSettlementAmount(577.31m)
                    .FundedBy(80)
                    .WithRate(new ItemRate(1.6577m, 1, 4, 1, null))
                    .IsQuotedWithId(72636580)
                    .WithRelatedId(0)
                    .WithWindowLength(0)
                    .WithReleaseDate(DateTime.Parse("2017-06-27 00:00:00.000"))
                    .Build())
                .AddRow(new OrderDetailValueDateBuilder<RueschlinkDB.OrderDetailValueDate.OrderDetailValueDateRow>()
                    .WithOrderDetailId(56115306)
                    .WithRequestedValueDate(DateTime.Parse("2017-06-28 00:00:00.000"))
                    .Build());

            AddDatabase(new RLHistoryDB());

            AddDatabase(new CrsDB())
                .AddRow(new QuoteBuilder<CrsDB.Quote.QuoteRow>()
                    .WithQuoteId(72636580)
                    .WithTradeCurrency(CurrencyDefn.AUD)
                    .WithSettlementCurrency(CurrencyDefn.GBP)
                    .WithCustomerRate(1.6577m, 1)
                    .WithCostRate(0.5942m, 0)
                    .WithForwardPoints(0.0001m, 0)
                    .WithRateMultiplier(1)
                    .Build())
                .AddRow(new CrossCurrencyBuilder()
                    .WithTargetCurrency(CurrencyDefn.AUD)
                    .WithBaseCurrency(CurrencyDefn.GBP)
                    .IsPerBase(0)
                    .NDecIn(4)
                    .NDecPer(4)
                    .Build());

            AddDatabase(new VMSDB());
        }
    }
}