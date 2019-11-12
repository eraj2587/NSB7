using System.Collections.Generic;
using WUBS.Cct.Treasury.DomainModel.Financial;
using WUBS.Cct.Treasury.Exceptions;
using WUBS.Cct.Treasury.Infrastructure.Caches.Mappers;

namespace WUBS.Cct.Treasury.Infrastructure.Caches
{
    public class CurrencyCache : Cache<Currency, CurrencyCache>
    {
        protected override Dictionary<int, Currency> LoadCacheDictionary()
        {
            return CurrencyCacheMapper.Instance.GetAllCurrenciesDictionary();
        }

        protected override string CacheName
        {
            get { return "Currency"; }
        }

        protected override Dictionary<int, string> GetCodeMapping()
        {
            return null;
        }

        public Currency GetByCurrencyCode(string currencyCode)
        {
            if (!string.IsNullOrEmpty(currencyCode))
            {
                foreach (var pair in CacheDictionary)
                {
                    if (pair.Value.Code == currencyCode.Trim().ToUpper())
                        return pair.Value;
                }
            }
            throw new InvalidCurrencyException();
        }

        public int GetIdByCode(string currencyCode)
        {
            if (!string.IsNullOrEmpty(currencyCode))
            {
                foreach (var pair in CacheDictionary)
                {
                    if (pair.Value.Code == currencyCode.Trim().ToUpper())
                        return pair.Key;
                }
            }

            throw new InvalidCurrencyException();
        }
    }
}
