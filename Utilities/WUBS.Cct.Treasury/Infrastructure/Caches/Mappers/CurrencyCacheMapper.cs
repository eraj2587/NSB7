using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WUBS.Cct.Treasury.DomainModel.Financial;
using WUBS.Cct.Treasury.Infrastructure.Caches.Mappers.Interfaces;
using WUBS.Cct.Treasury.Infrastructure.Persistence.DB;
using WUBS.Cct.Treasury.Infrastructure.Persistence.Providers;
using WUBS.Cct.Treasury.Infrastructure.Utilities;

namespace WUBS.Cct.Treasury.Infrastructure.Caches.Mappers
{
    public class CurrencyCacheMapper : ICurrencyCacheMapper
    {
        private static ICurrencyCacheMapper instance;
        public static ICurrencyCacheMapper Instance
        {
            get
            {
                if (instance == null)
                    instance = new CurrencyCacheMapper();
                return instance;
            }
            set { instance = value; }
        }

        private CurrencyCacheMapper()
        {
        }

        private string CrsConnectionString
        {
            get { return DatabaseConnectionStringProvider.Instance.GetDatabaseConnectionString(Database.Crs); }
        }

        public Dictionary<int, Currency> GetAllCurrenciesDictionary()
        {
            var currenciesDictionary = new Dictionary<int, Currency>();
            using (var connection = new SqlConnection(CrsConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"
	                    SELECT [Currency_ID], [Code], [Description], [NDecValue], [RoundToNearestValue], [MinimumItemAmount], [MaximumItemAmount]                         
	                    FROM dbo.Currency
	                    ORDER BY Code ASC";

                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var currency = new Currency(Convert.ToString(reader["Code"]))
                            {
                                //Status = CurrencyStatusCache.Instance.Find(Convert.ToInt32(reader["Status_ID"])),
                                //IsSettlementCurrency =
                                //    (SettlementCurrencyStatusCache.Instance.GetId(SettlementCurrencyStatus.Enabled) == DbReadingUtility.NullableInt(reader["SettlementCurrencyStatusId"])),
                                Description = Convert.ToString(reader["Description"]),
                                NumberOfDecimals = Convert.ToInt32(reader["NDecValue"]),
                                RoundToNearestValue = DbReadingUtility.NullableDecimal(reader["RoundToNearestValue"]),
                                MinimumTransactionAmount = DbReadingUtility.NullableDecimal(reader["MinimumItemAmount"]),
                                MaximumTransactionAmount = DbReadingUtility.NullableDecimal(reader["MaximumItemAmount"])
                            };
                            currenciesDictionary.Add(Convert.ToInt32(reader["Currency_ID"]), currency);
                        }
                    }
                }
            }
            return currenciesDictionary;
        }
    }
}
