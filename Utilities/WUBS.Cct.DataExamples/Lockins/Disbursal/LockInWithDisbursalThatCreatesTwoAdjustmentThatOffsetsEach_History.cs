using System;
using WUBS.Cct.DataExamples.DataBuilders;
using WUBS.Cct.DataExamples.Enums;
using WUBS.Cct.DataExamples.TestDataContainer;

namespace WUBS.Cct.DataExamples.Lockins.Disbursal
{
    public class LockInWithDisbursalThatCreatesTwoAdjustmentThatOffsetsEach_History : AbstractOrderData
    {
        public LockInWithDisbursalThatCreatesTwoAdjustmentThatOffsetsEach_History()
        {

            AddDatabase(new RLHistoryDB())
                //lockin
                .AddRow(new OrderHeaderBuilder<RLHistoryDB.TRRawHeader.TRRawHeaderRow>()
                    .OfType(OrderType.LockIn)
                    .WithOrderId(32047286)
                    .WithRelatedClientOrderId(32047501)
                    .Ordered(DateTime.Parse("2017-03-23 18:21:32.480"))
                    .SettlementCurrency(CurrencyDefn.USD)
                    .ForClient(16975)
                    .InApp(Application.GlobalPayPlus)
                    .Build())
                .AddRow(new LineItemBuilder<RLHistoryDB.trrawdetail.trrawdetailRow>()
                    .OfType(ItemType.LockIn)
                    .WithId(53707252)
                    .ForOrderId(32047286)
                    .WithItemNumber(1)
                    .WithTradeCurrency(CurrencyDefn.SGD)
                    .WithTradeAmount(5784m)
                    .WithSettlementAmount(4166.85m)
                    .WithForeignAmountInSettlementCurrency(false)
                    .FundedBy(80)
                    .IsQuotedWithId(69349261)
                    .WithRate(new ItemRate(1.3881m, 1, 4, 1, null))
                    .WithWindowLength(0)
                    .WithReleaseDate(DateTime.Parse("2017-03-24 00:00:00.000"))
                    .Build())
                .AddRow(new LineItemBuilder<RLHistoryDB.trrawdetail.trrawdetailRow>()
                    .OfType(ItemType.LockInAdjustment)
                    .WithId(53707851)
                    .ForOrderId(32047286)
                    .WithItemNumber(3)
                    .WithTradeCurrency(CurrencyDefn.SGD)
                    .WithTradeAmount(5784m)
                    .WithSettlementAmount(4166.85m)
                    .WithForeignAmountInSettlementCurrency(false)
                    .FundedBy(80)
                    .WithRate(new ItemRate(1.3881m, 1, null, 1, null))
                    .WithWindowLength(0)
                    .Build())
                .AddRow(new LineItemBuilder<RLHistoryDB.trrawdetail.trrawdetailRow>()
                    .OfType(ItemType.LockInAdjustment)
                    .WithId(53707852)
                    .ForOrderId(32047286)
                    .WithItemNumber(4)
                    .WithTradeCurrency(CurrencyDefn.SGD)
                    .WithTradeAmount(-5784m)
                    .WithSettlementAmount(-4166.85m)
                    .WithForeignAmountInSettlementCurrency(false)
                    .FundedBy(80)
                    .WithRate(new ItemRate(1.3881m, 1, null, 1, null))
                    .WithWindowLength(0)
                    .Build())

                .AddRow(new LineItemBuilder<RLHistoryDB.trrawdetail.trrawdetailRow>()
                    .OfType(ItemType.LockIn)
                    .WithId(53707253)
                    .ForOrderId(32047286)
                    .WithItemNumber(2)
                    .WithTradeCurrency(CurrencyDefn.CNH)
                    .WithTradeAmount(18268m)
                    .WithSettlementAmount(2787.69m)
                    .WithForeignAmountInSettlementCurrency(false)
                    .FundedBy(80)
                    .IsQuotedWithId(69349262)
                    .WithRate(new ItemRate(6.5531m, 1, 4, 1, null))
                    .WithWindowLength(0)
                    .WithReleaseDate(DateTime.Parse("2017-03-24 00:00:00.000"))
                    .Build())
                .AddRow(new LineItemBuilder<RLHistoryDB.trrawdetail.trrawdetailRow>()
                    .OfType(ItemType.LockInAdjustment)
                    .WithId(53707853)
                    .ForOrderId(32047286)
                    .WithItemNumber(5)
                    .WithTradeCurrency(CurrencyDefn.CNH)
                    .WithTradeAmount(-18268m)
                    .WithSettlementAmount(-2787.69m)
                    .WithForeignAmountInSettlementCurrency(false)
                    .FundedBy(80)
                    .WithRate(new ItemRate(6.5531m, 1, null, 1, null))
                    .WithWindowLength(0)
                    .Build())

                //disbursal
                .AddRow(new OrderHeaderBuilder<RLHistoryDB.TRRawHeader.TRRawHeaderRow>()
                    .OfType(OrderType.LockInDisbursal)
                    .WithOrderId(32047501)
                    .WithRelatedClientOrderId(32047286)
                    .Ordered(DateTime.Parse("2017-03-23 18:37:42.927"))
                    .SettlementCurrency(CurrencyDefn.USD)
                    .ForClient(16975)
                    .InApp(Application.GlobalPayPlus)
                    .Build())
                .AddRow(new LineItemBuilder<RLHistoryDB.trrawdetail.trrawdetailRow>()
                    .OfType(ItemType.EftPayment)
                    .WithId(53707592)
                    .WithRelatedId(53707252)
                    .ForOrderId(32047501)
                    .WithItemNumber(1)
                    .WithTradeCurrency(CurrencyDefn.SGD)
                    .WithTradeAmount(5784m)
                    .WithSettlementAmount(6904.8m)
                    .WithForeignAmountInSettlementCurrency(false)
                    .FundedBy(80)
                    .WithRate(new ItemRate(1.3881m, 1, 4, 1, null))
                    .WithWindowLength(0)
                    .WithReleaseDate(DateTime.Parse("2017-03-24 00:00:00.000"))
                    .Build())

                .AddRow(new OrderDetailValueDateBuilder<RLHistoryDB.TRRawDetailValueDate.TRRawDetailValueDateRow>()
                    .WithRequestedValueDate(DateTime.Parse("2017-03-24 00:00:00.000"))
                    .WithOrderDetailId(53707252)
                    .Build())
                .AddRow(new OrderDetailValueDateBuilder<RLHistoryDB.TRRawDetailValueDate.TRRawDetailValueDateRow>()
                    .WithRequestedValueDate(DateTime.Parse("2017-03-24 00:00:00.000"))
                    .WithOrderDetailId(53707253)
                    .Build())
                .AddRow(new OrderDetailValueDateBuilder<RLHistoryDB.TRRawDetailValueDate.TRRawDetailValueDateRow>()
                    .WithRequestedValueDate(DateTime.Parse("2017-03-24 00:00:00.000"))
                    .WithOrderDetailId(53707592)
                    .Build());

            AddDatabase(new RueschlinkDB())
                .AddRow(new RueschlinkDB.DisbursableFund.DisbursableFundRow()
                {
                    ClientOrder_ID = 32047286,
                    OrderDetail_ID = 53707252,
                    Currency_ID = CurrencyDefn.SGD.ID,
                    OriginalAmount = 5784d,
                    RemainingAmount = 0
                })
                .AddRow(new RueschlinkDB.DisbursableFund.DisbursableFundRow()
                {
                    ClientOrder_ID = 32047286,
                    OrderDetail_ID = 53707253,
                    Currency_ID = CurrencyDefn.CNH.ID,
                    OriginalAmount = 18268d,
                    RemainingAmount = 0
                });

            AddDatabase(new CrsDB())
                .AddRow(new QuoteBuilder<CrsDB.QuoteHistory.QuoteHistoryRow>()
                    .WithQuoteId(69349261)
                    .WithTradeCurrency(CurrencyDefn.SGD)
                    .WithSettlementCurrency(CurrencyDefn.USD)
                    .WithCustomerRate(1.3881m, 1)
                    .WithCostRate(1.3978m, 1)
                    .WithForwardPoints(0.0001m, 1)
                    .WithRateMultiplier(1)
                    .Build())

                .AddRow(new QuoteBuilder<CrsDB.QuoteHistory.QuoteHistoryRow>()
                    .WithQuoteId(69349262)
                    .WithTradeCurrency(CurrencyDefn.CNH)
                    .WithSettlementCurrency(CurrencyDefn.USD)
                    .WithCustomerRate(6.5531m, 1)
                    .WithCostRate(6.8637m, 1)
                    .WithForwardPoints(-0.0001m, 1)
                    .WithRateMultiplier(1)
                    .Build())

                .AddRow(new CrossCurrencyBuilder()
                    .WithTargetCurrency(CurrencyDefn.SGD)
                    .WithBaseCurrency(CurrencyDefn.USD)
                    .IsPerBase(1)
                    .NDecIn(4)
                    .NDecPer(4)
                    .Build())

                .AddRow(new CrossCurrencyBuilder()
                    .WithTargetCurrency(CurrencyDefn.CNH)
                    .WithBaseCurrency(CurrencyDefn.USD)
                    .IsPerBase(1)
                    .NDecIn(5)
                    .NDecPer(4)
                    .Build());

            AddDatabase(new VMSDB());
        }
    }
}
