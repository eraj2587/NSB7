using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using WUBS.Cct.Treasury.Infrastructure.Caches.Mappers.Interfaces;
using WUBS.Cct.Treasury.Infrastructure.Persistence.DB;
using WUBS.Cct.Treasury.Infrastructure.Persistence.Providers;

namespace WUBS.Cct.Treasury.Infrastructure.Caches.Mappers
{
    public class CurrencyHolidayCacheMapper : ICurrencyHolidayCacheMapper
    {
        private static ICurrencyHolidayCacheMapper instance;
        public static ICurrencyHolidayCacheMapper Instance
        {
            get
            {
                if (instance == null)
                    instance = new CurrencyHolidayCacheMapper();
                return instance;
            }
            set { instance = value; }
        }

        private CurrencyHolidayCacheMapper()
        {
        }

        private string RueschLinkConnectionString
        {
            get { return DatabaseConnectionStringProvider.Instance.GetDatabaseConnectionString(Database.RueschLink); }
        }

        public Dictionary<int, Holiday[]> GetAllCurrencyHolidaysDictionary()
        {
            var holidaysDictionary = new Dictionary<int, List<Holiday>>();
            using (var connection = new SqlConnection(RueschLinkConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT [BankHoliday_ID],[Currency_ID],[HolidayDate],[Description],[Country_ID] FROM [BankHoliday]", connection))
                {
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.IsDBNull(2)) continue; //skip null dates

                            var currencyId = reader.GetInt32(1);
                            var holiday = new Holiday
                            {
                                HolidayDate = reader.GetDateTime(2),
                                Description = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                                CountryId = reader.IsDBNull(4) ? -1 : reader.GetInt32(4)

                            };
                            var holidays = GetOrAddHolidaysForCurrency(currencyId, holidaysDictionary);
                            holidays.Add(holiday);
                        }
                    }
                }
            }

            return holidaysDictionary.ToDictionary(pair => pair.Key, pair => pair.Value.ToArray());
        }

        private List<Holiday> GetOrAddHolidaysForCurrency(int currencyId, Dictionary<int, List<Holiday>> holidaysDictionary)
        {
            if (holidaysDictionary.ContainsKey(currencyId))
                return holidaysDictionary[currencyId];

            var holidays = new List<Holiday>();
            holidaysDictionary.Add(currencyId, holidays);

            return holidays;
        }
    }
}
