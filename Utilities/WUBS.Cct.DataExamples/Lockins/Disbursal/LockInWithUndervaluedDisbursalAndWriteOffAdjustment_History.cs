using System;
using WUBS.Cct.DataExamples.DataBuilders;
using WUBS.Cct.DataExamples.Enums;
using WUBS.Cct.DataExamples.TestDataContainer;

namespace WUBS.Cct.DataExamples.Lockins.Disbursal
{
    public class LockInWithUndervaluedDisbursalAndWriteOffAdjustment_History : AbstractOrderData
    {
        public LockInWithUndervaluedDisbursalAndWriteOffAdjustment_History()
        {
            var tradeCur = CurrencyDefn.EUR;
            var settleCur = CurrencyDefn.CZK;
            var customerRate = 26.329m;
            var spotRate = 26.154m;
            var quoteId = 72879772;
            var clientId = 768583;
            var lockInOrderId = 33699626;
            var disbursalOrderId = 33699675;
            var lockInLineItemId = 56265920;
            var disbursalLineItemId = 56265972;
            var lockInAdjustmentLineItemId = 56265977;
            var valueDate = new DateTime(2017, 7, 3).Date;
            var confirmationNo = string.Format("ABCD{0}", lockInOrderId);

            AddDatabase(new RueschlinkDB())
                .AddRow(new OrderHeaderBuilder<RLHistoryDB.TRRawHeader.TRRawHeaderRow>()
                    .OfType(OrderType.LockIn)
                    .WithOrderId(lockInOrderId)
                    .WithRelatedClientOrderId(disbursalOrderId)
                    .WithConfirmationNumber(confirmationNo)
                    .WithItemCount(2)
                    .Ordered(DateTime.Parse("2017-07-03 09:03:12.533"))
                    .SettlementCurrency(settleCur)
                    .WithSettlementMethodId(SettlementMethod.Undefined)
                    .ForClient(clientId)
                    .InApp(Application.GlobalPayPlus)
                    .Build())
                .AddRow(new LineItemBuilder<RLHistoryDB.trrawdetail.trrawdetailRow>()
                    .OfType(ItemType.LockIn)
                    .WithId(lockInLineItemId)
                    .WithRelatedId(0)
                    .ForOrderId(lockInOrderId)
                    .WithItemNumber(1)
                    .WithTradeCurrency(tradeCur)
                    .WithTradeAmount(7000m)
                    .WithSettlementAmount(184303m)
                    .WithForeignAmountInSettlementCurrency(false)
                    .FundedBy(80)
                    .IsQuotedWithId(quoteId)
                    .WithRate(new ItemRate(customerRate, 0, 4, 1, null))
                    .WithWindowLength(1)
                    .WithReleaseDate(valueDate)
                    .Build())
                .AddRow(new OrderDetailValueDateBuilder<RLHistoryDB.TRRawDetailValueDate.TRRawDetailValueDateRow>()
                    .WithRequestedValueDate(valueDate)
                    .WithOrderDetailId(lockInLineItemId)
                    .Build())
                .AddRow(new LineItemBuilder<RLHistoryDB.trrawdetail.trrawdetailRow>()
                    .OfType(ItemType.LockInAdjustment)
                    .WithId(lockInAdjustmentLineItemId)
                    .ForOrderId(lockInOrderId)
                    .WithItemNumber(2)
                    .WithTradeCurrency(tradeCur)
                    .WithTradeAmount(-50m)
                    .WithSettlementAmount(-1316.45m)
                    .WithForeignAmountInSettlementCurrency(false)
                    .FundedBy(80)
                    .WithRate(new ItemRate(customerRate, 0, null, 1, null))
                    .WithWindowLength(0)
                    .WithReleaseDate(valueDate)
                    .Build())
                .AddRow(new RueschlinkDB.DisbursableFund.DisbursableFundRow()
                {
                    ClientOrder_ID = lockInOrderId,
                    OrderDetail_ID = lockInLineItemId,
                    Currency_ID = tradeCur.ID,
                    OriginalAmount = 7000d,
                    RemainingAmount = 0
                })

                .AddRow(new OrderHeaderBuilder<RLHistoryDB.TRRawHeader.TRRawHeaderRow>()
                    .OfType(OrderType.LockInDisbursal)
                    .WithOrderId(disbursalOrderId)
                    .WithRelatedClientOrderId(lockInOrderId)
                    .WithConfirmationNumber(confirmationNo)
                    .WithItemCount(1)
                    .Ordered(DateTime.Parse("2017-07-03 09:04:45.113"))
                    .SettlementCurrency(settleCur)
                    .WithSettlementMethodId(SettlementMethod.Wire)
                    .ForClient(clientId)
                    .InApp(Application.GlobalPayPlus)
                    .Build())
                .AddRow(new LineItemBuilder<RLHistoryDB.trrawdetail.trrawdetailRow>()
                    .OfType(ItemType.EftPayment)
                    .WithId(disbursalLineItemId)
                    .WithRelatedId(lockInLineItemId)
                    .ForOrderId(disbursalOrderId)
                    .WithItemNumber(1)
                    .WithTradeCurrency(tradeCur)
                    .WithTradeAmount(6950m)
                    .WithSettlementAmount(182986.55m)
                    .WithForeignAmountInSettlementCurrency(false)
                    .FundedBy(80)
                    .WithRate(new ItemRate(customerRate, 0, 4, 1, 1))
                    .WithWindowLength(0)
                    .WithReleaseDate(valueDate)
                    .Build())
                .AddRow(new OrderDetailValueDateBuilder<RLHistoryDB.TRRawDetailValueDate.TRRawDetailValueDateRow>()
                    .WithRequestedValueDate(valueDate)
                    .WithOrderDetailId(disbursalLineItemId)
                    .Build());

            AddDatabase(new RueschlinkDB())
                .AddRow(new LineItemToContractMappingBuilder
                        <RueschlinkDB.LineItemToContractMapping.LineItemToContractMappingRow>()
                    .WithLineItemId(lockInLineItemId)
                    .WithContractId(56336621763127348)
                    .IsActive(true)
                    .Build());

            AddDatabase(new CrsDB())
                .AddRow(new QuoteBuilder<CrsDB.QuoteHistory.QuoteHistoryRow>()
                .WithQuoteId(quoteId)
                    .WithTradeCurrency(tradeCur)
                    .WithSettlementCurrency(settleCur)
                    .WithCustomerRate(customerRate, 0)
                    .WithCostRate(spotRate, 0)
                    .WithForwardPoints(0.0034m, 0)
                    .WithRateMultiplier(1)
                    .Build())
                .AddRow(new CrossCurrencyBuilder()
                    .WithTargetCurrency(tradeCur)
                    .WithBaseCurrency(settleCur)
                    .IsPerBase(0)
                    .NDecIn(4)
                    .NDecPer(6)
                    .Build());

            AddDatabase(new VMSDB());
        }
    }
}
