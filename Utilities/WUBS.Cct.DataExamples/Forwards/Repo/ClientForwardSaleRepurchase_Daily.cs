﻿using System;
using WUBS.Cct.DataExamples.DataBuilders;
using WUBS.Cct.DataExamples.Enums;
using WUBS.Cct.DataExamples.TestDataContainer;

namespace WUBS.Cct.DataExamples.Forwards.New
{
    public class ClientForwardSaleRepurchase_Daily : AbstractOrderData
    {
        public ClientForwardSaleRepurchase_Daily()
        {
            var tradeAmt = 2134.67m;
            var tradeCur = CurrencyDefn.EUR;
            var settleAmt = 1652.73m;
            var settleCur = CurrencyDefn.GBP;

            AddDatabase(new RueschlinkDB())
                .AddRow(new OrderHeaderBuilder<RueschlinkDB.ClientOrder.ClientOrderRow>()
                            .OfType(OrderType.ClientForwardSaleRepurchase)
                            .WithItemCount(1)
                            .SettlementCurrency(settleCur)
                            .Build())
                .AddRow(new LineItemBuilder<RueschlinkDB.OrderDetail.OrderDetailRow>()
                            .OfType(ItemType.ClientForwardSaleRepurchase)
                            .WithSettlementAmount(settleAmt)
                            .WithTradeAmount(tradeAmt)
                            .WithTradeCurrency(tradeCur)
                            .IsQuotedWithId(1)
                            .WithRate(new ItemRate(1.175m, 1, 4, 1, 1))
                            .Build());

            AddDatabase(new RLHistoryDB());

            AddDatabase(new CrsDB())
                .AddRow(new QuoteBuilder<CrsDB.Quote.QuoteRow>()
                            .WithCustomerRate(1.175m, 1)
                            .WithCostRate(0.8824m, 0)
                            .WithReutersRate(0.879292m, 0)
                            .WithSettlementRate(1.2666m)
                            .WithReportingRate(1.2666m)
                            .WithForwardPoints(0, 0)
                            .WithSettlementCurrency(settleCur)
                            .WithTradeCurrency(tradeCur)
                            .WithReportingCurrency(CurrencyDefn.HKD)
                            .WithSpread(7.5m)
                            .WithCostMarkup(-3.5347)
                            .Build());

            AddDatabase(new VMaRSDB());
        }
    }
}