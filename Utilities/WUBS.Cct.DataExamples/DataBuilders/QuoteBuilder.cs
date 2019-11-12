using System;
using WUBS.Cct.DataExamples.Enums;
using WUBS.Cct.DataExamples.TestDataContainer;

namespace WUBS.Cct.DataExamples.DataBuilders
{
    public class QuoteBuilder<T>
        where T : StaticDataRow, new()
    {
        private int quote_ID = 1;
        private CurrencyDefn settleCur = CurrencyDefn.EUR;
        private CurrencyDefn tradeCur = CurrencyDefn.AUD;
        private decimal customerRate = 1.0m;
        private int customerRateIsPer = 1;
        private decimal costRate = 1;
        private int costRateIsPer = 1;
        private decimal reutersRate = 1;
        private int reutersRateIsPer = 1;
        private decimal settlementRate = 1;
        private decimal reportingRate = 1;
        private decimal? forwardPoints = null;
        private int forwardPointsIsPer = 1;
        private CurrencyDefn reportingCur = CurrencyDefn.USD;
        private decimal spread = 0;
        private double costPriceMarkup;
        private decimal childEffectiveMultiplier = 1;
        private short? rateMultiplier = 1;

        public QuoteBuilder()
        {
            if (typeof(T) != typeof(CrsDB.Quote.QuoteRow) &&
                typeof(T) != typeof(CrsDB.QuoteHistory.QuoteHistoryRow) &&
                typeof(T) != typeof(CrsDB.QuoteHistory_Archive.QuoteHistory_ArchiveRow))
                throw new InvalidOperationException(string.Format("Generic type T ({0}) is not supported by this builder", typeof(T).Name));
        }

        public T Build()
        {
            dynamic row = new T();

            row.Quote_ID = quote_ID;
            row.Rate = (double)customerRate;
            row.RateIsPer = (short)customerRateIsPer;
            row.SpotRate = (double)costRate;
            row.SpotRateIsPer = (short)costRateIsPer;
            row.SettlementRate = (double)settlementRate;
            row.ReportingRate = (double)reportingRate;
            row.ForwardPoints = (double?)forwardPoints;
            row.ForwardPointsIsPer = (short)forwardPointsIsPer;
            row.SettlementCurrency_ID = settleCur.ID;
            row.Currency_ID = tradeCur.ID;
            row.ReportingCurrency_ID = reportingCur.ID;
            row.ForwardSpread = 0;
            row.ChildEffectiveMultiplier = (double)childEffectiveMultiplier;
            row.ParentEffectiveMultiplier = 1;
            row.DefaultSpread = 1;
            row.ReutersSpotRate = (double)reutersRate;
            row.ReutersSpotRateIsPer = (short?)reutersRateIsPer;
            row.CostPriceMarkup = costPriceMarkup;
            row.RateMultiplier = rateMultiplier;
            row.SpotRateIsCostRate = false;
            row.Spread = (double)spread;

            return row;
        }


        public QuoteBuilder<T> WithCustomerRate(decimal rate, int isPer)
        {
            this.customerRate = rate;
            this.customerRateIsPer = isPer;

            return this;
        }

        public QuoteBuilder<T> WithCostRate(decimal rate, int isPer)
        {
            this.costRate = rate;
            this.costRateIsPer = isPer;

            return this;
        }

        public QuoteBuilder<T> WithReutersRate(decimal rate, int isPer)
        {
            this.reutersRate = rate;
            this.reutersRateIsPer = isPer;

            return this;
        }

        public QuoteBuilder<T> WithSettlementRate(decimal rate)
        {
            this.settlementRate = rate;

            return this;
        }

        public QuoteBuilder<T> WithReportingRate(decimal rate)
        {
            this.reportingRate = rate;

            return this;
        }

        public QuoteBuilder<T> WithForwardPoints(decimal points, int isPer)
        {
            this.forwardPoints = points;
            this.forwardPointsIsPer = isPer;

            return this;
        }

        public QuoteBuilder<T> WithSettlementCurrency(CurrencyDefn cur)
        {
            settleCur = cur;

            return this;
        }

        public QuoteBuilder<T> WithTradeCurrency(CurrencyDefn cur)
        {
            tradeCur = cur;

            return this;
        }

        public QuoteBuilder<T> WithReportingCurrency(CurrencyDefn cur)
        {
            reportingCur = cur;

            return this;
        }

        public QuoteBuilder<T> WithSpread(decimal spread)
        {
            this.spread = spread;

            return this;
        }

        public QuoteBuilder<T> WithCostMarkup(double markup)
        {
            this.costPriceMarkup = markup;

            return this;
        }

        public QuoteBuilder<T> WithChildEffectiveMultiplier(decimal mult)
        {
            this.childEffectiveMultiplier = mult;

            return this;
        }

        public QuoteBuilder<T> WithQuoteId(int id)
        {
            this.quote_ID = id;
            return this;
        }

        public QuoteBuilder<T> WithRateMultiplier(short rateMultiplier)
        {
            this.rateMultiplier = rateMultiplier;
            return this;
        }
    }
}