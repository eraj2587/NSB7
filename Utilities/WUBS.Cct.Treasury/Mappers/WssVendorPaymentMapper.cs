using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WUBS.Cct.Treasury.DomainModel.VendorDeals;
using WUBS.Cct.Treasury.Mappers.Interfaces;

namespace WUBS.Cct.Treasury.Mappers
{
    public class WssVendorPaymentMapper : IWssVendorPaymentMapper
    {
        private static string ConnectionString
        {
            get { return ConfigurationManager.AppSettings["ConnectionString.Baft"]; }
        }

        public void InsertVendorPayment(WssVendorPayment deal)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"
                        INSERT INTO [dbo].[zSQL_VendorPayment]
                            ([VendorName]
                            ,[ValueDate]
                            ,[DealDate]
                            ,[Currency]
                            ,[Amount]
                            ,[NetFlag]
                            ,[DealNo]
                            ,[IsTarget])
                        VALUES
                            (@VendorName,
                            @ValueDate,
                            @DealDate, 
                            @Currency,
                            @Amount,
                            @NetFlag, 
                            @DealNo,
                            @IsTarget)";

                    command.CommandType = CommandType.Text;
                    command.Parameters.Add(new SqlParameter("VendorName", deal.VendorName));
                    command.Parameters.Add(new SqlParameter("ValueDate", deal.ValueDate));
                    command.Parameters.Add(new SqlParameter("DealDate", deal.DealDate));
                    command.Parameters.Add(new SqlParameter("Currency", deal.Currency));
                    command.Parameters.Add(new SqlParameter("Amount", deal.Amount));
                    command.Parameters.Add(new SqlParameter("NetFlag", deal.NetFlag));
                    command.Parameters.Add(new SqlParameter("DealNo", deal.DealNo.ToString()));
                    command.Parameters.Add(new SqlParameter("IsTarget", deal.IsTarget));
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}