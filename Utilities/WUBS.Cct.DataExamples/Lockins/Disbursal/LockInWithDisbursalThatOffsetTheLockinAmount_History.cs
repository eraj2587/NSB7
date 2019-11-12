using System;
using WUBS.Cct.DataExamples.DataBuilders;
using WUBS.Cct.DataExamples.Enums;
using WUBS.Cct.DataExamples.TestDataContainer;

namespace WUBS.Cct.DataExamples.Lockins.Disbursal
{
    public class LockInWithDisbursalThatOffsetTheLockinAmount_History : AbstractOrderData
    {
        public LockInWithDisbursalThatOffsetTheLockinAmount_History()
        {

            AddDatabase(new RLHistoryDB())
                //lockin
                .AddRow(new OrderHeaderBuilder<RLHistoryDB.TRRawHeader.TRRawHeaderRow>()
                    .OfType(OrderType.LockIn)
                    .WithOrderId(33862309)
                    .WithRelatedClientOrderId(33866041)
                    .WithItemCount(2)
                    .Ordered(DateTime.Parse("2017-07-12 12:18:56.150"))
                    .SettlementCurrency(CurrencyDefn.USD)
                    .ForClient(1087928)
                    .InApp(Application.Nexus)
                    .Build())
                .AddRow(new LineItemBuilder<RLHistoryDB.trrawdetail.trrawdetailRow>()
                    .OfType(ItemType.LockIn)
                    .WithId(56498732)
                    .ForOrderId(33862309)
                    .WithItemNumber(1)
                    .WithTradeCurrency(CurrencyDefn.EUR)
                    .WithTradeAmount(4530.83m)
                    .WithSettlementAmount(5350)
                    .WithForeignAmountInSettlementCurrency(true)
                    .FundedBy(80)
                    .IsQuotedWithId(73282286)
                    .WithRate(new ItemRate(1.1808m, 0, 4, 1, null))
                    .WithWindowLength(2)
                    .WithReleaseDate(DateTime.Parse("2017-07-14 00:00:00.000"))
                    .Build())
                .AddRow(new LineItemBuilder<RLHistoryDB.trrawdetail.trrawdetailRow>()
                    .OfType(ItemType.LockInAdjustment)
                    .WithId(56505628)
                    .ForOrderId(33862309)
                    .WithItemNumber(2)
                    .WithTradeCurrency(CurrencyDefn.EUR)
                    .WithTradeAmount(-4530.83m)
                    .WithSettlementAmount(-5350)
                    .WithForeignAmountInSettlementCurrency(false)
                    .FundedBy(80)
                    .WithRate(new ItemRate(1.1808m, 0, null, 1, null))
                    .WithWindowLength(0)
                    .Build())

                //disbursal
                .AddRow(new OrderHeaderBuilder<RLHistoryDB.TRRawHeader.TRRawHeaderRow>()
                    .OfType(OrderType.LockInDisbursal)
                    .WithOrderId(33866041)
                    .WithRelatedClientOrderId(33862309)
                    .WithItemCount(1)
                    .Ordered(DateTime.Parse("2017-07-12 16:38:17.123"))
                    .SettlementCurrency(CurrencyDefn.USD)
                    .ForClient(1087928)
                    .InApp(Application.GlobalPayPlus)
                    .Build())
                .AddRow(new LineItemBuilder<RLHistoryDB.trrawdetail.trrawdetailRow>()
                    .OfType(ItemType.IntoHolding)
                    .WithId(56505250)
                    .WithRelatedId(56498732)
                    .ForOrderId(33866041)
                    .WithItemNumber(1)
                    .WithTradeCurrency(CurrencyDefn.EUR)
                    .WithTradeAmount(0)
                    .WithSettlementAmount(0)
                    .WithForeignAmountInSettlementCurrency(false)
                    .FundedBy(80)
                    .IsQuotedWithId(0)
                    .WithRate(new ItemRate(0, 0, 4, 1, null))
                    .WithWindowLength(0)
                    .WithReleaseDate(DateTime.Parse("2017-07-14 00:00:00.000"))
                    .Build())
                .AddRow(new OrderDetailValueDateBuilder<RLHistoryDB.TRRawDetailValueDate.TRRawDetailValueDateRow>()
                    .WithRequestedValueDate(DateTime.Parse("2017-07-14 00:00:00.000"))
                    .WithOrderDetailId(56498732)
                    .Build())
                .AddRow(new OrderDetailValueDateBuilder<RLHistoryDB.TRRawDetailValueDate.TRRawDetailValueDateRow>()
                    .WithRequestedValueDate(DateTime.Parse("2017-07-14 00:00:00.000"))
                    .WithOrderDetailId(56505250)
                    .Build());

            AddDatabase(new RueschlinkDB())
                .AddRow(new RueschlinkDB.DisbursableFund.DisbursableFundRow()
                {
                    ClientOrder_ID = 33862309,
                    OrderDetail_ID = 56498732,
                    Currency_ID = CurrencyDefn.EUR.ID,
                    OriginalAmount = 4530.83d,
                    RemainingAmount = 0
                })
                .AddRow(new LineItemToContractMappingBuilder<RueschlinkDB.LineItemToContractMapping.LineItemToContractMappingRow>()
                        .WithId(1)
                        .WithLineItemId(56498732)
                        .WithContractId(57991992300221919)
                        .IsActive(true)
                        .Build());

            AddDatabase(new CrsDB())
                .AddRow(new QuoteBuilder<CrsDB.QuoteHistory.QuoteHistoryRow>()
                .WithQuoteId(73282286)
                    .WithTradeCurrency(CurrencyDefn.EUR)
                    .WithSettlementCurrency(CurrencyDefn.USD)
                    .WithCustomerRate(1.1808m, 0)
                    .WithCostRate(1.1425m, 0)
                    .WithForwardPoints(0, 0)
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
