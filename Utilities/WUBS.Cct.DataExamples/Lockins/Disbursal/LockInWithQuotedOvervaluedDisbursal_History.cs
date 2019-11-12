using System;
using WUBS.Cct.DataExamples.DataBuilders;
using WUBS.Cct.DataExamples.Enums;
using WUBS.Cct.DataExamples.TestDataContainer;

namespace WUBS.Cct.DataExamples.Lockins.Disbursal
{
    public class LockInWithQuotedOvervaluedDisbursal_History : AbstractOrderData
    {
        public LockInWithQuotedOvervaluedDisbursal_History()
        {

            AddDatabase(new RLHistoryDB())
                //lockin
                .AddRow(new OrderHeaderBuilder<RLHistoryDB.TRRawHeader.TRRawHeaderRow>()
                    .OfType(OrderType.LockIn)
                    .WithOrderId(31960351)
                    .WithRelatedClientOrderId(31960418)
                    .WithItemCount(2)
                    .Ordered(DateTime.Parse("2017-03-20 03:37:23.350"))
                    .SettlementCurrency(CurrencyDefn.EUR)
                    .ForClient(23652)
                    .InApp(Application.GlobalPayPlus)
                    .Build())
                .AddRow(new LineItemBuilder<RLHistoryDB.trrawdetail.trrawdetailRow>()
                    .OfType(ItemType.LockIn)
                    .WithId(53570304)
                    .ForOrderId(31960351)
                    .WithItemNumber(1)
                    .WithTradeCurrency(CurrencyDefn.CHF)
                    .WithTradeAmount(200000)
                    .WithSettlementAmount(186532.36m)
                    .WithForeignAmountInSettlementCurrency(false)
                    .FundedBy(80)
                    .IsQuotedWithId(69180048)
                    .WithRate(new ItemRate(1.0722m, 1, 4, 1, null))
                    .WithWindowLength(1)
                    .WithReleaseDate(DateTime.Parse("2017-03-20 00:00:00.000"))
                    .Build())
                .AddRow(new LineItemBuilder<RLHistoryDB.trrawdetail.trrawdetailRow>()
                    .OfType(ItemType.LockInAdjustment)
                    .WithId(53570811)
                    .ForOrderId(31960351)
                    .WithItemNumber(2)
                    .WithTradeCurrency(CurrencyDefn.CHF)
                    .WithTradeAmount(14440)
                    .WithSettlementAmount(13467.64m)
                    .WithForeignAmountInSettlementCurrency(false)
                    .FundedBy(80)
                    .IsQuotedWithId(69180171)
                    .WithRate(new ItemRate(1.0722m, 1, 4, 1, null))
                    .WithWindowLength(0)
                    .WithReleaseDate(DateTime.Parse("2017-03-20 00:00:00.000"))
                    .Build())

                //disbursal
                .AddRow(new OrderHeaderBuilder<RLHistoryDB.TRRawHeader.TRRawHeaderRow>()
                    .OfType(OrderType.LockInDisbursal)
                    .WithOrderId(31960418)
                    .WithRelatedClientOrderId(31960351)
                    .WithItemCount(1)
                    .Ordered(DateTime.Parse("2017-03-20 03:35:02.743"))
                    .SettlementCurrency(CurrencyDefn.EUR)
                    .ForClient(23652)
                    .InApp(Application.GlobalPayPlus)
                    .Build())
                .AddRow(new LineItemBuilder<RLHistoryDB.trrawdetail.trrawdetailRow>()
                    .OfType(ItemType.EftPayment)
                    .WithId(53570806)
                    .WithRelatedId(53570304)
                    .ForOrderId(31960418)
                    .WithItemNumber(1)
                    .WithTradeCurrency(CurrencyDefn.CHF)
                    .WithTradeAmount(214440)
                    .WithSettlementAmount(200000)
                    .WithForeignAmountInSettlementCurrency(false)
                    .FundedBy(80)
                    .WithRate(new ItemRate(1.0722m, 1, 4, 1, null))
                    .WithWindowLength(0)
                    .WithReleaseDate(DateTime.Parse("2017-03-20 00:00:00.000"))
                    .Build())
                .AddRow(new OrderDetailValueDateBuilder<RLHistoryDB.TRRawDetailValueDate.TRRawDetailValueDateRow>()
                    .WithRequestedValueDate(DateTime.Parse("2017-03-20 00:00:00.000"))
                    .WithOrderDetailId(53570304)
                    .Build())
                .AddRow(new OrderDetailValueDateBuilder<RLHistoryDB.TRRawDetailValueDate.TRRawDetailValueDateRow>()
                    .WithRequestedValueDate(DateTime.Parse("2017-03-20 00:00:00.000"))
                    .WithOrderDetailId(53570806)
                    .Build());

            AddDatabase(new RueschlinkDB())
                .AddRow(new RueschlinkDB.DisbursableFund.DisbursableFundRow()
                {
                    ClientOrder_ID = 31960351,
                    OrderDetail_ID = 53570304,
                    Currency_ID = CurrencyDefn.CHF.ID,
                    OriginalAmount = 200000d,
                    RemainingAmount = 0
                })
                .AddRow(new LineItemToContractMappingBuilder<RueschlinkDB.LineItemToContractMapping.LineItemToContractMappingRow>()
                        .WithId(1)
                        .WithLineItemId(53570304)
                        .WithContractId(1)
                        .IsActive(true)
                        .Build())
                .AddRow(new LineItemToContractMappingBuilder<RueschlinkDB.LineItemToContractMapping.LineItemToContractMappingRow>()
                        .WithId(2)
                        .WithLineItemId(53570811)
                        .WithContractId(2)
                        .IsActive(true)
                        .Build());

            AddDatabase(new CrsDB())
                .AddRow(new QuoteBuilder<CrsDB.QuoteHistory.QuoteHistoryRow>()
                    .WithQuoteId(69180048)
                    .WithTradeCurrency(CurrencyDefn.CHF)
                    .WithSettlementCurrency(CurrencyDefn.EUR)
                    .WithCustomerRate(1.0722m, 1)
                    .WithCostRate(1.0726m, 1)
                    .WithForwardPoints(0, 1)
                    .WithRateMultiplier(1)
                    .Build())
                .AddRow(new QuoteBuilder<CrsDB.QuoteHistory.QuoteHistoryRow>()
                    .WithQuoteId(69180171)
                    .WithTradeCurrency(CurrencyDefn.CHF)
                    .WithSettlementCurrency(CurrencyDefn.EUR)
                    .WithCustomerRate(1.0722m, 1)
                    .WithCostRate(1.0726m, 1)
                    .WithForwardPoints(0, 1)
                    .WithRateMultiplier(1)
                    .Build())
                .AddRow(new CrossCurrencyBuilder()
                    .WithTargetCurrency(CurrencyDefn.CHF)
                    .WithBaseCurrency(CurrencyDefn.EUR)
                    .IsPerBase(1)
                    .NDecIn(6)
                    .NDecPer(4)
                    .Build());

            AddDatabase(new VMSDB());
        }
    }
}
