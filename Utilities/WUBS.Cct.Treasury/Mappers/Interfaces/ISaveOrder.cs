using WUBS.Cct.Treasury.DomainModel.Entities;

namespace WUBS.Cct.Treasury.Mappers.Interfaces
{
    public interface ISaveOrder
    {
        void Save(Order order);
    }
}