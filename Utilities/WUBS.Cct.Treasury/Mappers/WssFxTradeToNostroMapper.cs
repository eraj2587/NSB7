using System;
using System.Data;
using System.Data.SqlClient;
using WUBS.Cct.Treasury.DomainModel.VendorDeals;
using WUBS.Cct.Treasury.Infrastructure.Persistence.DB;
using WUBS.Cct.Treasury.Infrastructure.Persistence.Providers;
using WUBS.Cct.Treasury.Infrastructure.Utilities;
using WUBS.Cct.Treasury.Mappers.Interfaces;

namespace WUBS.Cct.Treasury.Mappers
{
    public class WssFxTradeToNostroMapper : IWssFxTradeToNostroMapper
    {
        private string ConnectionString
        {
            get { return DatabaseConnectionStringProvider.Instance.GetDatabaseConnectionString(Database.NostroSubsidiary); }
        }

        public WssFxTrade Save(WssFxTrade deal)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("dbo.SP_WSFX_To_NSTrans_Tables", connection)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    command.Parameters.Add(new SqlParameter("UserId", deal.UserId));
                    command.Parameters.Add(new SqlParameter("RefNumber", deal.RefNumber));
                    command.Parameters.Add(new SqlParameter("RelatedRefNumber", deal.RelatedRefNumber));
                    command.Parameters.Add(new SqlParameter("DealType", deal.DealType));
                    command.Parameters.Add(new SqlParameter("ItemType", deal.ItemType));
                    command.Parameters.Add(new SqlParameter("BuyCcy", deal.BuyCcy));
                    command.Parameters.Add(new SqlParameter("SellCcy", deal.SellCcy));
                    command.Parameters.Add(new SqlParameter("BuyAmount", deal.BuyAmount));
                    command.Parameters.Add(new SqlParameter("SellAmount", deal.SellAmount));
                    command.Parameters.Add(new SqlParameter("TradeRate", deal.TradeRate));
                    command.Parameters.Add(new SqlParameter("CustNo", deal.CustNo));
                    command.Parameters.Add(new SqlParameter("EntryDate", deal.EntryDate));
                    command.Parameters.Add(new SqlParameter("TradeDate", deal.TradeDate));
                    command.Parameters.Add(new SqlParameter("ValueDate", deal.ValueDate));
                    command.Parameters.Add(new SqlParameter("MultDiv", deal.MultDiv));
                    command.Parameters.Add(new SqlParameter("Status", SqlDbType.Int) { Direction = ParameterDirection.Output });
                    command.Parameters.Add(new SqlParameter("StatusMsg", SqlDbType.VarChar, 180) { Direction = ParameterDirection.Output });
                    command.ExecuteNonQuery();

                    deal.Status = Convert.ToInt32(command.Parameters["Status"].Value);
                    deal.StatusMsg = DbReadingUtility.NullableString((command.Parameters["StatusMsg"].Value));

                    return deal;
                }
            }
        }
    }
}
