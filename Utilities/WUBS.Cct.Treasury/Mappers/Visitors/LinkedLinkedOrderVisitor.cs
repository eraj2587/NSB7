using WUBS.Cct.Treasury.DomainModel.Entities;
using WUBS.Cct.Treasury.Mappers.Visitors;

namespace WUBS.Cct.Treasury.Services
{
    internal class LinkedLinkedOrderVisitor : OrderVisitor
    {
        private readonly LinkedOrderVisitor linkedOrderVisitor;

        public LinkedLinkedOrderVisitor(LinkedOrderVisitor linkedOrderVisitor)
        {
            this.linkedOrderVisitor = linkedOrderVisitor;
        }

        public override void Visit(Order order)
        {
            var linkedOrder = order as LinkedOrder;
            if (null != linkedOrder)
            {
                var linkedLinkedOrder = linkedOrder.RelatedOrder as LinkedOrder;
                if (null != linkedLinkedOrder)
                {
                    linkedOrderVisitor.Visit(linkedLinkedOrder);
                }
            }
        }
    }
}