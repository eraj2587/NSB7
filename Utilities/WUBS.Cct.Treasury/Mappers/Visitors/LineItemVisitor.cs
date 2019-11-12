using WUBS.Cct.Treasury.DomainModel.Entities;

namespace WUBS.Cct.Treasury.Mappers.Visitors
{
    public abstract class LineItemVisitor : IVisitor<LineItem>
    {
        public abstract void Visit(LineItem element);
       

        public virtual void Visit(LineItem element, int depth)
        {
            
        }
    }
}
