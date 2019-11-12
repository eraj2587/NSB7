using System.Collections.Generic;
using WUBS.Cct.Treasury.DomainModel.Financial;

namespace WUBS.Cct.Treasury.Infrastructure.Caches.Mappers.Interfaces
{
    public interface ICurrencyHolidayCacheMapper
    {
        Dictionary<int, Holiday[]> GetAllCurrencyHolidaysDictionary();
    }
}
