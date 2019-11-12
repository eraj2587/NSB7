using System;
using System.Linq;
using WUBS.Cct.Treasury.DomainModel.Financial;
using WUBS.Cct.Treasury.Infrastructure.Caches;

namespace WUBS.Cct.Treasury.Services
{
    public interface IValueDateService
    {
        DateTime GetSpotDate(DateTime bookingDate, Currency ccy1, Currency ccy2);
        DateTime GetValueDateByAddingBusinessDays(DateTime startDate, Currency ccy1, Currency ccy2, int numberOfBusinessDays);
    }

    public class ValueDateService : IValueDateService
    {
        private readonly IValueDateServiceConfigurationProvider configuration;

        public ValueDateService(IValueDateServiceConfigurationProvider configuration)
        {
            this.configuration = configuration;
        }

        public DateTime GetSpotDate(DateTime bookingDate, Currency ccy1, Currency ccy2)
        {
            var spotRangeCcy1 = GetSpotRange(ccy1.Code);
            var spotRangeCcy2 = GetSpotRange(ccy2.Code);

            var spotDayRange = Math.Max(spotRangeCcy1, spotRangeCcy2);

            return GetValueDateByAddingBusinessDays(bookingDate, ccy1, ccy2, spotDayRange);
        }

        public DateTime GetValueDateByAddingBusinessDays(DateTime startDate, Currency ccy1, Currency ccy2, int numberOfBusinessDays)
        {
            var ccy1Holidays = CurrencyHolidayCache.Instance.GetHolidaysByCurrencyCode(ccy1.Code);
            var ccy2Holidays = CurrencyHolidayCache.Instance.GetHolidaysByCurrencyCode(ccy2.Code);

            for (int i = 0; i < numberOfBusinessDays; i++)
            {
                startDate = startDate.AddDays(1);
                while (IsOnWeekend(startDate) ||
                       IsHoliday(startDate, ccy1Holidays) ||
                       IsHoliday(startDate, ccy2Holidays))
                {
                    startDate = startDate.AddDays(1);
                }
            }

            return startDate;
        }

        private bool IsHoliday(DateTime bookingDate, Holiday[] currencyHolidays)
        {
            return currencyHolidays.Any(h => h.HolidayDate.Date == bookingDate.Date);
        }

        private bool IsOnWeekend(DateTime bookingDate)
        {
            if (bookingDate.DayOfWeek == DayOfWeek.Sunday || bookingDate.DayOfWeek == DayOfWeek.Saturday)
                return true;

            return false;
        }

        private int GetSpotRange(string currencyCode)
        {
            if (configuration.CurrencySpotDays.ContainsKey(currencyCode))
                return configuration.CurrencySpotDays[currencyCode];

            return 2;
        }
    }
}
