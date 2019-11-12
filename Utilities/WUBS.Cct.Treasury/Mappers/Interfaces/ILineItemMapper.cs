using System.Collections.Generic;
using WUBS.Cct.Treasury.DomainModel.Entities;

namespace WUBS.Cct.Treasury.Mappers.Interfaces
{
    public interface ILineItemMapper
    {
        IList<LineItem> GetLineItemsByOrder(Order order);
        LineItem GetLineItemByItemId(int itemId);
        IList<LineItem> GetLineItemsByItemIds(IList<int> itemIds);
        int GetQuoteIdByRelatedItemId(int relatedLineItemId);
    }
}