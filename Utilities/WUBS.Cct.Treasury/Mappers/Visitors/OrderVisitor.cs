using WUBS.Cct.Treasury.DomainModel.Entities;

namespace WUBS.Cct.Treasury.Mappers.Visitors
{
    public abstract class OrderVisitor : IVisitor<Order>
    {
        public abstract void Visit(Order order);
    }
}
