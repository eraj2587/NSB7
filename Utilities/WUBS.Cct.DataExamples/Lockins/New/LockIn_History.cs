using System;
using WUBS.Cct.DataExamples.DataBuilders;
using WUBS.Cct.DataExamples.Enums;
using WUBS.Cct.DataExamples.TestDataContainer;

namespace WUBS.Cct.DataExamples.Lockins.New
{
    public class LockIn_History : AbstractOrderData
    {
        //CCT order 32696155, line item 54740483 (prod)
        public LockIn_History()
        {
            var tradeAmt = 5188067m;
            var tradeCur = CurrencyDefn.IDR;
            var settleAmt = 400m;
            var settleCur = CurrencyDefn.USD;
            var customerRate = 0.0000771m;
            var spotRate = 13236m;
            var quoteId = 70649275;
            var orderId = 32696155;
            var lineItemId = 54740483;
            var valueDate = new DateTime(2017, 5, 5).Date;

            AddDatabase(new RLHistoryDB())
                .AddRow(new OrderHeaderBuilder<RLHistoryDB.TRRawHeader.TRRawHeaderRow>()
                    .OfType(OrderType.LockIn)
                    .WithOrderId(orderId)
                    .WithItemCount(1)
                    .Ordered(DateTime.Parse("2017-05-03 06:06:07.287"))
                    .SettlementCurrency(settleCur)
                    .WithSettlementMethodId(SettlementMethod.Wire)
                    .ForClient(3224982)
                    .InApp(Application.Nexus)
                    .Build())
                .AddRow(new LineItemBuilder<RLHistoryDB.trrawdetail.trrawdetailRow>()
                    .OfType(ItemType.LockIn)
                    .WithId(lineItemId)
                    .ForOrderId(orderId)
                    .WithItemNumber(1)
                    .WithTradeCurrency(tradeCur)
                    .WithTradeAmount(tradeAmt)
                    .WithSettlementAmount(settleAmt)
                    .WithForeignAmountInSettlementCurrency(true)
                    .FundedBy(80)
                    .IsQuotedWithId(quoteId)
                    .WithRate(new ItemRate(customerRate, 0, 8, 1, null))
                    .WithWindowLength(0)
                    .WithReleaseDate(valueDate)
                    .Build())
                .AddRow(new OrderDetailValueDateBuilder<RLHistoryDB.TRRawDetailValueDate.TRRawDetailValueDateRow>()
                    .WithRequestedValueDate(valueDate)
                    .WithOrderDetailId(lineItemId)
                    .Build());

            AddDatabase(new RueschlinkDB())
                .AddRow(new RueschlinkDB.DisbursableFund.DisbursableFundRow()
                {
                    ClientOrder_ID = orderId,
                    OrderDetail_ID = lineItemId,
                    Currency_ID = tradeCur.ID,
                    OriginalAmount = (double)tradeAmt,
                    RemainingAmount = 0
                })
                .AddRow(new LineItemToContractMappingBuilder
                        <RueschlinkDB.LineItemToContractMapping.LineItemToContractMappingRow>()
                        .WithLineItemId(lineItemId)
                        .WithContractId(45261508269504358)
                        .IsActive(true)
                        .Build());

            AddDatabase(new CrsDB())
                .AddRow(new QuoteBuilder<CrsDB.QuoteHistory.QuoteHistoryRow>()
                .WithQuoteId(quoteId)
                    .WithTradeCurrency(tradeCur)
                    .WithSettlementCurrency(settleCur)
                    .WithCustomerRate(customerRate, 0)
                    .WithCostRate(spotRate, 1)
                    .WithForwardPoints(0, 1)
                    .WithRateMultiplier(1)
                    .Build())
                .AddRow(new CrossCurrencyBuilder()
                    .WithTargetCurrency(tradeCur)
                    .WithBaseCurrency(settleCur)
                    .IsPerBase(1)
                    .NDecIn(8)
                    .NDecPer(0)
                    .Build());

            AddDatabase(new VMSDB());
        }
    }
}
