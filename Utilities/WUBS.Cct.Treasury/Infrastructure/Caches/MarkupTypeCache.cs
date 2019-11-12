using WUBS.Cct.Treasury.DomainModel.Enums;
using WUBS.Cct.Treasury.Infrastructure.Caches.Base;

namespace WUBS.Cct.Treasury.Infrastructure.Caches
{
    public class MarkupTypeCache : PickListItemCache<MarkupType, MarkupTypeCache>
    {
        protected override string CacheName
        {
            get { return "Markup Type"; }
        }

        protected override PickListType PickListType
        {
            get { return PickListType.MarkupType; }
        }
    }
}