namespace WUBS.Cct.Treasury.Mappers.Interfaces
{
    public interface IOrderLogMapper
    {
        bool IsInLog(int orderId);
        void Add(int orderId);
    }
}