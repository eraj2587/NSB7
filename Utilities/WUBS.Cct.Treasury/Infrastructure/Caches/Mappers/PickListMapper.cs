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
    class PickListMapper : IPickListMapper
    {
        private static IPickListMapper instance;
        public static IPickListMapper Instance
        {
            get
            {
                if (instance == null)
                    instance = new PickListMapper();
                return instance;
            }
            set { instance = value; }
        }

        private PickListMapper()
        {
        }

        private string ConnectionString
        {
            get { return DatabaseConnectionStringProvider.Instance.GetDatabaseConnectionString(Database.RueschLink); }
        }

        public Dictionary<int, string> GetPickListItemsByPickListType(PickListType pickListType)
        {
            var pickListItems = new Dictionary<int, string>();
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"
                        SELECT PLI.PickListItem_ID, PLI.Code
	                    FROM 
                            dbo.PickListItem AS PLI INNER JOIN
                            dbo.PickList AS PL ON PLI.PickList_ID = PL.PickList_ID
	                    WHERE PL.Code = @pickListCode";

                    command.CommandType = CommandType.Text;
                    command.Parameters.Add(new SqlParameter("pickListCode", EnumUtility.CctCodeValueOf(pickListType)));

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                            pickListItems.Add(Convert.ToInt32(reader["PickListItem_ID"]), Convert.ToString(reader["Code"]));
                    }
                }
            }
            return pickListItems;
        }
    }
}
