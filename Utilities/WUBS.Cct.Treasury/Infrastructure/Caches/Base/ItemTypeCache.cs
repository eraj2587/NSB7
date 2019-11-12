using System.Collections.Generic;
using WUBS.Cct.Treasury.DomainModel.Enums;
using WUBS.Cct.Treasury.Infrastructure.Caches.Mappers;

namespace WUBS.Cct.Treasury.Infrastructure.Caches.Base
{
    public abstract class ItemTypeCache<TValueType, TCacheType> : Cache<TValueType, TCacheType>
        where TCacheType : ItemTypeCache<TValueType, TCacheType>, new()
    {
        protected abstract OrderType OrderType { get; }

        protected override Dictionary<int, string> GetCodeMapping()
        {
            return ItemTypeMapper.Instance.GetItemTypesByOrderType(OrderType);
        }
    }
}
