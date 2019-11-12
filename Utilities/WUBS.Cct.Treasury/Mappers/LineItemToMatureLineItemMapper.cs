using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WUBS.Cct.Treasury.DomainModel.Entities;
using WUBS.Cct.Treasury.Infrastructure.Persistence.DB;
using WUBS.Cct.Treasury.Infrastructure.Persistence.Providers;
using WUBS.Cct.Treasury.Infrastructure.Utilities;
using WUBS.Cct.Treasury.Mappers.Interfaces;

namespace WUBS.Cct.Treasury.Mappers
{
    public class LineItemToMatureLineItemMapper : ILineItemToMatureLineItemMapper
    {
        private string connectionString { get; set; }


        public LineItemToMatureLineItemMapper(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<LineItemToMatureLineItemMapping> GetLineItemMatureLineItemMappingsByMatureOrderId(int orderId)
        {
            var mappings = new List<LineItemToMatureLineItemMapping>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"
                        SELECT AgingOrderDetail_ID AS OriginalLineItemId, MatureOrderDetail_ID AS RelatedMatureOrderLineItemId
                        FROM dbo.AgingItemMatureItemMap
                        WHERE MatureClientOrder_ID = @orderId AND AgingItemType_ID NOT IN (101, 109, 110)";

                    command.CommandType = CommandType.Text;
                    command.Parameters.Add(new SqlParameter("orderId", orderId));

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            mappings.Add(GetMappingFromDataReader(reader));
                        }
                    }
                }
            }

            return mappings;
        }

        public DateTime? GetAgingReleaseDateByItemId(int itemId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = string.Format("SELECT ReleaseDate FROM dbo.OrderDetailAging WHERE OrderDetail_ID = {0}", itemId);
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return DbReadingUtility.NullableDateTime(reader["ReleaseDate"]);
                        }
                    }
                }
            }

            return null;
        }

        private LineItemToMatureLineItemMapping GetMappingFromDataReader(SqlDataReader reader)
        {
            return new LineItemToMatureLineItemMapping
            {
                OriginalLineItemId = Convert.ToInt32(reader["OriginalLineItemId"]),
                RelatedMatureOrderLineItemId = Convert.ToInt32(reader["RelatedMatureOrderLineItemId"])
            };
        }
    }
}
