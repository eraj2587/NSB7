using System;
using WUBS.Cct.DataExamples.DataBuilders;
using WUBS.Cct.DataExamples.Enums;
using WUBS.Cct.DataExamples.TestDataContainer;

namespace WUBS.Cct.DataExamples.Lockins.New
{
    public class LockIn_Daily : AbstractOrderData
    {
        public LockIn_Daily()
        {
            var tradeAmt = 12326.24m;
            var tradeCur = CurrencyDefn.MXN;
            var settleAmt = 700m;
            var settleCur = CurrencyDefn.USD;
            var customerRate = 0.0567894m;
            var spotRate = 17.9683m;
            var quoteId = 72641027;
            var orderId = 33604835;
            var lineItemId = 56118084;
            var valueDate = new DateTime(2017,6,29).Date;

            AddDatabase(new RueschlinkDB())
                .AddRow(new OrderHeaderBuilder<RueschlinkDB.ClientOrder.ClientOrderRow>()
                    .OfType(OrderType.LockIn)
                    .WithOrderId(orderId)
                    .WithItemCount(1)
                    .Ordered(DateTime.Parse("2017-06-27 13:41:49.970"))
                    .SettlementCurrency(settleCur)
                    .WithSettlementMethodId(SettlementMethod.Wire)
                    .ForClient(2505969)
                    .InApp(Application.Nexus)
                    .Build())
                .AddRow(new LineItemBuilder<RueschlinkDB.OrderDetail.OrderDetailRow>()
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
                    .WithRate(new ItemRate(customerRate, 0, 4, 1, null))
                    .WithWindowLength(0)
                    .WithReleaseDate(valueDate)
                    .Build())
                .AddRow(new OrderDetailValueDateBuilder<RueschlinkDB.OrderDetailValueDate.OrderDetailValueDateRow>()
                    .WithRequestedValueDate(valueDate)
                    .WithOrderDetailId(lineItemId)
                    .Build())
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
                        .WithContractId(55284517028063693)
                        .IsActive(true)
                    .Build());

            AddDatabase(new RLHistoryDB());

            AddDatabase(new CrsDB())                
                .AddRow(new QuoteBuilder<CrsDB.Quote.QuoteRow>()
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
                    .NDecIn(4)
                    .NDecPer(4)
                    .Build());

            AddDatabase(new VMSDB());
        }
    }
}
