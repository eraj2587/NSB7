using System;
using WUBS.Cct.DataExamples.DataBuilders;
using WUBS.Cct.DataExamples.Enums;
using WUBS.Cct.DataExamples.TestDataContainer;

namespace WUBS.Cct.DataExamples.Lockins.Disbursal
{
    public class LockInWithDisbursal_Daily : AbstractOrderData
    {
        public LockInWithDisbursal_Daily()
        {
            var tradeAmt = 395.10m;
            var tradeCur = CurrencyDefn.ILS;
            var settleAmt = 117.92m;
            var settleCur = CurrencyDefn.USD;
            var customerRate = 3.3506m;
            var spotRate = 3.4668m;
            var quoteId = 72767839;
            var clientId = 1087928;
            var lockInOrderId = 33654597;
            var disbursalOrderId = 33655036;
            var lockInLineItemId = 56193169;
            var disbursalLineItemId = 56194501;
            var valueDate = new DateTime(2017, 7, 3).Date;
            var requestedValueDate = new DateTime(2017, 6, 30).Date;
            var confirmationNo = string.Format("ABCD{0}", lockInOrderId);

            AddDatabase(new RueschlinkDB())
                .AddRow(new OrderHeaderBuilder<RueschlinkDB.ClientOrder.ClientOrderRow>()
                    .OfType(OrderType.LockIn)
                    .WithOrderId(lockInOrderId)
                    .WithRelatedClientOrderId(disbursalOrderId)
                    .WithConfirmationNumber(confirmationNo)
                    .WithItemCount(1)
                    .Ordered(DateTime.Parse("2017-06-29 13:42:15.617"))
                    .SettlementCurrency(settleCur)
                    .WithSettlementMethodId(SettlementMethod.Wire)
                    .ForClient(clientId)
                    .InApp(Application.Nexus)
                    .Build())
                .AddRow(new LineItemBuilder<RueschlinkDB.OrderDetail.OrderDetailRow>()
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
                    .WithRate(new ItemRate(customerRate, 0, 4, 1, null))
                    .WithWindowLength(0)
                    .WithReleaseDate(valueDate)
                    .Build())
                .AddRow(new OrderDetailValueDateBuilder<RueschlinkDB.OrderDetailValueDate.OrderDetailValueDateRow>()
                    .WithRequestedValueDate(valueDate)
                    .WithOrderDetailId(lockInLineItemId)
                    .Build())
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
                    .WithContractId(55646957580336426)
                    .IsActive(true)
                    .Build())
                .AddRow(new OrderHeaderBuilder<RueschlinkDB.ClientOrder.ClientOrderRow>()
                    .OfType(OrderType.LockInDisbursal)
                    .WithOrderId(disbursalOrderId)
                    .WithRelatedClientOrderId(lockInOrderId)
                    .WithConfirmationNumber(confirmationNo)
                    .WithItemCount(1)
                    .Ordered(DateTime.Parse("2017-06-29 14:00:16.163"))
                    .SettlementCurrency(settleCur)
                    .WithSettlementMethodId(SettlementMethod.Drawdown)
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
                    .IsQuotedWithId(quoteId)
                    .WithRate(new ItemRate(customerRate, 0, 4, 1, null))
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
                    .NDecIn(4)
                    .NDecPer(4)
                    .Build());

            AddDatabase(new VMSDB());
        }
    }
}
