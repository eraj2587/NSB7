using System;
using WUBS.Cct.DataExamples.DataBuilders;
using WUBS.Cct.DataExamples.Enums;
using WUBS.Cct.DataExamples.TestDataContainer;

namespace WUBS.Cct.DataExamples.Lockins.Disbursal
{
    public class LockInWithDisbursal_History : AbstractOrderData
    {
        public LockInWithDisbursal_History()
        {
            var tradeAmt = 5188067m;
            var tradeCur = CurrencyDefn.IDR;
            var settleAmt = 400m;
            var settleCur = CurrencyDefn.USD;
            var customerRate = 0.0000771m;
            var spotRate = 13236m;
            var quoteId = 70649275;
            var clientId = 3224982;
            var lockInOrderId = 32696155;
            var disbursalOrderId = 32696777;
            var lockInLineItemId = 54740483;
            var disbursalLineItemId = 54741233;
            var valueDate = new DateTime(2017, 5, 5).Date;
            var confirmationNo = string.Format("ABCD{0}", lockInOrderId);

            AddDatabase(new RLHistoryDB())
                .AddRow(new OrderHeaderBuilder<RLHistoryDB.TRRawHeader.TRRawHeaderRow>()
                    .OfType(OrderType.LockIn)
                    .WithOrderId(lockInOrderId)
                    .WithRelatedClientOrderId(disbursalOrderId)
                    .WithConfirmationNumber(confirmationNo)
                    .WithItemCount(1)
                    .Ordered(DateTime.Parse("2017-05-03 06:06:07.287"))
                    .SettlementCurrency(settleCur)
                    .WithSettlementMethodId(SettlementMethod.Wire)
                    .ForClient(clientId)
                    .InApp(Application.Nexus)
                    .Build())
                .AddRow(new LineItemBuilder<RLHistoryDB.trrawdetail.trrawdetailRow>()
                    .OfType(ItemType.LockIn)
                    .WithId(lockInLineItemId)
                    .ForOrderId(lockInOrderId)
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
                    .WithOrderDetailId(lockInLineItemId)
                    .Build())
                .AddRow(new OrderHeaderBuilder<RLHistoryDB.TRRawHeader.TRRawHeaderRow>()
                    .OfType(OrderType.LockInDisbursal)
                    .WithOrderId(disbursalOrderId)
                    .WithRelatedClientOrderId(lockInOrderId)
                    .WithConfirmationNumber(confirmationNo)
                    .WithItemCount(1)
                    .Ordered(DateTime.Parse("2017-05-03 06:36:11.313"))
                    .SettlementCurrency(settleCur)
                    .WithSettlementMethodId(SettlementMethod.Drawdown)
                    .ForClient(clientId)
                    .InApp(Application.Nexus)
                    .Build())
                .AddRow(new LineItemBuilder<RLHistoryDB.trrawdetail.trrawdetailRow>()
                    .OfType(ItemType.EftPayment)
                    .WithId(disbursalLineItemId)
                    .ForOrderId(disbursalOrderId)
                    .WithItemNumber(1)
                    .WithTradeCurrency(tradeCur)
                    .WithTradeAmount(tradeAmt)
                    .WithSettlementAmount(settleAmt)
                    .WithForeignAmountInSettlementCurrency(true)
                    .FundedBy(80)
                    .WithRate(new ItemRate(customerRate, 0, 8, 1, null))
                    .WithTradeCurrency(tradeCur)
                    .WithWindowLength(0)
                    .WithReleaseDate(valueDate)
                    .Build());

            AddDatabase(new RueschlinkDB())
                .AddRow(new RueschlinkDB.DisbursableFund.DisbursableFundRow()
                {
                    ClientOrder_ID = lockInOrderId,
                    OrderDetail_ID = lockInLineItemId,
                    Currency_ID = tradeCur.ID,
                    OriginalAmount = (double)tradeAmt,
                    RemainingAmount = 0
                })
                .AddRow(new LineItemToContractMappingBuilder
                        <RueschlinkDB.LineItemToContractMapping.LineItemToContractMappingRow>()
                        .WithLineItemId(lockInLineItemId)
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
