using WUBS.Cct.Treasury.DomainModel.Entities;

namespace WUBS.Cct.Treasury.Mappers.Interfaces
{
    internal interface IOrderMapper
    {
        Order GetOrder(int orderId);
        Order GetOrderByLineItemId(int lineItemId);

        int GetRepurchaseOrderIdFromReissueOrderId(int reissueOrderId);
    }
}