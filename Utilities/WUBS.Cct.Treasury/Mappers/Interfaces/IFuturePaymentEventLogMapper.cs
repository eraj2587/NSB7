using WUBS.Cct.Treasury.DomainModel.Entities;

namespace WUBS.Cct.Treasury.Mappers.Interfaces
{
    public interface IFuturePaymentEventLogMapper
    {
        FuturePaymentEventLog GetNextUnprocessed();
        void Update(FuturePaymentEventLog eventLog);

        FuturePaymentEventLog GetByLineItemId(int lineItemId);
    }
}
