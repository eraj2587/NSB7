using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WUBS.Cct.Treasury.Infrastructure.Persistence.DB;
using WUBS.Cct.Treasury.Infrastructure.Persistence.Providers;

namespace WUBS.Cct.Treasury.Infrastructure.Caches
{
    public class OrderTypeDescriptionCache : Cache<string, OrderTypeDescriptionCache>
    {
        protected override Dictionary<int, string> LoadCacheDictionary()
        {
            return GetCodeMapping();
        }

        public override string GetById(int id)
        {
            string returnValue;
            return !CacheDictionary.TryGetValue(id, out returnValue) ? "" : returnValue;
        }

        protected override string CacheName
        {
            get { return "Order Type Description"; }
        }

        protected override Dictionary<int, string> GetCodeMapping()
        {
            var connectionString = DatabaseConnectionStringProvider.Instance.GetDatabaseConnectionString(Database.RueschLink);
            var orderTypesDictionary = new Dictionary<int, string>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [OrderType_ID], [Description] FROM [dbo].[OrderType]";
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            orderTypesDictionary.Add(Convert.ToInt32(reader["OrderType_ID"]), Convert.ToString(reader["Description"]));
                        }
                    }
                }
            }
            return orderTypesDictionary;
        }
    }
}
