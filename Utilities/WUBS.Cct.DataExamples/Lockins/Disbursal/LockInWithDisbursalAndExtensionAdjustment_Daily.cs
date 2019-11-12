using System;
using WUBS.Cct.DataExamples.DataBuilders;
using WUBS.Cct.DataExamples.Enums;
using WUBS.Cct.DataExamples.TestDataContainer;

namespace WUBS.Cct.DataExamples.Lockins.Disbursal
{
    public class LockInWithDisbursalAndExtensionAdjustment_Daily : AbstractOrderData
    {
        public LockInWithDisbursalAndExtensionAdjustment_Daily()
        {
            var tradeCur = CurrencyDefn.USD;
            var settleCur = CurrencyDefn.CHF;
            var customerRate = 0.9983m;
            var spotRate = 0.9927m;
            var quoteId = 70643063;
            var clientId = 460938;
            var lockInOrderId = 32693087;
            var disbursalOrderId = 32693091;
            var lockInLineItemId = 54734844;
            var adjustmentLineItemId = 54734865;
            var disbursalLineItemId = 54734854;
            var valueDate = new DateTime(2017, 5, 3).Date;
            var confirmationNo = string.Format("ABCD{0}", lockInOrderId);

            AddDatabase(new RueschlinkDB())
                .AddRow(new OrderHeaderBuilder<RueschlinkDB.ClientOrder.ClientOrderRow>()
                    .OfType(OrderType.LockIn)
                    .WithOrderId(lockInOrderId)
                    .WithRelatedClientOrderId(disbursalOrderId)
                    .WithConfirmationNumber(confirmationNo)
                    .WithItemCount(2)
                    .Ordered(DateTime.Parse("2017-05-03 02:46:29.200"))
                    .SettlementCurrency(settleCur)
                    .WithSettlementMethodId(SettlementMethod.Undefined)
                    .ForClient(clientId)
                    .InApp(Application.GlobalPayPlus)
                    .Build())
                .AddRow(new LineItemBuilder<RueschlinkDB.OrderDetail.OrderDetailRow>()
                    .OfType(ItemType.LockIn)
                    .WithId(lockInLineItemId)
                    .WithRelatedId(0)
                    .ForOrderId(lockInOrderId)
                    .WithItemNumber(1)
                    .WithTradeCurrency(tradeCur)
                    .WithTradeAmount(7559m)
                    .WithSettlementAmount(7546.15m)
                    .WithForeignAmountInSettlementCurrency(false)
                    .FundedBy(80)
                    .IsQuotedWithId(quoteId)
                    .WithRate(new ItemRate(customerRate, 0, 4, 1, null))
                    .WithWindowLength(1)
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
                    OriginalAmount = 7559d,
                    RemainingAmount = 7558.41d
                })
                .AddRow(new LineItemToContractMappingBuilder
                        <RueschlinkDB.LineItemToContractMapping.LineItemToContractMappingRow>()
                    .WithLineItemId(lockInLineItemId)
                    .WithContractId(45236387987257124)
                    .IsActive(true)
                    .Build())
                .AddRow(new LineItemBuilder<RueschlinkDB.OrderDetail.OrderDetailRow>()
                    .OfType(ItemType.LockInAdjustment)
                    .WithId(adjustmentLineItemId)
                    .ForOrderId(lockInOrderId)
                    .WithItemNumber(2)
                    .WithTradeCurrency(tradeCur)
                    .WithTradeAmount(0m)
                    .WithSettlementAmount(0.6m)
                    .WithForeignAmountInSettlementCurrency(false)
                    .FundedBy(80)
                    .WithRate(new ItemRate(customerRate, 0, 4, 1, null))
                    .WithWindowLength(0)
                    .Build())
                .AddRow(new OrderHeaderBuilder<RueschlinkDB.ClientOrder.ClientOrderRow>()
                    .OfType(OrderType.LockInDisbursal)
                    .WithOrderId(disbursalOrderId)
                    .WithRelatedClientOrderId(lockInOrderId)
                    .WithConfirmationNumber(confirmationNo)
                    .WithItemCount(0)
                    .Ordered(DateTime.Parse("2017-05-03 02:48:12.137"))
                    .SettlementCurrency(settleCur)
                    .WithSettlementMethodId(SettlementMethod.Wire)
                    .ForClient(clientId)
                    .InApp(Application.GlobalPayPlus)
                    .Build())
                .AddRow(new LineItemBuilder<RueschlinkDB.OrderDetail.OrderDetailRow>()
                    .OfType(ItemType.EftPayment)
                    .WithId(disbursalLineItemId)
                    .WithRelatedId(lockInLineItemId)
                    .ForOrderId(lockInOrderId)
                    .WithItemNumber(1)
                    .WithTradeCurrency(tradeCur)
                    .WithTradeAmount(7559.59m)
                    .WithSettlementAmount(7546.75m)
                    .WithForeignAmountInSettlementCurrency(false)
                    .FundedBy(80)
                    .WithRate(new ItemRate(customerRate, 0, 4, 1, 1))
                    .WithWindowLength(0)
                    .WithReleaseDate(valueDate)
                    .Build())
                .AddRow(new OrderDetailValueDateBuilder<RueschlinkDB.OrderDetailValueDate.OrderDetailValueDateRow>()
                    .WithRequestedValueDate(valueDate)
                    .WithOrderDetailId(disbursalLineItemId)
                    .Build());

            AddDatabase(new RLHistoryDB());

            AddDatabase(new CrsDB())
                .AddRow(new QuoteBuilder<CrsDB.Quote.QuoteRow>()
                .WithQuoteId(quoteId)
                    .WithTradeCurrency(tradeCur)
                    .WithSettlementCurrency(settleCur)
                    .WithCustomerRate(customerRate, 0)
                    .WithCostRate(spotRate, 0)
                    .WithForwardPoints(0.0001m, 0)
                    .WithRateMultiplier(1)
                    .Build())
                .AddRow(new CrossCurrencyBuilder()
                    .WithTargetCurrency(tradeCur)
                    .WithBaseCurrency(settleCur)
                    .IsPerBase(0)
                    .NDecIn(4)
                    .NDecPer(4)
                    .Build());

            AddDatabase(new VMSDB());
        }
    }
}
