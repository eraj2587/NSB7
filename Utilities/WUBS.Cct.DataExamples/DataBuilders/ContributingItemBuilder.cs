using System;
using WUBS.Cct.DataExamples.Enums;
using WUBS.Cct.DataExamples.TestDataContainer;

namespace WUBS.Cct.DataExamples.DataBuilders
{
    internal class ContributingItemBuilder<T>
        where T : StaticDataRow, new()
    {
        private int orderDetailId = 1;
        private int clientOrderId = 1;
        private int fundedBy = (int)PaymentFundedBy.Fx;
        private double tradeAmount = 148.81;
        private double settlementAmount = 100;
        private ItemRate itemRate = null;
        private int? quoteId = null;
        private short itemNumber = 1;
        private bool? preDelivery = null;

        public ContributingItemBuilder()
        {
            if (typeof(T) != typeof(RueschlinkDB.ContributingItem.ContributingItemRow) &&
                typeof(T) != typeof(RLHistoryDB.ContributingItemHistory.ContributingItemHistoryRow))
                throw new InvalidOperationException(string.Format("Generic type T ({0}) is not supported by this builder", typeof(T).Name));
        }

        public T Build()
        {
            dynamic row = new T();
            
            row.OrderDetail_ID = orderDetailId;
            row.ItemNo = itemNumber;
            row.ClientOrder_ID = clientOrderId;
            row.Amount = tradeAmount;
            row.Extension = settlementAmount;
            row.Quote_ID = quoteId;
            row.Rate = itemRate != null ? (double)itemRate.RateValue : 1;
            row.ItemRateIsPer = itemRate != null ? (short?)itemRate.IsPer : null;
            row.ItemRate_NDec = itemRate != null ? (int?)itemRate.NDec : null;
            row.RateMultiplier = itemRate != null ? (int?)itemRate.RateMultiplier : null;
            row.RateMultiplier_Inv = itemRate != null ? (short?)itemRate.InvRateMultiplier : null;
            row.FundedBy = fundedBy;
            row.RelatedOrderDetail_ID = 0;
            row.PreDelivery = preDelivery;
            row.initdt = DateTime.Now;
            row.upddt = DateTime.Now;

            return row;
        }

        public ContributingItemBuilder<T> ForOrderId(int clientOrderId)
        {
            this.clientOrderId = clientOrderId;
            return this;
        }

        public ContributingItemBuilder<T> FundedBy(int fundedBy)
        {
            this.fundedBy = fundedBy;
            return this;
        }

        public ContributingItemBuilder<T> WithTradeAmount(decimal tradeAmount)
        {
            this.tradeAmount = (double)tradeAmount;
            return this;
        }

        public ContributingItemBuilder<T> WithSettlementAmount(decimal settlementAmount)
        {
            this.settlementAmount = (double)settlementAmount;
            return this;
        }

        public ContributingItemBuilder<T> WithRate(ItemRate rate)
        {
            this.itemRate = rate;
            return this;
        }

        public ContributingItemBuilder<T> IsQuotedWithId(int quoteId)
        {
            this.quoteId = quoteId;
            return this;
        }

        public ContributingItemBuilder<T> WithId(int detailId)
        {
            this.orderDetailId = detailId;
            return this;
        }

        public ContributingItemBuilder<T> IsItemNumber(short itemNumber)
        {
            this.itemNumber = itemNumber;
            return this;
        }

        public ContributingItemBuilder<T> IsPredelivery(bool preDelivery)
        {
            this.preDelivery = preDelivery;
            return this;
        }
    }
}