using System.Collections.Generic;
using WUBS.Cct.Treasury.DomainModel.Enums;

namespace WUBS.Cct.Treasury.Infrastructure.Caches.Mappers.Interfaces
{
    public interface IPickListMapper
    {
        Dictionary<int, string> GetPickListItemsByPickListType(PickListType statusListType);
    }
}
