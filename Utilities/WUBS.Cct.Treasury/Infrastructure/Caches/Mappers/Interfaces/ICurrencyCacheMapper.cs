using System.Collections.Generic;
using WUBS.Cct.Treasury.DomainModel.Financial;

namespace WUBS.Cct.Treasury.Infrastructure.Caches.Mappers.Interfaces
{
    public interface ICurrencyCacheMapper
    {
        Dictionary<int, Currency> GetAllCurrenciesDictionary();
    }
}
