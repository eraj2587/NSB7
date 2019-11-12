using System.Collections.Generic;
using WUBS.Cct.Treasury.DomainModel.Entities;

namespace WUBS.Cct.Treasury.Infrastructure.Caches.Mappers.Interfaces
{
    public interface ICctOrderTypeCacheMapper
    {
        Dictionary<int, CctOrderType> GetAllCctOrderTypesDictionary();
        Dictionary<int, CctRepurchaseType> GetAllCctRepurchaseTypesDictionary();
    }
}
