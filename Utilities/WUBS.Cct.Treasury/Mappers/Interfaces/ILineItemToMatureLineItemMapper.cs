using System;
using System.Collections.Generic;
using WUBS.Cct.Treasury.DomainModel.Entities;

namespace WUBS.Cct.Treasury.Mappers.Interfaces
{
    public interface ILineItemToMatureLineItemMapper
    {
        IList<LineItemToMatureLineItemMapping> GetLineItemMatureLineItemMappingsByMatureOrderId(int orderId);

        DateTime? GetAgingReleaseDateByItemId(int itemId);
    }
}
