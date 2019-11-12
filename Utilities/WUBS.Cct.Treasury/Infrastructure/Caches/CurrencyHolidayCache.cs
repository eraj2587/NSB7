using System;
using System.Collections.Generic;
using WUBS.Cct.Treasury.DomainModel.Financial;
using WUBS.Cct.Treasury.Exceptions;
using WUBS.Cct.Treasury.Infrastructure.Caches.Mappers;

namespace WUBS.Cct.Treasury.Infrastructure.Caches
{
    public class CurrencyHolidayCache : Cache<Holiday[], CurrencyHolidayCache>
    {
        protected override Dictionary<int, Holiday[]> LoadCacheDictionary()
        {
            return CurrencyHolidayCacheMapper.Instance.GetAllCurrencyHolidaysDictionary();
        }

        protected override string CacheName
        {
            get { return "CurrencyHoliday"; }
        }

        protected override Dictionary<int, string> GetCodeMapping()
        {
            return null;
        }

        public Holiday[] GetHolidaysByCurrencyCode(string currencyCode)
        {
            return GetHolidaysByCurrencyId(CurrencyCache.Instance.GetIdByCode(currencyCode));
        }

        public Holiday[] GetHolidaysByCurrencyId(int currencyId)
        {
            return CacheDictionary[currencyId];
        }

    }

    public class Holiday
    {
        public DateTime HolidayDate;
        public string Description;
        public int CountryId;
    }
}