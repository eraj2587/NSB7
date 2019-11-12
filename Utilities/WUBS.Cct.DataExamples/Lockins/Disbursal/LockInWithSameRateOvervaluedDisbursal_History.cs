using System;
using WUBS.Cct.DataExamples.DataBuilders;
using WUBS.Cct.DataExamples.Enums;
using WUBS.Cct.DataExamples.TestDataContainer;

namespace WUBS.Cct.DataExamples.Lockins.Disbursal
{
    public class LockInWithSameRateOvervaluedDisbursal_History : AbstractOrderData
    {
        public LockInWithSameRateOvervaluedDisbursal_History()
        {

            AddDatabase(new RLHistoryDB())
                //lockin
                .AddRow(new OrderHeaderBuilder<RLHistoryDB.TRRawHeader.TRRawHeaderRow>()
                    .OfType(OrderType.LockIn)
                    .WithOrderId(33471852)
                    .WithRelatedClientOrderId(33471863)
                    .WithItemCount(2)
                    .Ordered(DateTime.Parse("2017-06-19 14:50:46.480"))
                    .SettlementCurrency(CurrencyDefn.USD)
                    .ForClient(30947)
                    .InApp(Application.GlobalPayPlus)
                    .Build())
                .AddRow(new LineItemBuilder<RLHistoryDB.trrawdetail.trrawdetailRow>()
                    .OfType(ItemType.LockIn)
                    .WithId(55908401)
                    .ForOrderId(33471852)
                    .WithItemNumber(1)
                    .WithTradeCurrency(CurrencyDefn.EUR)
                    .WithTradeAmount(3600)
                    .WithSettlementAmount(4167.72m)
                    .WithForeignAmountInSettlementCurrency(false)
                    .FundedBy(80)
                    .IsQuotedWithId(72311077)
                    .WithRate(new ItemRate(1.1577m, 0, 4, 1, null))
                    .WithWindowLength(0)
                    .WithReleaseDate(DateTime.Parse("2017-06-20 00:00:00.000"))
                    .Build())
                .AddRow(new LineItemBuilder<RLHistoryDB.trrawdetail.trrawdetailRow>()
                    .OfType(ItemType.LockInAdjustment)
                    .WithId(55908427)
                    .ForOrderId(33471852)
                    .WithItemNumber(2)
                    .WithTradeCurrency(CurrencyDefn.EUR)
                    .WithTradeAmount(81.5m)
                    .WithSettlementAmount(94.35m)
                    .WithForeignAmountInSettlementCurrency(false)
                    .FundedBy(80)
                    .WithRate(new ItemRate(1.1577m, 0, 4, 1, null))
                    .WithWindowLength(0)
                    .WithReleaseDate(DateTime.Parse("2017-06-20 00:00:00.000"))
                    .Build())

                //disbursal
                .AddRow(new OrderHeaderBuilder<RLHistoryDB.TRRawHeader.TRRawHeaderRow>()
                    .OfType(OrderType.LockInDisbursal)
                    .WithOrderId(33471863)
                    .WithRelatedClientOrderId(33471852)
                    .WithItemCount(1)
                    .Ordered(DateTime.Parse("2017-06-19 14:50:46.503"))
                    .SettlementCurrency(CurrencyDefn.USD)
                    .ForClient(30947)
                    .InApp(Application.GlobalPayPlus)
                    .Build())
                .AddRow(new LineItemBuilder<RLHistoryDB.trrawdetail.trrawdetailRow>()
                    .OfType(ItemType.EftPayment)
                    .WithId(55908418)
                    .WithRelatedId(55908401)
                    .ForOrderId(33471863)
                    .WithItemNumber(1)
                    .WithTradeCurrency(CurrencyDefn.EUR)
                    .WithTradeAmount(3681.5m)
                    .WithSettlementAmount(4262.07m)
                    .WithForeignAmountInSettlementCurrency(false)
                    .FundedBy(80)
                    .WithRate(new ItemRate(1.1577m, 0, 4, 1, null))
                    .WithWindowLength(0)
                    .WithReleaseDate(DateTime.Parse("2017-06-20 00:00:00.000"))
                    .Build())
                .AddRow(new OrderDetailValueDateBuilder<RLHistoryDB.TRRawDetailValueDate.TRRawDetailValueDateRow>()
                    .WithRequestedValueDate(DateTime.Parse("2017-06-20 00:00:00.000"))
                    .WithOrderDetailId(55908401)
                    .Build())
                .AddRow(new OrderDetailValueDateBuilder<RLHistoryDB.TRRawDetailValueDate.TRRawDetailValueDateRow>()
                    .WithRequestedValueDate(DateTime.Parse("2017-06-20 00:00:00.000"))
                    .WithOrderDetailId(55908418)
                    .Build());

            AddDatabase(new RueschlinkDB())
                .AddRow(new RueschlinkDB.DisbursableFund.DisbursableFundRow()
                {
                    ClientOrder_ID = 33471852,
                    OrderDetail_ID = 55908401,
                    Currency_ID = CurrencyDefn.EUR.ID,
                    OriginalAmount = 3600d,
                    RemainingAmount = 0
                })
                .AddRow(new LineItemToContractMappingBuilder<RueschlinkDB.LineItemToContractMapping.LineItemToContractMappingRow>()
                        .WithId(1)
                        .WithLineItemId(55908401)
                        .WithContractId(1)
                        .IsActive(true)
                        .Build());

            AddDatabase(new CrsDB())
                .AddRow(new QuoteBuilder<CrsDB.QuoteHistory.QuoteHistoryRow>()
                .WithQuoteId(72311077)
                    .WithTradeCurrency(CurrencyDefn.EUR)
                    .WithSettlementCurrency(CurrencyDefn.USD)
                    .WithCustomerRate(1.1577m, 0)
                    .WithCostRate(1.1157m, 0)
                    .WithForwardPoints(-0.0001m, 0)
                    .WithRateMultiplier(1)
                    .Build())
                .AddRow(new CrossCurrencyBuilder()
                    .WithTargetCurrency(CurrencyDefn.EUR)
                    .WithBaseCurrency(CurrencyDefn.USD)
                    .IsPerBase(0)
                    .NDecIn(4)
                    .NDecPer(4)
                    .Build());

            AddDatabase(new VMSDB());
        }
    }
}
