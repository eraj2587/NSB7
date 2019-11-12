using WUBS.Cct.Treasury.DomainModel.Vms;

namespace WUBS.Cct.Treasury.Mappers.Interfaces
{
    public interface IVmsEventLogMapper
    {
        VmsEventLog GetNextUnprocessed();
        void Update(VmsEventLog eventLog);
        int GetOrderIdByNewOrderId(int newClientOrderId);
        bool HasVMSModified(int orderId);
    }
}