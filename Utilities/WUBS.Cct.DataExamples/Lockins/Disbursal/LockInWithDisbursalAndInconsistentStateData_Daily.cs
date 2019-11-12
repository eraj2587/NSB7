using System;
using WUBS.Cct.DataExamples.DataBuilders;
using WUBS.Cct.DataExamples.Enums;
using WUBS.Cct.DataExamples.TestDataContainer;

namespace WUBS.Cct.DataExamples.Lockins.Disbursal
{
    public class LockInWithDisbursalAndInconsistentStateData_Daily : AbstractOrderData
    {
        //WTP-292 Lockin missing in WSFX
        //Lock-In order with 1 line item loaded with header and no line item during "move" procedure at Commit time

        public LockInWithDisbursalAndInconsistentStateData_Daily()
        {
            var tradeAmt = 400m;
            var tradeCur = CurrencyDefn.NOK;
            var settleAmt = 36.11m;
            var settleCur = CurrencyDefn.GBP;
            var customerRate = 11.0786m;
            var spotRate = 11.2189m;
            var quoteId = 70855477;
            var clientId = 1363991;
            var lockInOrderId = 32795711;
            var disbursalOrderId = 32795713;
            var lockInLineItemId = 54880472;
            var disbursalLineItemId = 54880473;
            var valueDate = new DateTime(2017, 5, 11).Date;
            var requestedValueDate = new DateTime(2017, 5, 12).Date;
            var confirmationNo = string.Format("ABCD{0}", lockInOrderId);

            AddDatabase(new RueschlinkDB())
                .AddRow(new OrderHeaderBuilder<RueschlinkDB.ClientOrder.ClientOrderRow>()
                    .OfType(OrderType.LockIn)
                    .WithOrderId(lockInOrderId)
                    .WithRelatedClientOrderId(disbursalOrderId)
                    .WithConfirmationNumber(confirmationNo)
                    .WithItemCount(1)
                    .Ordered(DateTime.Parse("2017-05-09 11:18:23.157"))
                    .SettlementCurrency(settleCur)
                    .WithSettlementMethodId(SettlementMethod.Wire)
                    .ForClient(clientId)
                    .InApp(Application.Nexus)
                    .Build())
                //                .AddRow(new LineItemBuilder<RueschlinkDB.OrderDetail.OrderDetailRow>()
                //                    .OfType(ItemType.LockIn)
                //                    .WithId(lockInLineItemId)
                //                    .ForOrderId(lockInOrderId)
                //                    .WithItemNumber(1)
                //                    .WithTradeCurrency(tradeCur)
                //                    .WithTradeAmount(tradeAmt)
                //                    .WithSettlementAmount(settleAmt)
                //                    .WithForeignAmountInSettlementCurrency(true)
                //                    .FundedBy(80)
                //                    .IsQuotedWithId(quoteId)
                //                    .WithRate(new ItemRate(customerRate, 1, 4, 1, null))
                //                    .WithWindowLength(0)
                //                    .WithReleaseDate(valueDate)
                //                    .Build())
                //                .AddRow(new OrderDetailValueDateBuilder<RueschlinkDB.OrderDetailValueDate.OrderDetailValueDateRow>()
                //                    .WithRequestedValueDate(valueDate)
                //                    .WithOrderDetailId(lockInLineItemId)
                //                    .Build())
                .AddRow(new RueschlinkDB.DisbursableFund.DisbursableFundRow()
                {
                    ClientOrder_ID = lockInOrderId,
                    OrderDetail_ID = lockInLineItemId,
                    Currency_ID = tradeCur.ID,
                    OriginalAmount = (double)tradeAmt,
                    RemainingAmount = 0
                })
                .AddRow(new OrderHeaderBuilder<RueschlinkDB.ClientOrder.ClientOrderRow>()
                    .OfType(OrderType.LockInDisbursal)
                    .WithOrderId(disbursalOrderId)
                    .WithRelatedClientOrderId(lockInOrderId)
                    .WithConfirmationNumber(confirmationNo)
                    .WithItemCount(1)
                    .Ordered(DateTime.Parse("2017-05-09 11:18:24.970"))
                    .SettlementCurrency(settleCur)
                    .WithSettlementMethodId(SettlementMethod.Wire)
                    .ForClient(clientId)
                    .InApp(Application.Nexus)
                    .Build())
                .AddRow(new LineItemBuilder<RueschlinkDB.OrderDetail.OrderDetailRow>()
                    .OfType(ItemType.EftPayment)
                    .WithId(disbursalLineItemId)
                    .ForOrderId(disbursalOrderId)
                    .WithItemNumber(1)
                    .WithTradeCurrency(tradeCur)
                    .WithTradeAmount(tradeAmt)
                    .WithSettlementAmount(settleAmt)
                    .WithForeignAmountInSettlementCurrency(true)
                    .FundedBy(80)
                    .WithRate(new ItemRate(customerRate, 1, 4, 1, null))
                    .WithWindowLength(0)
                    .WithReleaseDate(valueDate)
                    .Build())
                .AddRow(new OrderDetailValueDateBuilder<RueschlinkDB.OrderDetailValueDate.OrderDetailValueDateRow>()
                    .WithRequestedValueDate(requestedValueDate)
                    .WithOrderDetailId(disbursalLineItemId)
                    .Build());

            AddDatabase(new RLHistoryDB());

            AddDatabase(new CrsDB())
                .AddRow(new QuoteBuilder<CrsDB.Quote.QuoteRow>()
                .WithQuoteId(quoteId)
                    .WithTradeCurrency(tradeCur)
                    .WithSettlementCurrency(settleCur)
                    .WithCustomerRate(customerRate, 1)
                    .WithCostRate(spotRate, 1)
                    .WithForwardPoints(0, 1)
                    .WithRateMultiplier(1)
                    .Build())
                .AddRow(new CrossCurrencyBuilder()
                    .WithTargetCurrency(tradeCur)
                    .WithBaseCurrency(settleCur)
                    .IsPerBase(1)
                    .NDecIn(6)
                    .NDecPer(4)
                    .Build());

            AddDatabase(new VMSDB());
        }
    }
}