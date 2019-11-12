using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WUBS.Cct.Treasury.DomainModel.Enums;
using WUBS.Cct.Treasury.Infrastructure.Persistence.DB;
using WUBS.Cct.Treasury.Infrastructure.Persistence.Providers;

namespace WUBS.Cct.Treasury.Infrastructure.Caches
{
    public class ItemTypeCache : Cache<ItemType, ItemTypeCache>
    {
        protected override Dictionary<int, string> GetCodeMapping()
        {
            var connectionString = DatabaseConnectionStringProvider.Instance.GetDatabaseConnectionString(Database.RueschLink);
            var itemTypes = new Dictionary<int, string>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT ItemType_ID, Code FROM dbo.ItemType";
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            itemTypes.Add(Convert.ToInt32(reader["ItemType_ID"]), Convert.ToString(reader["Code"]));
                        }
                    }
                }
            }
            return itemTypes;
        }

        protected override string CacheName
        {
            get { return "Item Type"; }
        }

        public override ItemType GetById(int id)
        {
            ItemType returnValue;
            return !CacheDictionary.TryGetValue(id, out returnValue) ? ItemType.Undefined : returnValue;
        }

        public override int GetId(ItemType value)
        {
            if (value.Equals(ItemType.Undefined))
                return 0;

            return base.GetId(value);
        }
    }
}
