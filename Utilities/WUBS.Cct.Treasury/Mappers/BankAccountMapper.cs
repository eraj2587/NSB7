using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WUBS.Cct.Treasury.Infrastructure.Utilities;
using WUBS.Cct.Treasury.Mappers.Interfaces;

namespace WUBS.Cct.Treasury.Mappers
{
    public class BankAccountMapper : IBankAccountMapper
    {
        private static string ConnectionString
        {
            get { return ConfigurationManager.AppSettings["ConnectionString.Baft"]; }
        }

        public string GetBankListCodeByToAccountId(int? toAccountId)
        {
            if (toAccountId == null) return null;

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT BankListCode FROM dbo.BankAccounts WHERE ToAccount_ID = @toAccountId";
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add(new SqlParameter("toAccountId", toAccountId));

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return DbReadingUtility.NullableString(reader["BankListCode"]);
                        }
                    }
                }
            }

            return null;
        }
    }
}
