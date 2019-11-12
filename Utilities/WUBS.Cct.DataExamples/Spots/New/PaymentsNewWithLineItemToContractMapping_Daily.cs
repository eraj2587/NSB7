using System;
using WUBS.Cct.DataExamples.DataBuilders;
using WUBS.Cct.DataExamples.Enums;
using WUBS.Cct.DataExamples.TestDataContainer;

namespace WUBS.Cct.DataExamples.Spots.New
{
    public class PaymentsNewWithLineItemToContractMapping_Daily : AbstractOrderData
    {
        public PaymentsNewWithLineItemToContractMapping_Daily()
        {
            var valueDate = DateTime.Now.AddDays(2).Date;

            AddDatabase(new RueschlinkDB())
                .AddRow(new OrderHeaderBuilder<RueschlinkDB.ClientOrder.ClientOrderRow>().OfType(OrderType.PaymentsNew).WithItemCount(1).Build())
                .AddRow(new LineItemBuilder<RueschlinkDB.OrderDetail.OrderDetailRow>().OfType(ItemType.EftPayment).Build())
                .AddRow(new OrderDetailValueDateBuilder<RueschlinkDB.OrderDetailValueDate.OrderDetailValueDateRow>()
                    .WithRequestedValueDate(valueDate)
                    .Build())
                .AddRow(new RueschlinkDB.LineItemToContractMapping.LineItemToContractMappingRow
                    {
                        LineItemId = 1,
                        ContractId = 1,
                        IsActive = true
                    });

            AddDatabase(new RLHistoryDB());

            AddDatabase(new CrsDB())
                .AddRow(new QuoteBuilder<CrsDB.Quote.QuoteRow>()
                    .WithCustomerRate(1.4881m, 1)
                    .WithCostRate(1.4653m, 1)
                    .WithForwardPoints(0, 1)
                    .Build())
                .AddRow(new CrossCurrencyBuilder().Build());

            AddDatabase(new VMSDB());
        }
    }
}