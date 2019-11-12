using System.Collections.Generic;
using WUBS.Cct.Treasury.DomainModel.Enums;

namespace WUBS.Cct.Treasury.Infrastructure.Caches.Mappers.Interfaces
{
    public interface IItemTypeMapper
    {
        Dictionary<int, string> GetItemTypesByOrderType(OrderType orderType);
    }
}
