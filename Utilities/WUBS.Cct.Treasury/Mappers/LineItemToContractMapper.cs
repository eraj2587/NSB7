using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using WUBS.Cct.Treasury.Mappers.Interfaces;

namespace WUBS.Cct.Treasury.Mappers
{
    public class LineItemToContractMapper : ILineItemToContractMapper
    {
        private readonly string connectionString;

        public LineItemToContractMapper(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public long GetContractId(int lineItemId)
        {
            if (lineItemId == 0) return 0;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText =
                        string.Format(
                            "SELECT ContractId FROM dbo.LineItemToContractMapping WITH (NOLOCK) WHERE LineItemId = {0} AND IsActive = 1", lineItemId);
                    command.CommandType = CommandType.Text;

                    return Convert.ToInt64(command.ExecuteScalar());
                }
            }
        }

        public IList<int> GetLineItemIdsByContractIds(long[] contractIds)
        {
            var lineItemIds = new List<int>();

            contractIds = contractIds.Where(id => id > 0).ToArray();
            if (!contractIds.Any()) return lineItemIds;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText =
                        string.Format(
                            "SELECT LineItemId FROM dbo.LineItemToContractMapping WITH (NOLOCK) WHERE ContractId IN ({0}) AND IsActive = 1", string.Join(",", contractIds));
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lineItemIds.Add(Convert.ToInt32(reader["LineItemId"]));
                        }
                    }
                }
            }

            return lineItemIds;
        }

        public IList<long> GetContractIdsByLineItemIds(int[] lineItemIds)
        {
            var contractIds = new List<long>();

            lineItemIds = lineItemIds.Where(id => id > 0).ToArray();
            if (!lineItemIds.Any()) return contractIds;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText =
                        string.Format(
                            "SELECT ContractId FROM dbo.LineItemToContractMapping WITH (NOLOCK) WHERE LineItemId IN ({0}) AND IsActive = 1", string.Join(",", lineItemIds));
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            contractIds.Add(Convert.ToInt64(reader["ContractId"]));
                        }
                    }
                }
            }

            return contractIds;
        }

        public IList<int> GetLineItemIdsByRelatedLineItemIds(int[] lineItemIds)
        {
            return GetLineItemIdsByContractIds(GetContractIdsByLineItemIds(lineItemIds).ToArray());
        }

        public void Save(LineItemToContractMapping mapping)
        {
            var lineItemContractIds = GetContractIdsByLineItemIds(new [] {mapping.LineItemId});

            if (!lineItemContractIds.Contains(mapping.ContractId))
            {
                if (lineItemContractIds.Any())
                {
                    DisableLineItemToContractMappings(mapping.LineItemId);
                }
                
                InsertLineItemToContractMapping(mapping.LineItemId, mapping.ContractId);
            }
        }

        public void Update(int newLineItemId, int existingLineItemId)
        {
            var existingLineItemContractIds = GetContractIdsByLineItemIds(new[] { existingLineItemId });

            if (existingLineItemContractIds.Any())
            {
                DisableLineItemToContractMappings(existingLineItemId);

                var contractId = existingLineItemContractIds.First();
                var newLineItemContractIds = GetContractIdsByLineItemIds(new[] { newLineItemId });

                if (!newLineItemContractIds.Contains(contractId))
                {
                    InsertLineItemToContractMapping(newLineItemId, contractId);
                }
            }
        }

        private void InsertLineItemToContractMapping(int lineItemId, long contractId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"
		                INSERT INTO [dbo].[LineItemToContractMapping] ([LineItemId], [ContractId], [IsActive]) 
		                VALUES (@lineItemId, @contractId, 1)";

                    command.CommandType = CommandType.Text;
                    command.Parameters.Add(new SqlParameter("lineItemId", lineItemId));
                    command.Parameters.Add(new SqlParameter("contractId", contractId));
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DisableLineItemToContractMappings(int lineItemId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText =
                        string.Format(
                            "UPDATE [dbo].[LineItemToContractMapping] SET [IsActive] = 0, [ExpiredOn] = GETDATE() WHERE [LineItemId] = {0}", lineItemId);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
            }
        }

        public bool IsAggregatedContract(long contractId, int[] lineItemIds)
        {
            if (contractId == 0) return false;
            lineItemIds = lineItemIds.Where(id => id > 0).ToArray();
            if (!lineItemIds.Any()) return false;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText =
                        string.Format(
                            "SELECT TOP 1 1 FROM dbo.LineItemToContractMapping WITH (NOLOCK) WHERE ContractId = {0} AND LineItemId in ({1}) AND IsActive = 1", contractId, string.Join(",", lineItemIds));
                    command.CommandType = CommandType.Text;

                    return Convert.ToBoolean(command.ExecuteScalar());
                }
            }
        }

        private static DataTable ToDataTable<T>(IEnumerable<T> ids)
        {
            var table = new DataTable();
            table.Columns.Add("ID", typeof(T));

            foreach (T id in ids)
                table.Rows.Add(id);

            return table;
        }
    }
}
