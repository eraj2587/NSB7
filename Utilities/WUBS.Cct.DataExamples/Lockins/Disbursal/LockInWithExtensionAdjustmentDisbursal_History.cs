using System;
using WUBS.Cct.DataExamples.DataBuilders;
using WUBS.Cct.DataExamples.Enums;
using WUBS.Cct.DataExamples.TestDataContainer;

namespace WUBS.Cct.DataExamples.Lockins.Disbursal
{
    public class LockInWithExtensionAdjustmentDisbursal_History : AbstractOrderData
    {
        public LockInWithExtensionAdjustmentDisbursal_History()
        {

            AddDatabase(new RLHistoryDB())
                //lockin
                .AddRow(new OrderHeaderBuilder<RLHistoryDB.TRRawHeader.TRRawHeaderRow>()
                    .OfType(OrderType.LockIn)
                    .WithOrderId(33694469)
                    .WithRelatedClientOrderId(33694475)
                    .WithItemCount(2)
                    .Ordered(DateTime.Parse("2017-07-03 03:54:25.470"))
                    .SettlementCurrency(CurrencyDefn.USD)
                    .ForClient(1889324)
                    .InApp(Application.GlobalPayPlus)
                    .Build())
                .AddRow(new LineItemBuilder<RLHistoryDB.trrawdetail.trrawdetailRow>()
                    .OfType(ItemType.LockIn)
                    .WithId(56258398)
                    .ForOrderId(33694469)
                    .WithItemNumber(1)
                    .WithTradeCurrency(CurrencyDefn.CHF)
                    .WithTradeAmount(644.55m)
                    .WithSettlementAmount(679.71m)
                    .WithForeignAmountInSettlementCurrency(true)
                    .FundedBy(80)
                    .IsQuotedWithId(72866020)
                    .WithRate(new ItemRate(0.9483m, 1, 4, 1, null))
                    .WithWindowLength(2)
                    .WithReleaseDate(DateTime.Parse("2017-07-03 00:00:00.000"))
                    .Build())
                .AddRow(new LineItemBuilder<RLHistoryDB.trrawdetail.trrawdetailRow>()
                    .OfType(ItemType.LockInAdjustment)
                    .WithId(56258442)
                    .ForOrderId(33694469)
                    .WithItemNumber(2)
                    .WithTradeCurrency(CurrencyDefn.CHF)
                    .WithTradeAmount(0.01m)
                    .WithSettlementAmount(0.01m)
                    .WithForeignAmountInSettlementCurrency(false)
                    .FundedBy(80)
                    .WithRate(new ItemRate(0.9483m, 1, 4, 1, null))
                    .WithWindowLength(0)
                    .WithReleaseDate(DateTime.Parse("2017-07-03 00:00:00.000"))
                    .Build())
                .AddRow(new LineItemBuilder<RLHistoryDB.trrawdetail.trrawdetailRow>()
                    .OfType(ItemType.LockInAdjustment)
                    .WithId(56258444)
                    .ForOrderId(33694469)
                    .WithItemNumber(3)
                    .WithTradeCurrency(CurrencyDefn.CHF)
                    .WithTradeAmount(0)
                    .WithSettlementAmount(-0.02m)
                    .WithForeignAmountInSettlementCurrency(false)
                    .FundedBy(80)
                    .WithRate(new ItemRate(0.9483m, 1, 4, 1, null))
                    .WithWindowLength(0)
                    .Build())

                //disbursal
                .AddRow(new OrderHeaderBuilder<RLHistoryDB.TRRawHeader.TRRawHeaderRow>()
                    .OfType(OrderType.LockInDisbursal)
                    .WithOrderId(33694475)
                    .WithRelatedClientOrderId(33694469)
                    .WithItemCount(1)
                    .Ordered(DateTime.Parse("2017-07-03 03:54:25.487"))
                    .SettlementCurrency(CurrencyDefn.USD)
                    .ForClient(1889324)
                    .InApp(Application.GlobalPayPlus)
                    .Build())
                .AddRow(new LineItemBuilder<RLHistoryDB.trrawdetail.trrawdetailRow>()
                    .OfType(ItemType.EftPayment)
                    .WithId(56258407)
                    .WithRelatedId(56258398)
                    .ForOrderId(33694475)
                    .WithItemNumber(1)
                    .WithTradeCurrency(CurrencyDefn.CHF)
                    .WithTradeAmount(644.56m)
                    .WithSettlementAmount(679.7m)
                    .WithForeignAmountInSettlementCurrency(false)
                    .FundedBy(80)
                    .WithRate(new ItemRate(0.9483m, 1, 4, 1, null))
                    .WithWindowLength(0)
                    .WithReleaseDate(DateTime.Parse("2017-07-03 00:00:00.000"))
                    .Build())
                .AddRow(new OrderDetailValueDateBuilder<RLHistoryDB.TRRawDetailValueDate.TRRawDetailValueDateRow>()
                    .WithRequestedValueDate(DateTime.Parse("2017-07-03 00:00:00.000"))
                    .WithOrderDetailId(56258398)
                    .Build());

            AddDatabase(new RueschlinkDB())
                .AddRow(new RueschlinkDB.DisbursableFund.DisbursableFundRow()
                {
                    ClientOrder_ID = 33694469,
                    OrderDetail_ID = 56258444,
                    Currency_ID = CurrencyDefn.CHF.ID,
                    OriginalAmount = 644.55d,
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
                .WithQuoteId(72866020)
                    .WithTradeCurrency(CurrencyDefn.CHF)
                    .WithSettlementCurrency(CurrencyDefn.USD)
                    .WithCustomerRate(0.9483m, 1)
                    .WithCostRate(0.9589m, 1)
                    .WithForwardPoints(0.0001m, 1)
                    .WithRateMultiplier(1)
                    .Build())
                .AddRow(new CrossCurrencyBuilder()
                    .WithTargetCurrency(CurrencyDefn.CHF)
                    .WithBaseCurrency(CurrencyDefn.USD)
                    .IsPerBase(1)
                    .NDecIn(4)
                    .NDecPer(4)
                    .Build());

            AddDatabase(new VMSDB());
        }
    }
}
