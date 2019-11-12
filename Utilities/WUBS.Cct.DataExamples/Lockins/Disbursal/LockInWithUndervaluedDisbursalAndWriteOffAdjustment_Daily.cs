using System;
using WUBS.Cct.DataExamples.DataBuilders;
using WUBS.Cct.DataExamples.Enums;
using WUBS.Cct.DataExamples.TestDataContainer;

namespace WUBS.Cct.DataExamples.Lockins.Disbursal
{
    public class LockInWithUndervaluedDisbursalAndWriteOffAdjustment_Daily : AbstractOrderData
    {
        public LockInWithUndervaluedDisbursalAndWriteOffAdjustment_Daily()
        {
            var tradeCur = CurrencyDefn.EUR;
            var settleCur = CurrencyDefn.CHF;
            var customerRate = 1.2136m;
            var spotRate = 1.2922m;
            var quoteId = 28685806;
            var clientId = 30190;
            var lockInOrderId = 12541567;
            var disbursalOrderId = 12541572;
            var lockInLineItemId = 20796637;
            var valueDate = new DateTime(2012, 9, 13).Date;
            var confirmationNo = string.Format("ABCD{0}", lockInOrderId);

            AddDatabase(new RueschlinkDB())
                .AddRow(new OrderHeaderBuilder<RueschlinkDB.ClientOrder.ClientOrderRow>()
                    .OfType(OrderType.LockIn)
                    .WithOrderId(lockInOrderId)
                    .WithRelatedClientOrderId(disbursalOrderId)
                    .WithConfirmationNumber(confirmationNo)
                    .WithItemCount(2)
                    .Ordered(DateTime.Parse("2012-09-12 10:22:03.103"))
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
                    .WithTradeAmount(23088.71m)
                    .WithSettlementAmount(28020.45m)
                    .WithForeignAmountInSettlementCurrency(false)
                    .FundedBy(80)
                    .IsQuotedWithId(quoteId)
                    .WithRate(new ItemRate(customerRate, 0, 4, 1, null))
                    .WithWindowLength(0)
                    .WithReleaseDate(valueDate)
                    .Build())
               .AddRow(new LineItemBuilder<RueschlinkDB.OrderDetail.OrderDetailRow>()
                    .OfType(ItemType.LockInAdjustment)
                    .WithId(20797064)
                    .ForOrderId(lockInOrderId)
                    .WithItemNumber(2)
                    .WithTradeCurrency(tradeCur)
                    .WithTradeAmount(-0.09m)
                    .WithSettlementAmount(-0.1m)
                    .WithForeignAmountInSettlementCurrency(false)
                    .FundedBy(80)
                    .WithRate(new ItemRate(customerRate, 0, null, 1, null))
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
                    OriginalAmount = 23088.71d,
                    RemainingAmount = 14163d
                })

                .AddRow(new OrderHeaderBuilder<RueschlinkDB.ClientOrder.ClientOrderRow>()
                    .OfType(OrderType.LockInDisbursal)
                    .WithOrderId(disbursalOrderId)
                    .WithRelatedClientOrderId(lockInOrderId)
                    .WithConfirmationNumber(confirmationNo)
                    .WithItemCount(0)
                    .Ordered(DateTime.Parse("2017-07-04 06:15:35.040"))
                    .SettlementCurrency(settleCur)
                    .WithSettlementMethodId(SettlementMethod.Wire)
                    .ForClient(clientId)
                    .InApp(Application.GlobalPayPlus)
                    .Build())
                .AddRow(new LineItemBuilder<RueschlinkDB.OrderDetail.OrderDetailRow>()
                    .OfType(ItemType.EftPayment)
                    .WithId(20796668)
                    .WithRelatedId(lockInLineItemId)
                    .ForOrderId(disbursalOrderId)
                    .WithItemNumber(1)
                    .WithTradeCurrency(tradeCur)
                    .WithTradeAmount(8897.42m)
                    .WithSettlementAmount(10797.9m)
                    .WithForeignAmountInSettlementCurrency(false)
                    .FundedBy(80)
                    .WithRate(new ItemRate(customerRate, 0, 4, 1, null))
                    .WithWindowLength(0)
                    .WithReleaseDate(valueDate)
                    .Build())
                .AddRow(new LineItemBuilder<RueschlinkDB.OrderDetail.OrderDetailRow>()
                    .OfType(ItemType.AchCredit)
                    .WithId(20796669)
                    .WithRelatedId(0)
                    .ForOrderId(disbursalOrderId)
                    .WithItemNumber(2)
                    .WithTradeCurrency(tradeCur)
                    .WithTradeAmount(27.45m)
                    .WithSettlementAmount(33.3m)
                    .WithForeignAmountInSettlementCurrency(false)
                    .FundedBy(80)
                    .WithRate(new ItemRate(customerRate, 0, 4, 1, null))
                    .WithWindowLength(0)
                    .WithReleaseDate(valueDate)
                    .Build())
                .AddRow(new LineItemBuilder<RueschlinkDB.OrderDetail.OrderDetailRow>()
                    .OfType(ItemType.EftPayment)
                    .WithId(20796670)
                    .WithRelatedId(0)
                    .ForOrderId(disbursalOrderId)
                    .WithItemNumber(3)
                    .WithTradeCurrency(tradeCur)
                    .WithTradeAmount(14163.75m)
                    .WithSettlementAmount(17189.15m)
                    .WithForeignAmountInSettlementCurrency(false)
                    .FundedBy(80)
                    .WithRate(new ItemRate(customerRate, 0, 4, 1, null))
                    .WithWindowLength(0)
                    .WithReleaseDate(valueDate)
                    .Build());

            AddDatabase(new RLHistoryDB());

            AddDatabase(new CrsDB())
                .AddRow(new QuoteBuilder<CrsDB.Quote.QuoteRow>()
                .WithQuoteId(quoteId)
                    .WithTradeCurrency(tradeCur)
                    .WithSettlementCurrency(settleCur)
                    .WithCustomerRate(customerRate, 1)
                    .WithCostRate(spotRate, 1)
                    .WithForwardPoints(-0.0001m, 1)
                    .WithRateMultiplier(1)
                    .Build())
                .AddRow(new CrossCurrencyBuilder()
                    .WithTargetCurrency(tradeCur)
                    .WithBaseCurrency(settleCur)
                    .IsPerBase(1)
                    .NDecIn(6)
                    .NDecPer(6)
                    .Build());

            AddDatabase(new VMSDB());
        }
    }
}
