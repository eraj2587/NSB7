using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using WUBS.Cct.Treasury.DomainModel.Entities;
using WUBS.Cct.Treasury.DomainModel.Enums;
using WUBS.Cct.Treasury.DomainModel.Financial;
using WUBS.Cct.Treasury.Exceptions;
using WUBS.Cct.Treasury.Infrastructure.Caches;
using WUBS.Cct.Treasury.Infrastructure.Persistence.DB;
using WUBS.Cct.Treasury.Infrastructure.Persistence.Providers;
using WUBS.Cct.Treasury.Infrastructure.Utilities;
using WUBS.Cct.Treasury.Mappers.Factories;
using WUBS.Cct.Treasury.Mappers.Interfaces;
using WUBS.Cct.Treasury.Mappers.Visitors;

namespace WUBS.Cct.Treasury.Mappers
{
    public class LineItemMapper : ILineItemMapper
    {
        private readonly List<LineItemVisitor> itemVisitors = new List<LineItemVisitor>();
        private readonly ILineItemToContractMapper lineItemToContractMapper;
        private readonly IQuoteMapper quoteMapper;
        private readonly IFundingSourceFactory fundingSourceFactory;


        private readonly HashSet<OrderType> singleSidedOrders = new HashSet<OrderType>
        {
            OrderType.FtSweep,
            OrderType.FtSweepReversal
        };

        private string CMD_GET_LINEITEMS_BASE_FORMAT = @"
SELECT 		
	O.Ordered,
	O.OrderType_ID,
	O.SettlementCurrency_ID,
	LineItem.OrderDetail_ID,
	LineItem.Currency_ID,
	LineItem.ItemType_ID,
	COALESCE(NULLIF(CI.Quote_ID, 0), NULLIF(LineItem.Quote_ID, 0), ODA.Quote_ID) AS Quote_ID,
			  
	COALESCE(LineItem.ItemRate, CI.Rate) AS ItemRate,
	COALESCE(LineItem.ItemRateIsPer, CI.ItemRateIsPer) AS ItemRateIsPer,
	COALESCE(LineItem.ItemRate_NDec, CI.ItemRate_NDec) AS ItemRate_NDec,
	COALESCE(LineItem.RateMultiplier, CI.RateMultiplier) AS RateMultiplier,
	COALESCE(LineItem.RateMultiplier_Inv, CI.RateMultiplier_Inv) AS RateMultiplier_Inv,
			  
	COALESCE(CI.Amount, LineItem.ForeignAmount) AS ForeignAmount,
	LineItem.ForeignAmountIsInSC,
	LineItem.ForeignAmt_NDec,
	COALESCE(CI.ItemNo, LineItem.ItemNo, 0) AS ItemNo,
	COALESCE(CI.Extension, LineItem.Extension) AS Extension,
	COALESCE(CI.FundedBy, LineItem.FundedBy) AS FundedBy,
	LineItem.RelatedOrderDetail_ID,
	LineItem.ItemType_ID,
	LineItem.WindowLength,		
	LineItem.ReleaseDate,
	LineItem.DepositDueDate,
	LineItem.OptionContractId,
	LineItem.OptionLeg,
	CI.PreDelivery,
	CI.RelatedOrderDetail_ID AS ContributingItemRelatedOrderDetail_ID,
		
	ValueDate.RequestedValueDate,
	LineItem.Beneficiary_ID

FROM {3} AS LineItem WITH (NOLOCK) 
	INNER JOIN {2} AS O WITH (NOLOCK) ON O.ClientOrder_ID = LineItem.ClientOrder_ID
    {0}
	LEFT OUTER JOIN {4} AS CI WITH (NOLOCK) ON CI.OrderDetail_ID = LineItem.OrderDetail_ID
	LEFT OUTER JOIN {5} AS ValueDate WITH (NOLOCK) ON ValueDate.OrderDetail_ID = LineItem.OrderDetail_ID
	LEFT OUTER JOIN {6} AS ODA WITH (NOLOCK) ON CI.RelatedOrderDetail_ID = ODA.OrderDetail_ID
		
WHERE {1}		

ORDER BY LineItem.OrderDetail_ID
";

        private string BY_ORDER_JOIN = "";
        private string BY_ORDER_CONDITION = @"
LineItem.ClientOrder_ID = @orderID
AND LineItem.ItemType_ID NOT IN (109, 110, 101)	
AND (O.SettlementCurrency_ID <> LineItem.Currency_ID OR @IncludeSameCurrency = 1)";

        private string BY_ITEM_JOIN = "";
        private string BY_ITEM_CONDITION = @"LineItem.OrderDetail_ID = @itemID";

        private string BY_ITEMS_JOIN = "INNER JOIN @itemIds AS I ON LineItem.OrderDetail_ID = I.ID";
        private string BY_ITEMS_CONDITION = "LineItem.ItemType_ID NOT IN (109, 110, 101)";

        private string DAILY_ORDER_TABLE_NAME = "dbo.ClientOrder";
        private string DAILY_LINEITEM_TABLE_NAME = "dbo.OrderDetail";
        private string DAILY_CONTRIB_TABLE_NAME = "dbo.ContributingItem";
        private string DAILY_VALUEDATE_TABLE_NAME = "dbo.OrderDetailValueDate";
        private string DAILY_AGINGITEM_TABLE_NAME = "dbo.OrderDetailAging";

        private string HISTORY_ORDER_TABLE_NAME = "dbo.TRRawHeader";
        private string HISTORY_LINEITEM_TABLE_NAME = "dbo.TRRawDetail";
        private string HISTORY_CONTRIB_TABLE_NAME = "dbo.ContributingItemHistory";
        private string HISTORY_VALUEDATE_TABLE_NAME = "dbo.TRRawDetailValueDate";
        private string HISTORY_AGINGITEM_TABLE_NAME = "dbo.TRRawDetail";

        public LineItemMapper(IQuoteMapper quoteMapper, ILineItemToContractMapper lineItemToContractMapper, IFundingSourceFactory fundingSourceFactory)
        {
            this.quoteMapper = quoteMapper;
            this.lineItemToContractMapper = lineItemToContractMapper;
            this.fundingSourceFactory = fundingSourceFactory;

            RegisterVisitors();
        }

        private void RegisterVisitors()
        {
            itemVisitors.Add(new LineItemFundingSourceVisitor(fundingSourceFactory));
            itemVisitors.Add(new NonQuotedLineItemVisitor(this, quoteMapper));
        }

        private string RueschlinkConnectionString
        {
            get { return DatabaseConnectionStringProvider.Instance.GetDatabaseConnectionString(Database.RueschLink); }
        }

        private string HistoryConnectionString
        {
            get { return DatabaseConnectionStringProvider.Instance.GetDatabaseConnectionString(Database.History); }
        }

        public IList<LineItem> GetLineItemsByOrder(Order order)
        {
            var lineItems = new List<LineItem>();

            lineItems.AddRange(GetLineItemsByOrder(order, true));

            if (lineItems.Count == 0)
                lineItems.AddRange(GetLineItemsByOrder(order, false));

            lineItems.ForEach(li => li.ContractId = lineItemToContractMapper.GetContractId(li.Id));

            itemVisitors.ForEach(v => lineItems.ForEach(v.Visit));
            return lineItems;
        }

        public LineItem GetLineItemByItemId(int itemId)
        {
            var lineItem = GetLineItemByItemId(itemId, true)
                ?? GetLineItemByItemId(itemId, false);

            if (lineItem == null)
                throw new InvalidForwardContractIdException(itemId);

            lineItem.ContractId = lineItemToContractMapper.GetContractId(itemId);

            itemVisitors.ForEach(v => v.Visit(lineItem));
            return lineItem;
        }

        public IList<LineItem> GetLineItemsByItemIds(IList<int> itemIds)
        {
            var lineItems = GetLineItemsByItemIds(itemIds, false);

            if (!lineItems.Any())
            {
                lineItems = GetLineItemsByItemIds(itemIds, true);
            }

            lineItems.ForEach(li => li.ContractId = lineItemToContractMapper.GetContractId(li.Id));

            itemVisitors.ForEach(v => lineItems.ForEach(v.Visit));
            return lineItems;
        }

        public int GetQuoteIdByRelatedItemId(int relatedLineItemId)
        {
            return GetOriginalQuoteId(relatedLineItemId);
        }


        internal List<LineItem> GetLineItemsByOrder(Order order, bool fromDailyTables)
        {
            var lineItems = new List<LineItem>();

            var cmd = (fromDailyTables)
                ? BuildDailyCommand(CMD_GET_LINEITEMS_BASE_FORMAT, BY_ORDER_JOIN, BY_ORDER_CONDITION)
                : BuildHistoryCommand(CMD_GET_LINEITEMS_BASE_FORMAT, BY_ORDER_JOIN, BY_ORDER_CONDITION);

            using (var connection = new SqlConnection((fromDailyTables) ? RueschlinkConnectionString : HistoryConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(cmd, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add(new SqlParameter("orderID", order.Id));
                    command.Parameters.Add(new SqlParameter("includeSameCurrency", true));

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lineItems.Add(GetLineItemFromDataReader(reader));
                        }
                    }
                }
            }
            return lineItems;
        }

        internal LineItem GetLineItemByItemId(int itemId, bool fromDailyTables)
        {
            var cmd = (fromDailyTables)
                ? BuildDailyCommand(CMD_GET_LINEITEMS_BASE_FORMAT, BY_ITEM_JOIN, BY_ITEM_CONDITION)
                : BuildHistoryCommand(CMD_GET_LINEITEMS_BASE_FORMAT, BY_ITEM_JOIN, BY_ITEM_CONDITION);

            using (var connection = new SqlConnection((fromDailyTables) ? RueschlinkConnectionString : HistoryConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(cmd, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add(new SqlParameter("itemId", itemId));

                    using (var reader = command.ExecuteReader())
                    {
                        return reader.Read() ? GetLineItemFromDataReader(reader) : null;
                    }
                }
            }
        }

        internal IList<LineItem> GetLineItemsByItemIds(IList<int> itemIds, bool fromDailyTables)
        {
            var cmd = (fromDailyTables)
                ? BuildDailyCommand(CMD_GET_LINEITEMS_BASE_FORMAT, BY_ITEMS_JOIN, BY_ITEMS_CONDITION)
                : BuildHistoryCommand(CMD_GET_LINEITEMS_BASE_FORMAT, BY_ITEMS_JOIN, BY_ITEMS_CONDITION);

            var items = new List<LineItem>();
            using (var connection = new SqlConnection((fromDailyTables) ? RueschlinkConnectionString : HistoryConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(cmd, connection))
                {
                    command.CommandType = CommandType.Text;
                    var lineItemIdsParam = command.Parameters.AddWithValue("itemIds", ToDataTable(itemIds));
                    lineItemIdsParam.SqlDbType = SqlDbType.Structured;
                    lineItemIdsParam.TypeName = "dbo.TblId";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            items.Add(GetLineItemFromDataReader(reader));
                        }
                    }
                }
            }
            return items;
        }

        private LineItem GetLineItemFromDataReader(SqlDataReader reader)
        {
            var lineItem = CreateLineItem(reader);

            Currency settlementCurrency = CurrencyCache.Instance.GetById(Convert.ToInt32(reader["SettlementCurrency_ID"]));
            Currency tradeCurrency = CurrencyCache.Instance.GetById(Convert.ToInt32(reader["Currency_ID"]));

            lineItem.Id = Convert.ToInt32(reader["OrderDetail_ID"]);
            lineItem.Number = Convert.ToInt32(reader["ItemNo"]);
            lineItem.SettlementMoney = new Money(settlementCurrency,
                Convert.ToDecimal(DbReadingUtility.NullableDecimal(reader["Extension"])));
            lineItem.IsAmountInSettlementCurrency = Convert.ToBoolean(reader["ForeignAmountIsInSC"]);
            lineItem.TradeMoney = new Money(tradeCurrency,
                Convert.ToDecimal(DbReadingUtility.NullableDecimal(reader["ForeignAmount"])));
            lineItem.TradeAmountNDec = Convert.ToInt32(DbReadingUtility.NullableInt(reader["ForeignAmt_NDec"]));
            lineItem.ItemRateValue = Convert.ToDecimal(DbReadingUtility.NullableDecimal(reader["ItemRate"]));
            lineItem.LineItemFundingMethod = LineItemFundingMethodCache.Instance.GetById(Convert.ToInt32(reader["FundedBy"]));
            lineItem.QuoteId = DbReadingUtility.NullableInt(reader["Quote_ID"]);
            lineItem.ContributingItemId = DbReadingUtility.NullableInt(reader["ContributingItemRelatedOrderDetail_ID"]);

            if (lineItem is SingleSidedLineItem)
            {
                lineItem.ValueDate = ((SingleSidedLineItem)lineItem).DepositDueDate;
            }
            else
            {
                lineItem.ValueDate = DbReadingUtility.NullableDateTime(reader["RequestedValueDate"], null);
            }

            lineItem.WindowLength = DbReadingUtility.NullableInt(reader["WindowLength"]);
            lineItem.WindowStartDate = DbReadingUtility.NullableDateTime(reader["ReleaseDate"], null);
            lineItem.RelatedLineItemId = DbReadingUtility.NullableInt(reader["RelatedOrderDetail_ID"]);
            lineItem.OptionContractId = DbReadingUtility.NullableString(reader["OptionContractId"]);
            lineItem.OptionLeg = DbReadingUtility.NullableInt(reader["OptionLeg"]);
            lineItem.LineItemType = ItemTypeCache.Instance.GetById(Convert.ToInt32(reader["ItemType_ID"]));

            return lineItem;
        }

        private LineItem CreateLineItem(SqlDataReader reader)
        {
            var orderType = OrderTypeCache.Instance.GetById(Convert.ToInt32(reader["OrderType_ID"]));
            if (singleSidedOrders.Contains(orderType))
                return new SingleSidedLineItem
                {
                    BeneficiaryId = DbReadingUtility.NullableInt(reader["Beneficiary_ID"]),
                    DepositDueDate = DbReadingUtility.NullableDateTime(reader["DepositDueDate"])
                };
            return new LineItem();
        }



        private int GetOriginalQuoteId(int relatedLineItemId)
        {
            RelatedLineItemQuote result;
            var depth = 0;
            do
            {
                result = GetRelatedLineItemQuoteId(relatedLineItemId);
                if (result.RelatedItemId != 0) relatedLineItemId = result.RelatedItemId;

            } while (result.QuoteId == 0 && result.RelatedItemId != 0 && depth++ < 1000);

            return result.QuoteId == 0 ? GetLockinItemQuoteIdFromDisbursal(result.ClientOrderId) : result.QuoteId;
        }

        private RelatedLineItemQuote GetRelatedLineItemQuoteId(int relatedLineItemId)
        {
#if DEBUG
            Console.WriteLine("  Read historical quoteId for lineItemId {0}", relatedLineItemId);
#endif
            var result = new RelatedLineItemQuote { QuoteId = 0, RelatedItemId = 0, ClientOrderId = 0 };

            using (var connection = new SqlConnection(HistoryConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText =
                        string.Format(
                            "SELECT Quote_ID, RelatedOrderDetail_ID, ClientOrder_ID FROM dbo.TRRawDetail WHERE OrderDetail_ID = {0} AND FundedBy = 80",
                            relatedLineItemId);
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.QuoteId = DbReadingUtility.NullableInt(reader["Quote_ID"]);
                            result.RelatedItemId = DbReadingUtility.NullableInt(reader["RelatedOrderDetail_ID"]);
                            result.ClientOrderId = DbReadingUtility.NullableInt(reader["ClientOrder_ID"]);
                        }
                    }
                }
            }

            if (result.QuoteId != 0 || result.RelatedItemId != 0) return result;

            using (var connection = new SqlConnection(RueschlinkConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText =
                        string.Format(
                            "SELECT Quote_ID, RelatedOrderDetail_ID, ClientOrder_ID FROM dbo.OrderDetail WHERE OrderDetail_ID = {0} AND FundedBy = 80",
                            relatedLineItemId);
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.QuoteId = DbReadingUtility.NullableInt(reader["Quote_ID"]);
                            result.RelatedItemId = DbReadingUtility.NullableInt(reader["RelatedOrderDetail_ID"]);
                            result.ClientOrderId = DbReadingUtility.NullableInt(reader["ClientOrder_ID"]);
                        }
                    }
                }
            }
            return result;
        }

        private int GetLockinItemQuoteIdFromDisbursal(int clientOrderId)
        {
            var lockinOrderId = GetLockinOrderIdByDisbursalOrderId(clientOrderId);

            var quoteId = GetLockinItemQuoteIdFromDisbursalByDB(lockinOrderId, HistoryConnectionString);

            if (quoteId == 0)
                return GetLockinItemQuoteIdFromDisbursalByDB(lockinOrderId, RueschlinkConnectionString);

            return quoteId;
        }

        private int GetLockinItemQuoteIdFromDisbursalByDB(int lockinOrderId, string connectionString)
        {
            var quoteId = 0;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = string.Format(GetLockinItemQuoteIdQueryString(connectionString), lockinOrderId);
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            quoteId = DbReadingUtility.NullableInt(reader["Quote_ID"]);
                        }
                    }
                }
            }
            return quoteId;
        }

        private int GetLockinOrderIdByDisbursalOrderId(int disbursalOrderId)
        {
            var lockinOrderId = GetLockinOrderIdByDisbursalOrderId(disbursalOrderId, HistoryConnectionString);

            if (lockinOrderId == 0)
                return GetLockinOrderIdByDisbursalOrderId(disbursalOrderId, RueschlinkConnectionString);

            return lockinOrderId;
        }

        private int GetLockinOrderIdByDisbursalOrderId(int disbursalOrderId, string connectionString)
        {
            var lockinOrderId = 0;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = string.Format(GetLockinOrderIdByDisbursalOrderIdQueryString(connectionString), disbursalOrderId);
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lockinOrderId = DbReadingUtility.NullableInt(reader["RelatedClientOrder_Id"]);
                        }
                    }
                }
            }
            return lockinOrderId;
        }

        private string BuildHistoryCommand(string cmdFormat, string byOrderJoin, string byOrderCondition)
        {
            return string.Format(cmdFormat, byOrderJoin, byOrderCondition, HISTORY_ORDER_TABLE_NAME, HISTORY_LINEITEM_TABLE_NAME, HISTORY_CONTRIB_TABLE_NAME, HISTORY_VALUEDATE_TABLE_NAME, HISTORY_AGINGITEM_TABLE_NAME);
        }

        private string BuildDailyCommand(string cmdFormat, string byOrderJoin, string byOrderCondition)
        {
            return string.Format(cmdFormat, byOrderJoin, byOrderCondition, DAILY_ORDER_TABLE_NAME, DAILY_LINEITEM_TABLE_NAME, DAILY_CONTRIB_TABLE_NAME, DAILY_VALUEDATE_TABLE_NAME, DAILY_AGINGITEM_TABLE_NAME);
        }

        private string GetLockinItemQuoteIdQueryString(string connectionString)
        {
            return (connectionString == HistoryConnectionString)
                ? @"SELECT Quote_ID FROM dbo.trrawdetail WHERE ClientOrder_ID = {0} AND ItemType_ID = 55"
                : @"SELECT Quote_ID FROM dbo.OrderDetail WHERE ClientOrder_ID = {0} AND ItemType_ID = 55";
        }

        private string GetLockinOrderIdByDisbursalOrderIdQueryString(string connectionString)
        {
            return (connectionString == HistoryConnectionString)
                ? @"SELECT RelatedClientOrder_Id FROM dbo.trrawheader WHERE ClientOrder_ID = {0}"
                : @"SELECT RelatedClientOrder_Id FROM dbo.ClientOrder WHERE ClientOrder_ID = {0}";
        }

        private class RelatedLineItemQuote
        {
            public int RelatedItemId { get; set; }
            public int QuoteId { get; set; }
            public int ClientOrderId { get; set; }
        }




        private static DataTable ToDataTable(IEnumerable<int> ids)
        {
            var table = new DataTable();
            table.Columns.Add("ID", typeof(int));

            foreach (int id in ids)
                table.Rows.Add(id);

            return table;
        }
    }
}