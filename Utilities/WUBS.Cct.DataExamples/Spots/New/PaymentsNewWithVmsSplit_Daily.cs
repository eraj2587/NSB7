using System;
using WUBS.Cct.DataExamples.DataBuilders;
using WUBS.Cct.DataExamples.Enums;
using WUBS.Cct.DataExamples.TestDataContainer;

namespace WUBS.Cct.DataExamples.Spots.New
{
    public class PaymentsNewWithVmsSplit_Daily : AbstractOrderData
    {
        public PaymentsNewWithVmsSplit_Daily()
        {
            var valueDate = DateTime.Now.AddDays(2).Date;

            AddDatabase(new RueschlinkDB())
                .AddRow(new OrderHeaderBuilder<RueschlinkDB.ClientOrder.ClientOrderRow>()
                    .OfType(OrderType.PaymentsNew)
                    .WithOrderId(1)
                    .WithItemCount(1)
                    .Build())
                .AddRow(new LineItemBuilder<RueschlinkDB.OrderDetail.OrderDetailRow>()
                    .OfType(ItemType.EftPayment)
                    .WithId(1)
                    .IsQuotedWithId(1)
                    .WithRate(new ItemRate(1.5m, 1, 4, 1, 1))
                    .Build())
                .AddRow(new OrderDetailValueDateBuilder<RueschlinkDB.OrderDetailValueDate.OrderDetailValueDateRow>()
                    .WithRequestedValueDate(valueDate)
                    .Build())

                .AddRow(new OrderHeaderBuilder<RueschlinkDB.ClientOrder.ClientOrderRow>()
                    .OfType(OrderType.PaymentsNew)
                    .WithOrderId(2)
                    .WithItemCount(1)
                    .Build())
                .AddRow(new LineItemBuilder<RueschlinkDB.OrderDetail.OrderDetailRow>()
                    .OfType(ItemType.EftPayment)
                    .WithId(2)
                    .ForOrderId(2)
                    .IsQuotedWithId(2)
                    .WithRate(new ItemRate(1.6m, 1, 4, 1, 1))
                    .Build())
                .AddRow(new OrderDetailValueDateBuilder<RueschlinkDB.OrderDetailValueDate.OrderDetailValueDateRow>()
                    .WithRequestedValueDate(valueDate)
                    .Build());

            AddDatabase(new RLHistoryDB());

            AddDatabase(new CrsDB())
                .AddRow(new QuoteBuilder<CrsDB.Quote.QuoteRow>()
                    .WithQuoteId(1)
                    .WithCustomerRate(1.5m, 1)
                    .WithCostRate(1.47m, 1)
                    .WithForwardPoints(0, 1)
                    .Build())
                .AddRow(new QuoteBuilder<CrsDB.Quote.QuoteRow>()
                    .WithQuoteId(2)
                    .WithCustomerRate(1.6m, 1)
                    .WithCostRate(1.57m, 1)
                    .WithForwardPoints(0, 1)
                    .Build())
                .AddRow(new CrossCurrencyBuilder().Build());

            AddDatabase(new VMSDB())
                .AddRow(new VMSDB.VmsEventLog.VmsEventLogRow()
                {
                    LOG_ID = 1,
                    ClientOrder_ID = 1,
                    OrderDetail_ID = 1,
                    NewClientOrder_ID = 2,
                    NewOrderDetail_ID = 2,
                    ITEM_NO = 1,
                    EVENT = "SPLIT",
                    PROCESSED = 0
                });
        }
    }
}