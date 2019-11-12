using System.Collections.Generic;
using WUBS.Cct.Treasury.DomainModel.Enums;
using WUBS.Cct.Treasury.Infrastructure.Caches.Mappers;

namespace WUBS.Cct.Treasury.Infrastructure.Caches.Base
{
    public abstract class PickListItemCache<TValueType, TCacheType> : Cache<TValueType, TCacheType>
        where TCacheType : PickListItemCache<TValueType, TCacheType>, new()
    {
        protected abstract PickListType PickListType { get; }

        protected override Dictionary<int, string> GetCodeMapping()
        {
            return PickListMapper.Instance.GetPickListItemsByPickListType(PickListType); 
        }
    }
}
