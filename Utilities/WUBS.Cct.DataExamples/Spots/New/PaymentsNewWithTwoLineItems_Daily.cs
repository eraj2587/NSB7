using System;
using WUBS.Cct.DataExamples.DataBuilders;
using WUBS.Cct.DataExamples.Enums;
using WUBS.Cct.DataExamples.TestDataContainer;

namespace WUBS.Cct.DataExamples.Spots.New
{
    public class PaymentsNewWithTwoLineItems_Daily : AbstractOrderData
    {
        /// <summary>
        /// OTR4485096
        /// </summary>
        public PaymentsNewWithTwoLineItems_Daily()
        {
            AddDatabase(new RueschlinkDB())
                .AddRow(new OrderHeaderBuilder<RueschlinkDB.ClientOrder.ClientOrderRow>()
                    .OfType(OrderType.PaymentsNew)
                    .WithOrderId(33605932)
                    .WithItemCount(2)
                    .Ordered(DateTime.Parse("2017-06-27 15:00:02.253"))
                    .SettlementCurrency(CurrencyDefn.USD)
                    .WithSettlementMethodId(SettlementMethod.EDebit)
                    .ForClient(13306)
                    .InApp(Application.GlobalPay)
                    .Build())
                .AddRow(new LineItemBuilder<RueschlinkDB.OrderDetail.OrderDetailRow>()
                    .OfType(ItemType.EftPayment)
                    .WithId(56119856)
                    .ForOrderId(33605932)
                    .WithItemNumber(1)
                    .WithTradeCurrency(CurrencyDefn.MXN)
                    .WithTradeAmount(49800)
                    .WithSettlementAmount(2792.23m)
                    .FundedBy(80)
                    .WithRate(new ItemRate(17.83519m, 1, 5, 1, null))
                    .IsQuotedWithId(72643361)
                    .WithRelatedId(0)
                    .WithWindowLength(0)
                    .WithReleaseDate(DateTime.Parse("2017-06-28 00:00:00.000"))
                    .Build())
                .AddRow(new LineItemBuilder<RueschlinkDB.OrderDetail.OrderDetailRow>()
                    .OfType(ItemType.EftPayment)
                    .WithId(56119857)
                    .ForOrderId(33605932)
                    .WithItemNumber(2)
                    .WithTradeCurrency(CurrencyDefn.MXN)
                    .WithTradeAmount(53951.31m)
                    .WithSettlementAmount(3024.99m)
                    .FundedBy(80)
                    .WithRate(new ItemRate(17.83519m, 1, 5, 1, null))
                    .IsQuotedWithId(72643361)
                    .WithRelatedId(0)
                    .WithWindowLength(0)
                    .WithReleaseDate(DateTime.Parse("2017-06-28 00:00:00.000"))
                    .Build())
                .AddRow(new OrderDetailValueDateBuilder<RueschlinkDB.OrderDetailValueDate.OrderDetailValueDateRow>()
                    .WithOrderDetailId(56119856)
                    .WithRequestedValueDate(DateTime.Parse("2017-06-28 00:00:00.000"))
                    .Build())
                .AddRow(new OrderDetailValueDateBuilder<RueschlinkDB.OrderDetailValueDate.OrderDetailValueDateRow>()
                    .WithOrderDetailId(56119857)
                    .WithRequestedValueDate(DateTime.Parse("2017-06-28 00:00:00.000"))
                    .Build());

            AddDatabase(new RLHistoryDB());

            AddDatabase(new CrsDB())
                .AddRow(new QuoteBuilder<CrsDB.Quote.QuoteRow>()
                    .WithQuoteId(72643361)
                    .WithTradeCurrency(CurrencyDefn.MXN)
                    .WithSettlementCurrency(CurrencyDefn.USD)
                    .WithCustomerRate(17.83519m, 1)
                    .WithCostRate(17.92755m, 1)
                    .WithForwardPoints(-0.00273m, 1)
                    .WithRateMultiplier(1)
                    .Build())
                .AddRow(new CrossCurrencyBuilder()
                    .WithTargetCurrency(CurrencyDefn.MXN)
                    .WithBaseCurrency(CurrencyDefn.USD)
                    .IsPerBase(1)
                    .NDecIn(7)
                    .NDecPer(5)
                    .Build());

            AddDatabase(new VMSDB());
        }
    }
}