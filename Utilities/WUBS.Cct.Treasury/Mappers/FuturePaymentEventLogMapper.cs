using System;
using System.Data;
using System.Data.SqlClient;
using WUBS.Cct.Treasury.DomainModel.Entities;
using WUBS.Cct.Treasury.DomainModel.Vms;
using WUBS.Cct.Treasury.Infrastructure.Persistence.DB;
using WUBS.Cct.Treasury.Infrastructure.Persistence.Providers;
using WUBS.Cct.Treasury.Infrastructure.Utilities;
using WUBS.Cct.Treasury.Mappers.Interfaces;

namespace WUBS.Cct.Treasury.Mappers
{
    public class FuturePaymentEventLogMapper : IFuturePaymentEventLogMapper
    {
        private string ConnectionString
        {
            get { return DatabaseConnectionStringProvider.Instance.GetDatabaseConnectionString(Database.RueschLink); }
        }

        public FuturePaymentEventLog GetNextUnprocessed()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText =
                        @"SELECT TOP 1 fp1.*, fp2.PreviousReleaseDate
                            FROM [FuturePaymentEventLog] fp1
                            WITH (UPDLOCK, READPAST)
                            LEFT JOIN
                            (SELECT [OrderDetailId], [Upddt], [NewReleaseDate] AS PreviousReleaseDate
                              FROM [FuturePaymentEventLog]
                              WHERE [PROCESSED] = 1
                            ) AS fp2
                            ON fp1.[OrderDetailId] = fp2.[OrderDetailId]
                            WHERE ISNULL(fp1.[PROCESSED], 0) = 0
							ORDER BY fp2.[Upddt] DESC";
                    command.CommandType = CommandType.Text;
                    using (var dr = command.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            return ConstructFuturePaymentEventLog(dr);
                        }
                    }
                }
            }

            return null;
        }

        public void Update(FuturePaymentEventLog eventLog)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText =
                        string.Format(
                            "UPDATE dbo.FuturePaymentEventLog SET Processed = {0}, ProcessedTime = GETDATE(), Upddt = GETDATE() WHERE OrderDetailId = {1} AND Id = {2}",
                            (byte)eventLog.Status, eventLog.LineItemId, eventLog.Id);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
            }
        }

        public FuturePaymentEventLog GetByLineItemId(int lineItemId)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = string.Format(
                        @"SELECT TOP 1 *, null AS PreviousReleaseDate FROM [FuturePaymentEventLog] WHERE OrderDetailId = {0} ORDER BY UpdDt DESC ",
                        lineItemId);
                    command.CommandType = CommandType.Text;
                    using (var dr = command.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            return ConstructFuturePaymentEventLog(dr);
                        }
                    }
                }
            }

            return null;
        }

        private FuturePaymentEventLog ConstructFuturePaymentEventLog(SqlDataReader reader)
        {
            return new FuturePaymentEventLog
            {
                Id = Convert.ToInt32(reader["Id"]),
                LineItemId = Convert.ToInt32(reader["OrderDetailId"]),
                NewReleaseDate = Convert.ToDateTime(reader["NewReleaseDate"]),
                Status = (RecordStatus)DbReadingUtility.NullableInt(reader["Processed"]),
                ProcessedTime = DbReadingUtility.NullableDateTime(reader["ProcessedTime"], null),
                CreatedOn = DbReadingUtility.NullableDateTime(reader["Initdt"], null),
                UpdatedOn = DbReadingUtility.NullableDateTime(reader["Upddt"], null),
                PreviousReleaseDate = DbReadingUtility.NullableDateTime(reader["PreviousReleaseDate"], null)
            };
        }
    }
}