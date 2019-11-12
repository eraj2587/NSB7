using System;
using WUBS.Cct.DataExamples.Enums;
using WUBS.Cct.DataExamples.TestDataContainer;

namespace WUBS.Cct.DataExamples.DataBuilders
{
    internal class CrossCurrencyBuilder
    {
        private CurrencyDefn baseCurrency = CurrencyDefn.EUR;
        private CurrencyDefn targetCurrency = CurrencyDefn.AUD;
        private short? isPerBase = null;
        private short? nDecIn = null;
        private short? nDecPer = null;

        public CrsDB.CrossCurrency.CrossCurrencyRow Build()
        {
            var row = new CrsDB.CrossCurrency.CrossCurrencyRow();

            row.BaseCurrency_ID = baseCurrency.ID;
            row.TargetCurrency_ID = targetCurrency.ID;
            row.IsPerBase = isPerBase;
            row.NDecIn = nDecIn;
            row.NDecPer = nDecPer;
            row.initdt = DateTime.Now;
            row.upddt = DateTime.Now;

            return row;
        }

        public CrossCurrencyBuilder WithBaseCurrency(CurrencyDefn baseCur)
        {
            this.baseCurrency = baseCur;
            return this;
        }

        public CrossCurrencyBuilder WithTargetCurrency(CurrencyDefn targetCur)
        {
            this.targetCurrency = targetCur;
            return this;
        }

        public CrossCurrencyBuilder IsPerBase(short isPerBase)
        {
            this.isPerBase = isPerBase;
            return this;
        }

        public CrossCurrencyBuilder NDecIn(short nDecIn)
        {
            this.nDecIn = nDecIn;
            return this;
        }

        public CrossCurrencyBuilder NDecPer(short nDecPer)
        {
            this.nDecPer = nDecPer;
            return this;
        }
    }
}
