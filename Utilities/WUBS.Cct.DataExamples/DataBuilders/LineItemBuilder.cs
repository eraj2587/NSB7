using System;
using WUBS.Cct.DataExamples.Enums;
using WUBS.Cct.DataExamples.TestDataContainer;

namespace WUBS.Cct.DataExamples.DataBuilders
{
    internal class LineItemBuilder<T>
        where T : StaticDataRow, new()
    {
        private int orderDetailId = 1;
        private int clientOrderId = 1;
        private int itemType = (int)ItemType.EftPayment;
        private DateTime? releaseDate = null;
        private int fundedBy = (int)PaymentFundedBy.Fx;
        private CurrencyDefn tradeCurrency = CurrencyDefn.AUD;
        private double tradeAmount = 148.81;
        private double settlementAmount = 100;
        private ItemRate itemRate = null;
        private int? quoteId = null;
        private short itemNumber = 1;
        private short isForeignAmountInSettlementCurrency = 0;
        private int? relatedOrderDetailId = null;
        private int? windowLength = null;

        public LineItemBuilder()
        {
            if (typeof(T) != typeof(RueschlinkDB.OrderDetail.OrderDetailRow) &&
                typeof(T) != typeof(RLHistoryDB.trrawdetail.trrawdetailRow))
                throw new InvalidOperationException(string.Format("Generic type T ({0}) is not supported by this builder", typeof(T).Name));
        }

        public T Build()
        {
            dynamic row = new T();

            row.OrderDetail_ID = orderDetailId;
            row.ItemNo = itemNumber;
            row.ClientOrder_ID = clientOrderId;
            row.ForeignAmount = tradeAmount;
            row.Extension = settlementAmount;
            row.ForeignAmountIsInSC = isForeignAmountInSettlementCurrency;
            row.ForeignAmt_NDec = 2;
            row.Currency_ID = tradeCurrency.ID;
            row.CurrencyCode = tradeCurrency.Code;
            row.ItemType_ID = itemType;
            row.Quote_ID = quoteId;
            row.ItemRate = itemRate != null ? (double?)itemRate.RateValue : null;
            row.ItemRateIsPer = itemRate != null ? (short?)itemRate.IsPer : null;
            row.ItemRate_NDec = itemRate != null ? (int?)itemRate.NDec : null;
            row.RateMultiplier = itemRate != null ? (int?)itemRate.RateMultiplier : null;
            row.RateMultiplier_Inv = itemRate != null ? (short?)itemRate.InvRateMultiplier : null;
            row.FundedBy = fundedBy;
            row.RelatedOrderDetail_ID = relatedOrderDetailId;
            row.WindowLength = windowLength;
            row.ReleaseDate = releaseDate;
            row.Beneficiary_ID = 1;

            return row;
        }

        public LineItemBuilder<T> OfType(ItemType lineItemType)
        {
            this.itemType = (int)lineItemType;
            return this;
        }

        public LineItemBuilder<T> ForOrderId(int clientOrderId)
        {
            this.clientOrderId = clientOrderId;
            return this;
        }

        public LineItemBuilder<T> WithReleaseDate(DateTime rd)
        {
            this.releaseDate = rd;
            return this;
        }

        public LineItemBuilder<T> FundedBy(int fundedBy)
        {
            this.fundedBy = fundedBy;
            return this;
        }

        public LineItemBuilder<T> WithTradeCurrency(CurrencyDefn tradeCur)
        {
            this.tradeCurrency = tradeCur;
            return this;
        }

        public LineItemBuilder<T> WithTradeAmount(decimal tradeAmount)
        {
            this.tradeAmount = (double)tradeAmount;
            return this;
        }

        public LineItemBuilder<T> WithSettlementAmount(decimal settlementAmount)
        {
            this.settlementAmount = (double)settlementAmount;
            return this;
        }

        public LineItemBuilder<T> WithRate(ItemRate rate)
        {
            this.itemRate = rate;
            return this;
        }

        public LineItemBuilder<T> IsQuotedWithId(int quoteId)
        {
            this.quoteId = quoteId;
            return this;
        }

        public LineItemBuilder<T> WithId(int detailId)
        {
            this.orderDetailId = detailId;
            return this;
        }

        public LineItemBuilder<T> WithItemNumber(short itemNumber)
        {
            this.itemNumber = itemNumber;
            return this;
        }

        public LineItemBuilder<T> HasContributingItem()
        {
            this.itemRate = null;
            return this;
        }

        public LineItemBuilder<T> WithForeignAmountInSettlementCurrency(bool isForeignAmountInSettleCur)
        {
            this.isForeignAmountInSettlementCurrency = Convert.ToInt16(isForeignAmountInSettleCur);
            return this;
        }
        
        public LineItemBuilder<T> WithWindowLength(int windowLength)
        {
            this.windowLength = windowLength;
            return this;
        }

        public LineItemBuilder<T> WithRelatedId(int relatedDetailId)
        {
            this.relatedOrderDetailId = relatedDetailId;
            return this;
        }

    }
}