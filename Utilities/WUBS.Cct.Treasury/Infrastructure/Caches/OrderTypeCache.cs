using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using WUBS.Cct.Treasury.DomainModel.Enums;
using WUBS.Cct.Treasury.DomainModel.Enums.Utility;
using WUBS.Cct.Treasury.Infrastructure.Persistence.DB;
using WUBS.Cct.Treasury.Infrastructure.Persistence.Providers;

namespace WUBS.Cct.Treasury.Infrastructure.Caches
{
    public class OrderTypeCache : Cache<OrderType, OrderTypeCache>
    {
        protected override Dictionary<int, string> GetCodeMapping()
        {
            var connectionString = DatabaseConnectionStringProvider.Instance.GetDatabaseConnectionString(Database.RueschLink);
            var orderTypesDictionary = new Dictionary<int, string>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [OrderType_ID], [Code] FROM [dbo].[OrderType]";
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            orderTypesDictionary.Add(Convert.ToInt32(reader["OrderType_ID"]), Convert.ToString(reader["Code"]));
                        }
                    }
                }
            }
            return orderTypesDictionary;
        }

        public override OrderType GetById(int id)
        {
            OrderType returnValue;
            return !CacheDictionary.TryGetValue(id, out returnValue) ? OrderType.Undefined : returnValue;
        }

        public int GetIdByOrderType(OrderType orderType)
        {

            return CacheDictionary.First(
                pair => pair.Value == orderType).Key;
        }

        protected override string CacheName
        {
            get { return "Order Type"; }
        }
    }
}
