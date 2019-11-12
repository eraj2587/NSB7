using System;
using WUBS.Cct.DataExamples.TestDataContainer;

namespace WUBS.Cct.DataExamples.DataBuilders
{
    internal class OrderDetailValueDateBuilder<T>
        where T : StaticDataRow, new()
    {
        private int orderDetailId = 1;
        private DateTime requestedValueDate = DateTime.Now.Date;

        public OrderDetailValueDateBuilder()
        {
            if (typeof(T) != typeof(RueschlinkDB.OrderDetailValueDate.OrderDetailValueDateRow) &&
                typeof(T) != typeof(RLHistoryDB.TRRawDetailValueDate.TRRawDetailValueDateRow))
                throw new InvalidOperationException(string.Format("Generic type T ({0}) is not supported by this builder", typeof(T).Name));
        }

        public T Build()
        {
            dynamic row = new T();
            row.OrderDetail_ID = orderDetailId;
            row.RequestedValueDate = requestedValueDate;
            row.initdt = DateTime.Now;
            row.upddt = DateTime.Now;

            return row;
        }

        public OrderDetailValueDateBuilder<T> WithOrderDetailId(int detailId)
        {
            this.orderDetailId = detailId;
            return this;
        }

        public OrderDetailValueDateBuilder<T> WithRequestedValueDate(DateTime valueDate)
        {
            this.requestedValueDate = valueDate;
            return this;
        }}
}