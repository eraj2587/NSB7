using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WUBS.Cct.Treasury.DomainModel.Enums;
using WUBS.Cct.Treasury.DomainModel.Enums.Utility;
using WUBS.Cct.Treasury.Infrastructure.Caches.Mappers.Interfaces;
using WUBS.Cct.Treasury.Infrastructure.Persistence.DB;
using WUBS.Cct.Treasury.Infrastructure.Persistence.Providers;

namespace WUBS.Cct.Treasury.Infrastructure.Caches.Mappers
{
    public class ItemTypeMapper : IItemTypeMapper
    {
        private static IItemTypeMapper instance;
        public static IItemTypeMapper Instance
        {
            get
            {
                if (instance == null)
                    instance = new ItemTypeMapper();
                return instance;
            }
            set { instance = value; }
        }

        private ItemTypeMapper()
        {
        }

        private string ConnectionString
        {
            get { return DatabaseConnectionStringProvider.Instance.GetDatabaseConnectionString(Database.RueschLink); }
        }

        public Dictionary<int, string> GetItemTypesByOrderType(OrderType orderType)
        {
            var itemTypes = new Dictionary<int, string>();
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"
                        SELECT IT.ItemType_ID, IT.Code
                        FROM
                            dbo.OrderTypeItemType AS OTIT INNER JOIN
                            dbo.ItemType AS IT ON OTIT.ItemType_ID = IT.ItemType_ID INNER JOIN
                            dbo.OrderType AS OT ON OTIT.OrderType_ID = OT.OrderType_ID
                        WHERE OT.Code = @orderTypeCode";

                    command.CommandType = CommandType.Text;
                    command.Parameters.Add(new SqlParameter("orderTypeCode", EnumUtility.CctCodeValueOf(orderType)));

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                            itemTypes.Add(Convert.ToInt32(reader["ItemType_ID"]), Convert.ToString(reader["Code"]));
                    }
                }
            }
            return itemTypes;
        }
    }
}
