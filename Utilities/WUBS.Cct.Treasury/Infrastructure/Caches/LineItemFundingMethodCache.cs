using WUBS.Cct.Treasury.DomainModel.Enums;
using WUBS.Cct.Treasury.Infrastructure.Caches.Base;

namespace WUBS.Cct.Treasury.Infrastructure.Caches
{
    public class LineItemFundingMethodCache : PickListItemCache<LineItemFundingMethod, LineItemFundingMethodCache>
    {
        protected override string CacheName
        {
            get { return "Line Item Funding Method"; }
        }

        protected override PickListType PickListType
        {
            get { return PickListType.LineItemFundingMethod; }
        }
    }
}