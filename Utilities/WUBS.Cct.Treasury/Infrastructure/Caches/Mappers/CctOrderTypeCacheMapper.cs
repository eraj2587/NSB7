using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using WUBS.Cct.Treasury.DomainModel.Entities;
using WUBS.Cct.Treasury.Infrastructure.Caches.Mappers.Interfaces;
using WUBS.Cct.Treasury.Infrastructure.Persistence.DB;
using WUBS.Cct.Treasury.Infrastructure.Persistence.Providers;

namespace WUBS.Cct.Treasury.Infrastructure.Caches.Mappers
{
    public class CctOrderTypeCacheMapper : ICctOrderTypeCacheMapper
    {
        private static ICctOrderTypeCacheMapper instance;
        public static ICctOrderTypeCacheMapper Instance
        {
            get { return instance ?? (instance = new CctOrderTypeCacheMapper()); }
            set { instance = value; }
        }

        private CctOrderTypeCacheMapper()
        {
        }

        private string RueschlinkConnectionString
        {
            get { return DatabaseConnectionStringProvider.Instance.GetDatabaseConnectionString(Database.RueschLink); }
        }

        public Dictionary<int, CctOrderType> GetAllCctOrderTypesDictionary()
        {
            var orderTypeDictionary = new Dictionary<int, CctOrderType>();

            using (var connection = new SqlConnection(RueschlinkConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"
	                    SELECT OrderType_ID, Code, Description, BuySell_ID, SpreadType_ID                       
	                    FROM dbo.OrderType
	                    ORDER BY OrderType_ID ASC";

                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var orderType = new CctOrderType
                            {
                                Id = Convert.ToInt32(reader["OrderType_ID"]),
                                Code = Convert.ToString(reader["Code"]),
                                Description = Convert.ToString(reader["Description"]),
                                BuySellId = Convert.ToInt32(reader["BuySell_ID"] == DBNull.Value ? "0" : reader["BuySell_ID"]),
                                SpreadTypeId = Convert.ToInt32(reader["SpreadType_ID"] == DBNull.Value ? "0" : reader["SpreadType_ID"])
                            };
                            orderTypeDictionary.Add(Convert.ToInt32(reader["OrderType_ID"]), orderType);
                        }
                    }
                }
            }
            return orderTypeDictionary;
        }

        public Dictionary<int, CctRepurchaseType> GetAllCctRepurchaseTypesDictionary()
        {
            var repurchaseTypeDictionary = new Dictionary<int, CctRepurchaseType>();

            using (var connection = new SqlConnection(RueschlinkConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"
	                    SELECT OTRT.RepoOrderType_ID, OTRT.OrderType_ID, OT.Code, OT.Description, OT.BuySell_ID, OT.SpreadType_ID                         
	                    FROM dbo.OrderTypeRepurchaseType OTRT
	                    LEFT JOIN dbo.OrderType OT ON OTRT.RepoOrderType_ID = OT.OrderType_ID";

                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var repurchaseType = new CctRepurchaseType
                            {
                                RepoOrderTypeId = Convert.ToInt32(reader["RepoOrderType_ID"]),
                                OrderTypeId = Convert.ToInt32(reader["OrderType_ID"]),
                                Code = Convert.ToString(reader["Code"] ?? string.Empty),
                                Description = Convert.ToString(reader["Description"] ?? string.Empty),
                                BuySellId = Convert.ToInt32(reader["BuySell_ID"] == DBNull.Value ? "0" : reader["BuySell_ID"]),
                                SpreadTypeId = Convert.ToInt32(reader["SpreadType_ID"] == DBNull.Value ? "0" : reader["SpreadType_ID"])
                            };
                            repurchaseTypeDictionary.Add(Convert.ToInt32(reader["RepoOrderType_ID"]), repurchaseType);
                        }
                    }
                }
            }
            return repurchaseTypeDictionary;
        }
    }
}
