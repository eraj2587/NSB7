using System;
using System.Data;
using System.Data.SqlClient;
using WUBS.Cct.Treasury.DomainModel.Vms;
using WUBS.Cct.Treasury.Infrastructure.Persistence.DB;
using WUBS.Cct.Treasury.Infrastructure.Persistence.Providers;
using WUBS.Cct.Treasury.Infrastructure.Utilities;
using WUBS.Cct.Treasury.Mappers.Interfaces;

namespace WUBS.Cct.Treasury.Mappers
{
    public class VmsEventLogMapper : IVmsEventLogMapper
    {
        private string ConnectionString
        {
            get { return DatabaseConnectionStringProvider.Instance.GetDatabaseConnectionString(Database.Vms); }
        }

        public VmsEventLog GetNextUnprocessed()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"
	                    SELECT top 1
                            [LOG_ID],
		                    [ClientOrder_ID],
		                    [OrderDetail_ID],
		                    [NewClientOrder_ID],
		                    [NewOrderDetail_ID],
		                    [ITEM_NO],
		                    [EVENT],
		                    [PROCESSED],
		                    [INITID],
		                    [INITDT],
		                    [UPDID],
		                    [UPDDT]
	                    FROM [dbo].[VmsEventLog] WITH (UPDLOCK,READPAST) WHERE ISNULL([PROCESSED], 0) = 0";

                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return ConstructVmsEventLog(reader);
                        }
                    }
                }
            }

            return null;
        }

        private VmsEventLog ConstructVmsEventLog(SqlDataReader reader)
        {
            return new VmsEventLog
            {
                Id = Convert.ToInt32(reader["LOG_ID"]),
                OrderId = Convert.ToInt32(reader["ClientOrder_ID"]),
                LineItemId = Convert.ToInt32(reader["OrderDetail_ID"]),
                NewOrderId = DbReadingUtility.NullableInt(reader["NewClientOrder_ID"], null),
                NewLineItemId = DbReadingUtility.NullableInt(reader["NewOrderDetail_ID"], null),
                ItemNumber = DbReadingUtility.NullableInt(reader["ITEM_NO"], null),
                Event = DbReadingUtility.NullableString(reader["EVENT"]),
                Status = (RecordStatus)DbReadingUtility.NullableInt(reader["PROCESSED"]),
                CreatedBy = DbReadingUtility.NullableInt(reader["INITID"], null),
                CreatedOn = DbReadingUtility.NullableDateTime(reader["INITDT"], null),
                UpdatedBy = DbReadingUtility.NullableInt(reader["UPDID"], null),
                UpdatedOn = DbReadingUtility.NullableDateTime(reader["UPDDT"], null)
            };
        }

        public void Update(VmsEventLog eventLog)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"
	                    UPDATE [dbo].[VmsEventLog]
	                    SET
                            PROCESSED = @Status,
		                    UPDID = @Updid,
		                    UPDDT = @Upddt
	                    WHERE [LOG_ID] = @Log_Id";

                    command.CommandType = CommandType.Text;
                    command.Parameters.Add(new SqlParameter("Log_Id", eventLog.Id));
                    command.Parameters.Add(new SqlParameter("Status", eventLog.Status));
                    command.Parameters.Add(new SqlParameter("Updid", eventLog.UpdatedBy));
                    command.Parameters.Add(new SqlParameter("Upddt", eventLog.UpdatedOn));
                    command.ExecuteNonQuery();
                }
            }
        }

        public bool HasVMSModified(int clientOrderId)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        @"SELECT TOP 1 [ClientOrder_ID]
	                    FROM [dbo].[VmsEventLog] WITH (NOLOCK)
                        WHERE [ClientOrder_ID] = @clientOrderId";
                    command.Parameters.AddWithValue("@clientOrderId", clientOrderId);

                    return DbReadingUtility.NullableInt(command.ExecuteScalar()) > 0;
                }
            }
        }

        public int GetOrderIdByNewOrderId(int newClientOrderId)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        @"SELECT TOP 1 [ClientOrder_ID]
	                    FROM [dbo].[VmsEventLog] WITH (NOLOCK)
                        WHERE [NewClientOrder_ID] = @newClientOrderId";
                    command.Parameters.AddWithValue("@newClientOrderId", newClientOrderId);

                    return DbReadingUtility.NullableInt(command.ExecuteScalar());
                }
            }
        }
    }
}