using System;
using WUBS.Cct.DataExamples.Enums;
using WUBS.Cct.DataExamples.TestDataContainer;

namespace WUBS.Cct.DataExamples.DataBuilders
{
    internal class OrderHeaderBuilder<T>
        where T : StaticDataRow, new()
    {
        private int orderType = 1; //DEFAULT Nostro
        private short itemCount = 0;
        private int orderId = 1;
        private CurrencyDefn settlementCurrency = CurrencyDefn.EUR;
        private int clientId = 4;
        private int? staffId = null;
        private Application app = Application.GlobalPayPlus;
        private int userId = 1;
        private SettlementMethod settlementMethod = SettlementMethod.Wire;
        private int? relatedClientOrderId = null;
        private double? itemTotal = null;
        private DateTime? ordered = DateTime.Now;
        private string confirmationNumber;

        public OrderHeaderBuilder()
        {
            if (typeof(T) != typeof(RueschlinkDB.ClientOrder.ClientOrderRow) &&
                typeof(T) != typeof(RLHistoryDB.TRRawHeader.TRRawHeaderRow))
                throw new InvalidOperationException(string.Format("Generic type T ({0}) is not supported by this builder", typeof(T).Name));
        }

        public T Build()
        {
            dynamic row = new T();

            row.ClientOrder_ID = orderId;
            row.RelatedClientOrder_ID = relatedClientOrderId;
            row.Client_ID = clientId;
            row.OrderType_ID = orderType;
            row.ConfirmationNo = confirmationNumber ?? "ABCD" + row.ClientOrder_ID;
            row.RueschStaff_ID = staffId;
            row.Application_ID = (int?)app;
            row.ItemTotal = itemTotal; 
            row.Ordered = ordered;
            row.NumberItems = itemCount;
            row.Quote_ID = 0;
            row.SettlementCurrency_ID = settlementCurrency.ID;
            row.User_ID = userId;
            row.PaymentMethod_ID = (int?)settlementMethod;

            return row;
        }

        public OrderHeaderBuilder<T> OfType(OrderType orderType)
        {
            this.orderType = (int)orderType;
            return this;
        }

        public OrderHeaderBuilder<T> WithOrderId(int orderId)
        {
            this.orderId = orderId;
            return this;
        }

        public OrderHeaderBuilder<T> WithItemCount(short itemCount)
        {
            this.itemCount = itemCount;
            return this;
        }

        public OrderHeaderBuilder<T> SettlementCurrency(CurrencyDefn cur)
        {
            this.settlementCurrency = cur;
            return this;
        }

        public OrderHeaderBuilder<T> ForClient(int clientId)
        {
            this.clientId = clientId;

            return this;
        }

        public OrderHeaderBuilder<T> ByStaff(int reuschStaffId)
        {
            this.staffId = reuschStaffId;
            return this;
        }

        public OrderHeaderBuilder<T> InApp(Application application)
        {
            this.app = application;
            return this;
        }

        public OrderHeaderBuilder<T> WithUserId(int userId)
        {
            this.userId = userId;
            return this;
        }

        public OrderHeaderBuilder<T> WithSettlementMethodId(SettlementMethod settlementMethod)
        {
            this.settlementMethod = settlementMethod;
            return this;
        }

        public OrderHeaderBuilder<T> WithRelatedClientOrderId(int relatedClientOrderId)
        {
            this.relatedClientOrderId = relatedClientOrderId;
            return this;
        }

        public OrderHeaderBuilder<T> Ordered(DateTime ordered)
        {
            this.ordered = ordered;
            return this;
        }

        public OrderHeaderBuilder<T> WithConfirmationNumber(string confirmationNumber)
        {
            this.confirmationNumber = confirmationNumber;
            return this;
        }
    }
}