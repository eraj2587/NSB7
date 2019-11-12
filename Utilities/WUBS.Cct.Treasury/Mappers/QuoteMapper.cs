using System;
using System.Data;
using System.Data.SqlClient;
using WUBS.Cct.Treasury.DomainModel.Entities;
using WUBS.Cct.Treasury.DomainModel.Enums;
using WUBS.Cct.Treasury.DomainModel.Financial;
using WUBS.Cct.Treasury.DomainModel.Trading;
using WUBS.Cct.Treasury.Infrastructure.Caches;
using WUBS.Cct.Treasury.Infrastructure.Persistence.DB;
using WUBS.Cct.Treasury.Infrastructure.Persistence.Providers;
using WUBS.Cct.Treasury.Infrastructure.Utilities;
using WUBS.Cct.Treasury.Mappers.Interfaces;

namespace WUBS.Cct.Treasury.Mappers
{
    public class QuoteMapper : IQuoteMapper
    {
        private string ConnectionString
        {
            get { return DatabaseConnectionStringProvider.Instance.GetDatabaseConnectionString(Database.Crs); }
        }

        public int GetLatestRateRunId()
        {

            using (var connection = new SqlConnection(ConnectionString))
            {

                var getRateRunCommand = new SqlCommand("dbo.sp__GetMaxRateRunID", connection);
                getRateRunCommand.CommandType = CommandType.StoredProcedure;

                //getRateRunCommand.Parameters.Add(new SqlParameter("RLApplication_ID",
                //                                                  ApplicationCache.Instance.GetId(
                //                                                      Application.GlobalPayPlus)));
                getRateRunCommand.Parameters.Add(new SqlParameter("RLApplication_ID", 8));
                getRateRunCommand.Parameters.Add(new SqlParameter("SpreadType_ID",
                                                                  MarkupTypeCache.Instance.GetId(MarkupType.Nostro)));
                getRateRunCommand.Parameters.Add(new SqlParameter("RateRun_ID", SqlDbType.Int)
                { Direction = ParameterDirection.Output });
                getRateRunCommand.Parameters.Add(new SqlParameter("status", SqlDbType.Int)
                { Direction = ParameterDirection.Output });
                getRateRunCommand.Parameters.Add(new SqlParameter("statusmsg", SqlDbType.VarChar, 90)
                { Direction = ParameterDirection.Output });

                getRateRunCommand.Connection.Open();
                getRateRunCommand.ExecuteNonQuery();

                //ValidateStoredProcedureStatus(Convert.ToInt32(getRateRunCommand.Parameters["status"].Value),
                //                              Convert.ToString(getRateRunCommand.Parameters["statusMsg"].Value));

                return Convert.ToInt32(getRateRunCommand.Parameters["RateRun_ID"].Value);
            }
        }

        public Rate GetMidRate(Currency targetCurrency, Currency refCurrency, int rateRunId, TradeDirection tradeDirection)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {

                var datetime = DateTime.Now;

                var command = new SqlCommand("dbo.sp__GetCrossRate", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("SettlementCurrency_ID",
                                                        CurrencyCache.Instance.GetId(targetCurrency)));
                command.Parameters.Add(new SqlParameter("Currency_ID", CurrencyCache.Instance.GetId(refCurrency)));
                command.Parameters.Add(new SqlParameter("ReportingCurrency_ID",
                                                        CurrencyCache.Instance.GetId(targetCurrency)));
                command.Parameters.Add(new SqlParameter("RateRun_ID", rateRunId));
                command.Parameters.Add(new SqlParameter("Language_ID", 1));
                command.Parameters.Add(new SqlParameter("EntitySpreadType_ID",
                                                        MarkupTypeCache.Instance.GetId(MarkupType.Nostro)));
                command.Parameters.Add(new SqlParameter("Parent_EffectiveSellMultiplier", SqlDbType.Float) { Value = 1f });
                command.Parameters.Add(new SqlParameter("Parent_EffectiveBuyMultiplier", SqlDbType.Float) { Value = 1f });
                command.Parameters.Add(new SqlParameter("Child_EffectiveSellMultiplier", SqlDbType.Float) { Value = 1f });
                command.Parameters.Add(new SqlParameter("Child_EffectiveBuyMultiplier", SqlDbType.Float) { Value = 1f });
                command.Parameters.Add(new SqlParameter("EffectiveForwardStart_BuyMultiplier", SqlDbType.Float)
                { Value = 0f });
                command.Parameters.Add(new SqlParameter("EffectiveForwardStart_SellMultiplier", SqlDbType.Float)
                { Value = 0f });
                command.Parameters.Add(new SqlParameter("EffectiveForwardEnd_BuyMultiplier", SqlDbType.Float)
                { Value = 0f });
                command.Parameters.Add(new SqlParameter("EffectiveForwardEnd_SellMultiplier", SqlDbType.Float)
                { Value = 0f });
                command.Parameters.Add(new SqlParameter("Currency_CostPriceSellSpread", SqlDbType.Float) { Value = 0f });
                command.Parameters.Add(new SqlParameter("Currency_CostPriceBuySpread", SqlDbType.Float) { Value = 0f });
                command.Parameters.Add(new SqlParameter("Currency_CostPriceMarkupType_ID", DBNull.Value));
                command.Parameters.Add(new SqlParameter("Currency_TradingHoursSellSpread", SqlDbType.Float) { Value = 0f });
                command.Parameters.Add(new SqlParameter("Currency_TradingHoursBuySpread", SqlDbType.Float) { Value = 0f });
                command.Parameters.Add(new SqlParameter("Currency_TradingHoursMarkupType_ID", DBNull.Value));
                command.Parameters.Add(new SqlParameter("SettlementCurrency_CostPriceSellSpread", SqlDbType.Float)
                { Value = 0f });
                command.Parameters.Add(new SqlParameter("SettlementCurrency_CostPriceBuySpread", SqlDbType.Float)
                { Value = 0f });
                command.Parameters.Add(new SqlParameter("SettlementCurrency_CostPriceMarkupType_ID", DBNull.Value));
                command.Parameters.Add(new SqlParameter("SettlementCurrency_TradingHoursSellSpread", SqlDbType.Float)
                { Value = 0f });
                command.Parameters.Add(new SqlParameter("SettlementCurrency_TradingHoursBuySpread", SqlDbType.Float)
                { Value = 0f });
                command.Parameters.Add(new SqlParameter("SettlementCurrency_TradingHoursMarkupType_ID", DBNull.Value));
                command.Parameters.Add(new SqlParameter("Child_IsPer", (int)RateConvention.Default));
                command.Parameters.Add(new SqlParameter("ForwardStartDate", datetime));
                command.Parameters.Add(new SqlParameter("ForwardEndDate", datetime));
                command.Parameters.Add(new SqlParameter("ForwardPoints", SqlDbType.Float) { Value = 0f });
                command.Parameters.Add(new SqlParameter("SwiftCode", SqlDbType.VarChar, 17)
                { Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("CurrencyDescription", SqlDbType.VarChar, 64)
                { Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("WeSellRate", SqlDbType.Float)
                { Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("WeBuyRate", SqlDbType.Float)
                { Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("WeSellRateStr", SqlDbType.VarChar, 33)
                { Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("WeBuyRateStr", SqlDbType.VarChar, 33)
                { Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("LowRate", SqlDbType.Decimal)
                { Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("HighRate", SqlDbType.Decimal)
                { Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("NDec", SqlDbType.Int) { Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("IsPer", SqlDbType.Int) { Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("SettlementCode", SqlDbType.VarChar, 17)
                { Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("SettlementCurrencySymbol", SqlDbType.VarChar, 7)
                { Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("SettlementRate", SqlDbType.Decimal)
                { Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("SettlementRateStr", SqlDbType.VarChar, 33)
                { Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("SettlementIsPer", SqlDbType.Int)
                { Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("SettlementNDec", SqlDbType.Int)
                { Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("SettlementMultiplier", SqlDbType.Int)
                { Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("ReportingCode", SqlDbType.VarChar, 17)
                { Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("ReportingRate", SqlDbType.Decimal)
                { Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("ReportingRateStr", SqlDbType.VarChar, 33)
                { Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("ReportingIsPer", SqlDbType.Int)
                { Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("ReportingNDec", SqlDbType.Int)
                { Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("ReportingMultiplier", SqlDbType.Int)
                { Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("CurrencyBaseBuySpread", SqlDbType.Decimal)
                { Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("CurrencyBaseSellSpread", SqlDbType.Decimal)
                { Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("RateMultiplier", SqlDbType.Int)
                { Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("SpotSellRate", SqlDbType.Decimal)
                { Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("SpotBuyRate", SqlDbType.Decimal)
                { Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("SpotSellRateStr", SqlDbType.VarChar, 33)
                { Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("SpotBuyRateStr", SqlDbType.VarChar, 33)
                { Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("SpotRateDateTime", SqlDbType.DateTime)
                { Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("SpotRateNDec", SqlDbType.Int)
                { Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("SpotRateIsPer", SqlDbType.Int)
                { Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("SpotRateMultiplier", SqlDbType.Int)
                { Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("ReutersSpotSellRate", SqlDbType.Decimal)
                { Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("ReutersSpotBuyRate", SqlDbType.Decimal)
                { Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("ReutersSpotSellRateStr", SqlDbType.VarChar, 33)
                { Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("ReutersSpotBuyRateStr", SqlDbType.VarChar, 33)
                { Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("CostPriceSellMarkup", SqlDbType.Decimal)
                { Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("CostPriceBuyMarkup", SqlDbType.Decimal)
                { Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("ParentSpotSellRate", SqlDbType.Decimal)
                { Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("ParentSpotBuyRate", SqlDbType.Decimal)
                { Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("ForwardSellRate", SqlDbType.Decimal)
                { Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("ForwardBuyRate", SqlDbType.Decimal)
                { Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("ForwardSellRateStr", SqlDbType.VarChar, 33)
                { Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("ForwardBuyRateStr", SqlDbType.VarChar, 33)
                { Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("ForwardSellPoints", SqlDbType.Decimal)
                { Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("ForwardBuyPoints", SqlDbType.Decimal)
                { Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("ForwardSellDate", SqlDbType.DateTime)
                { Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("ForwardBuyDate", SqlDbType.DateTime)
                { Direction = ParameterDirection.Output });

                command.Parameters.Add(new SqlParameter("status", SqlDbType.Int) { Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("statusmsg", SqlDbType.VarChar, 90)
                { Direction = ParameterDirection.Output });

                command.Connection.Open();
                command.ExecuteNonQuery();

                //ValidateStoredProcedureStatus(Convert.ToInt32(command.Parameters["status"].Value),
                //                              Convert.ToString(command.Parameters["statusmsg"].Value));

                var rateConvention = command.Parameters["IsPer"].Value != DBNull.Value ? (RateConvention)Convert.ToInt32(command.Parameters["IsPer"].Value) : 0;
                var midRateMultiplier = command.Parameters["RateMultiplier"].Value != DBNull.Value ? Convert.ToInt32(command.Parameters["RateMultiplier"].Value) : 1;
                var numDec = command.Parameters["NDec"].Value != DBNull.Value ? Convert.ToInt32(command.Parameters["NDec"].Value) : 0;
                decimal midRateValue = command.Parameters["WeSellRate"].Value != DBNull.Value ? Convert.ToDecimal(command.Parameters["WeSellRate"].Value) : 0;
                if (tradeDirection == TradeDirection.Buy)
                    midRateValue = command.Parameters["WeSellRate"].Value != DBNull.Value ? Convert.ToDecimal(command.Parameters["WeBuyRate"].Value) : 0;

                var midRate = CreateRateFromMultipliedValue(rateConvention, midRateValue, targetCurrency, refCurrency, midRateMultiplier, numDec, numDec);

                return midRate;
            }
        }


        public LineItemQuote GetLineItemQuote(int lineItemQuoteId)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = CreateQuoteQuery(lineItemQuoteId);
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                            return GetLineItemQuoteFromDataReader(reader);
                    }
                }
            }

            throw new ArgumentException("Invalid quote ID: " + lineItemQuoteId);
        }

        public LineItemQuote GetRepurchaseLineItemQuote(decimal itemRate, ClientRateComponent relatedClientRateComponent)
        {
            var lineItemQuote = new LineItemQuote
            {
                SpotRate = relatedClientRateComponent.CostRateComponent.SpotRate,
                ForwardPoints = relatedClientRateComponent.CostRateComponent.ForwardPoints,
                ClientRate = itemRate != 0 ? CreateRateFromMultipliedValue(relatedClientRateComponent.ClientRate.RateConvention,
                    itemRate,
                    relatedClientRateComponent.ClientRate.UnitCurrency,
                    relatedClientRateComponent.ClientRate.RefCurrency,
                    relatedClientRateComponent.ClientRate.MetaData.MultiplierDirect,
                    relatedClientRateComponent.ClientRate.MetaData.NumberOfDecimalsDirectMultiplied,
                    relatedClientRateComponent.ClientRate.MetaData.NumberOfDecimalsIndirectMultiplied) : relatedClientRateComponent.ClientRate
            };

            return lineItemQuote;
        }

        private static LineItemQuote GetLineItemQuoteFromDataReader(SqlDataReader reader)
        {
            var lineItemQuote = new LineItemQuote();
            PopulateQuoteFromDataReader(lineItemQuote, reader);

            var tradeCurrency = CurrencyCache.Instance.GetById(Convert.ToInt32(reader["Currency_ID"]));

            var settlementCurrency = CurrencyCache.Instance.GetById(Convert.ToInt32(reader["SettlementCurrency_ID"]));

            var rateConventionSpotRate = (RateConvention)Convert.ToInt32(reader["SpotRateIsPer"]);
            var rateConventionClientRate = (RateConvention)Convert.ToInt32(reader["ClientRateIsPer"]);
            var rateConventionForwardPoints = (RateConvention)Convert.ToInt32(reader["ForwardPointsIsPer"]);

            if (rateConventionClientRate == RateConvention.Default)
                rateConventionClientRate = rateConventionSpotRate;

            var nDecIndirect = Convert.ToInt32(reader["SpotRateNDecPer"]);
            var nDecDirect = Convert.ToInt32(reader["SpotRateNDecIn"]);

            lineItemQuote.SpotRate = CreateRateFromUnmultipliedValue(rateConventionSpotRate, Convert.ToDecimal(reader["SpotRate"]),
                                                settlementCurrency, tradeCurrency,
                                                Convert.ToInt32(reader["RateMultiplier"]), nDecDirect, nDecIndirect);

            lineItemQuote.ClientRate = CreateRateFromMultipliedValue(rateConventionClientRate, Convert.ToDecimal(reader["ClientRate"]),
                                                settlementCurrency, tradeCurrency,
                                                Convert.ToInt32(reader["RateMultiplier"]), nDecDirect, nDecIndirect);

            lineItemQuote.ForwardPoints = CalculateForwardPoints(DbReadingUtility.NullableDecimal(reader["ForwardPoints"]),
                rateConventionSpotRate, rateConventionForwardPoints, lineItemQuote);

            lineItemQuote.MarkupPct = ConvertCctMarkupInTenthsOfPercentToMarkupInPercent(DbReadingUtility.NullableDecimal(reader["Spread"]));
            lineItemQuote.StartValueDate = DbReadingUtility.NullableDateTime(reader["ForwardStartDate"]);
            lineItemQuote.EndValueDate = DbReadingUtility.NullableDateTime(reader["ForwardEndDate"]);

            return lineItemQuote;
        }

        private static decimal ConvertCctMarkupInTenthsOfPercentToMarkupInPercent(decimal cctMarkup)
        {
            return Decimal.Round(cctMarkup * 0.1m, 2);
        }

        private static Rate CreateRateFromMultipliedValue(RateConvention rateConvention, decimal value, Currency baseCurrency, Currency currency, int rateMultiplier, int numDecDirect, int numDecIndirect)
        {
            return Rate.CreateRate(currency, baseCurrency, value, true, new RateMetaData(numDecDirect, numDecIndirect, rateMultiplier, rateMultiplier), rateConvention);
        }

        private static Rate CreateRateFromUnmultipliedValue(RateConvention rateConvention, decimal value, Currency baseCurrency, Currency currency, int rateMultiplier, int numDecDirect, int numDecIndirect)
        {
            return Rate.CreateRate(currency, baseCurrency, value, false, new RateMetaData(numDecDirect, numDecIndirect, rateMultiplier, rateMultiplier), rateConvention);
        }

        private static decimal CalculateForwardPoints(decimal forwardPoints, RateConvention rateConventionSpotRate, RateConvention rateConventionForwardPoints, LineItemQuote lineItem)
        {
            return rateConventionForwardPoints != rateConventionSpotRate
                ? lineItem.SpotRate.NewValue(1 / lineItem.ClientRate - 1 / (lineItem.ClientRate - forwardPoints)).RoundedValue
                : forwardPoints;
        }

        private static void PopulateQuoteFromDataReader(Quote quote, SqlDataReader reader)
        {
            quote.Id = Convert.ToInt32(reader["Quote_ID"]);
            quote.ExpirationTimeStamp = DbReadingUtility.TimeZoneAdjustedNullableDateTime(reader["SelectedDuration"]);
            quote.RateRunId = DbReadingUtility.NullableInt((reader["RateRun_ID"]));
            quote.ExpirationDurationInMinutes = (double)DbReadingUtility.NullableDecimal(reader["Duration"]);
            quote.EffectiveMultiplier = DbReadingUtility.NullableDecimal(reader["ChildEffectiveMultiplier"]);
            quote.MarkupType = MarkupTypeCache.Instance.GetById(Convert.ToInt32((reader["SpreadType_ID"])));
            quote.ClientId = Convert.ToInt32(reader["Client_ID"]);
        }

        private static string CreateQuoteQuery(int quoteId)
        {
            return CreateQueryFromTable(quoteId, "Quote")
                + "ELSE" + CreateQueryFromTable(quoteId, "QuoteHistory")
                + "ELSE" + CreateQueryFromTable(quoteId, "QuoteHistory_Archive");
        }

        private static string CreateQueryFromTable(int quoteId, string table)
        {
            return string.Format(@"
			IF EXISTS (SELECT [Quote_ID] FROM [dbo].[{1}] WHERE Quote_ID = {0})
			BEGIN
				{2}
				{3}
			END
			", quoteId, table, QuoteFields, CreateFromTableStatement(quoteId, table)
            );
        }

        private const string QuoteFields = @"
			SELECT Quote.Quote_ID,
					Quote.Rate as ClientRate,
					Quote.RateString as ClientRateString,
					Quote.SpotRate,
					COALESCE(Quote.SpotRateIsPer, ccRate.IsPerBase) as SpotRateIsPer,
					Quote.SettlementRate,
					Quote.ReportingRate,
					Quote.RateIsPer as ClientRateIsPer,
					Quote.SelectedDuration,
					Quote.Duration,
					Quote.BuySell_ID,	
					Quote.Spread,
					Quote.ForwardStartDate,
					Quote.ForwardEndDate,
					Quote.ForwardDate,
					Quote.ForwardPoints,
					Quote.ForwardPointsIsPer,
					Quote.RateRun_ID,
					Quote.Client_ID,
					Quote.Currency_ID,
					Quote.SettlementCurrency_ID,
					Quote.ReportingCurrency_ID,
					Quote.Status_ID,
					Quote.ChildEffectiveMultiplier,
					Quote.SpreadType_ID,
					(SELECT Currency_ID from dbo.Currency where Code='USD') as SettlementRateBaseCurrency_ID,
					(SELECT Currency_ID from dbo.Currency where Code='USD') as ReportingRateBaseCurrency_ID,
					ccRate.NDecIn as SpotRateNDecIn,
					ccRate.NDecPer as SpotRateNDecPer,
					Quote.RateMultiplier,
					ccReportingRate.IsPerBase ReportingRateIsPerBase,
					ccReportingRate.NDecIn ReportingRateNDecIn,
					ccReportingRate.NDecPer ReportingRateNDecPer,
					ccReportingRate.RateMultiplier ReportingRateMultiplier,
					ccSettlementRate.IsPerBase SettlementRateIsPerBase,
					ccSettlementRate.NDecIn SettlementRateNDecIn,
					ccSettlementRate.NDecPer SettlementRateNDecPer,
					ccSettlementRate.RateMultiplier SettlementRateMultiplier  ,
					ccSettlementReportingRate.IsPerBase SettlementReportingRateIsPerBase,
					ccSettlementReportingRate.NDecIn SettlementReportingRateNDecIn,
					ccSettlementReportingRate.NDecPer SettlementReportingRateNDecPer,
					ccSettlementReportingRate.RateMultiplier SettlementReportingRateMultiplier
			";

        private static string CreateFromTableStatement(int quoteId, string table)
        {
            return string.Format(@"
			FROM [dbo].[{1}] AS Quote
				LEFT OUTER JOIN [dbo].[CrossCurrency] ccRate ON ccRate.TargetCurrency_ID = Quote.Currency_ID AND ccRate.BaseCurrency_ID = Quote.SettlementCurrency_ID
				LEFT OUTER JOIN [dbo].[CrossCurrency] ccReportingRate ON ccReportingRate.TargetCurrency_ID = Quote.ReportingCurrency_ID AND ccReportingRate.BaseCurrency_ID = (SELECT Currency_ID from dbo.Currency where Code='USD')
				LEFT OUTER JOIN [dbo].[CrossCurrency] ccSettlementRate ON ccSettlementRate.TargetCurrency_ID = Quote.SettlementCurrency_ID AND ccSettlementRate.BaseCurrency_ID = (SELECT Currency_ID from dbo.Currency where Code='USD')	
				LEFT OUTER JOIN [dbo].[CrossCurrency] ccSettlementReportingRate ON ccSettlementReportingRate.TargetCurrency_ID = Quote.SettlementCurrency_ID AND ccSettlementReportingRate.BaseCurrency_ID = Quote.ReportingCurrency_ID		
			WHERE Quote_ID = {0}
			", quoteId, table
            );
        }
    }
}
