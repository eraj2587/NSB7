using System;
using System.Data;
using System.Data.SqlClient;
using WUBS.Cct.Treasury.DomainModel.Entities;
using WUBS.Cct.Treasury.Infrastructure.Caches;
using WUBS.Cct.Treasury.Infrastructure.Persistence.DB;
using WUBS.Cct.Treasury.Infrastructure.Persistence.Providers;
using WUBS.Cct.Treasury.Infrastructure.Utilities;
using WUBS.Cct.Treasury.Mappers.Interfaces;

namespace WUBS.Cct.Treasury.Mappers
{
    internal class OrderMapper : IOrderMapper
    {
        private string CMD_GET_ORDER_FORMAT = @"
SELECT 
		O.ClientOrder_ID,
		O.RelatedClientOrder_ID,
		O.Client_ID,
		O.SettlementCurrency_ID,
		O.ConfirmationNo,
		O.Ordered,
		O.RueschStaff_ID,
		O.Application_ID,
		O.OrderType_ID
";

        private string BY_ORDER_FORMAT = @"
    FROM {0} AS O WITH (NOLOCK)
	WHERE O.ClientOrder_ID = @orderID
";
        private string BY_LI_FORMAT = @"
    FROM {0} AS O WITH (NOLOCK) 
	INNER JOIN {1} AS D WITH (NOLOCK) ON O.ClientOrder_ID = D.ClientOrder_ID

	WHERE D.OrderDetail_ID = @lineItemId
";

        private string DAILY_ORDER_TABLE_NAME = "dbo.ClientOrder";
        private string DAILY_LI_TABLE_NAME = "dbo.OrderDetail";

        private string HISTORY_ORDER_TABLE_NAME = "dbo.TRRawHeader";
        private string HISTORY_LI_TABLE_NAME = "dbo.TRRawDetail";

        private string RueschlinkConnectionString
        {
            get { return DatabaseConnectionStringProvider.Instance.GetDatabaseConnectionString(Database.RueschLink); }
        }

        private string HistoryConnectionString
        {
            get { return DatabaseConnectionStringProvider.Instance.GetDatabaseConnectionString(Database.History); }
        }

        private string VMaRSConnectionString
        {
            get { return DatabaseConnectionStringProvider.Instance.GetDatabaseConnectionString(Database.Vmars); }
        }

        //[LogOrder]
        public Order GetOrder(int orderId)
        {
#if DEBUG
            Console.WriteLine(" Read OrderId {0}", orderId);
#endif
            var order = GetOrder(orderId, true) ?? GetOrder(orderId, false);

            if (order == null)
                throw new ArgumentException(string.Format("invalid order id {0}", orderId), "orderId");

            return order;
        }

        internal Order GetOrder(int orderId, bool fromDailyTables)
        {
            var cmd = (fromDailyTables)
                ? BuildDailyCommand(CMD_GET_ORDER_FORMAT, BY_ORDER_FORMAT)
                : BuildHistoryCommand(CMD_GET_ORDER_FORMAT, BY_ORDER_FORMAT);

            Order order;
            var isRepurchaseOrReissue = IsRepurchaseOrReissueOrder(orderId);

            using (var connection = new SqlConnection((fromDailyTables) ? RueschlinkConnectionString : HistoryConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(cmd, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add(new SqlParameter("orderID", orderId));

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                            order = GetOrderFromDataReader(isRepurchaseOrReissue, reader);
                        else
                            return null;
                    }
                }
            }

            order.ReinstateFundsToForward = ReinstateFundsToForward(orderId);

            return order;
        }

        private string BuildHistoryCommand(string selectClause, string restFormat)
        {
            var cmdFormat = string.Format("{0} {1}", selectClause, restFormat);
            return string.Format(cmdFormat, HISTORY_ORDER_TABLE_NAME, HISTORY_LI_TABLE_NAME);
        }

        private string BuildDailyCommand(string selectClause, string restFormat)
        {
            var cmdFormat = string.Format("{0} {1}", selectClause, restFormat);
            return string.Format(cmdFormat, DAILY_ORDER_TABLE_NAME, DAILY_LI_TABLE_NAME);
        }

        public Order GetOrderByLineItemId(int lineItemId)
        {
            var order = GetOrderByLineItemId(lineItemId, false) ??
                        GetOrderByLineItemId(lineItemId, true);

            if (order == null)
                throw new ArgumentException(string.Format("invalid lineItemId {0}", lineItemId), "lineItemId");

            return order;
        }

        private Order GetOrderByLineItemId(int lineItemId, bool fromDailyTables)
        {
            Order order;

            var cmd = (fromDailyTables)
                ? BuildDailyCommand(CMD_GET_ORDER_FORMAT, BY_LI_FORMAT)
                : BuildHistoryCommand(CMD_GET_ORDER_FORMAT, BY_LI_FORMAT);

            using (var connection = new SqlConnection((fromDailyTables) ? RueschlinkConnectionString : HistoryConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(cmd, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add(new SqlParameter("lineItemId", lineItemId));

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                            order = GetOrderFromDataReader(false, reader);
                        else
                            return null;
                    }
                }
            }

            return order;
        }

        private Order GetOrderFromDataReader(bool isRepurchaseOrReissue, SqlDataReader reader)
        {
            return PopulateOrder(reader,
                OrderFactory.CreateOrderByOrderType(
                    OrderTypeCache.Instance.GetById(Convert.ToInt32(reader["OrderType_ID"])),
                    isRepurchaseOrReissue));
        }

        private static Order PopulateOrder(SqlDataReader reader, Order order)
        {
            order.Id = Convert.ToInt32(reader["ClientOrder_ID"]);
            order.RelatedOrderId = DbReadingUtility.NullableInt(reader["RelatedClientOrder_ID"], null);
            order.ClientId = Convert.ToInt32(reader["Client_ID"]);
            order.SettlementCurrency = CurrencyCache.Instance.GetById(Convert.ToInt32(reader["SettlementCurrency_ID"]));
            order.ConfirmationNumber = DbReadingUtility.NullableString(reader["ConfirmationNo"]).Trim();
            order.OrderedAt = DbReadingUtility.NullableDateTime(reader["Ordered"]);
            order.RueschStaffId = DbReadingUtility.NullableInt(reader["RueschStaff_ID"]);
            order.ApplicationId = DbReadingUtility.NullableInt(reader["Application_ID"]);
            order.OrderTypeDescription = OrderTypeDescriptionCache.Instance.GetById(Convert.ToInt32(reader["OrderType_ID"]));
            return order;
        }

        public int GetRepurchaseOrderIdFromReissueOrderId(int reissueOrderId)
        {
            using (var connection = new SqlConnection(VMaRSConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT MatchingClientOrder_ID, PreviousClientOrder_ID FROM dbo.RSRepurchase WITH (NOLOCK) WHERE ClientOrder_ID = @reissueOrderId ";
                    command.Parameters.Add(new SqlParameter("@reissueOrderId", reissueOrderId));
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var matchingOrderId = DbReadingUtility.NullableInt(reader["MatchingClientOrder_ID"]);
                            var previousOrderId = DbReadingUtility.NullableInt(reader["PreviousClientOrder_ID"]);

                            return matchingOrderId > 0 ? matchingOrderId : previousOrderId;
                        }
                        return 0;
                    }                                       
                }
            }
        }

        internal bool IsRepurchaseOrReissueOrder(int orderId)
        {
            var cmd = "SELECT 1 FROM dbo.RSRepurchase WITH (NOLOCK) WHERE ClientOrder_ID = @ClientOrder_ID";

            using (var connection = new SqlConnection(VMaRSConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(cmd, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add(new SqlParameter("ClientOrder_ID", orderId));

                    return Convert.ToBoolean(command.ExecuteScalar());
                }
            }
        }

        internal bool ReinstateFundsToForward(int orderId)
        {
            var cmd = "SELECT ISNULL(IsReinstateFundsToForward, 0) FROM dbo.RSBuilder WITH (NOLOCK) WHERE ClientOrder_ID = @ClientOrder_ID";
            using (var connection = new SqlConnection(VMaRSConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(cmd, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add(new SqlParameter("ClientOrder_ID", orderId));

                    return Convert.ToBoolean(command.ExecuteScalar());
                }
            }
        }
    }
}