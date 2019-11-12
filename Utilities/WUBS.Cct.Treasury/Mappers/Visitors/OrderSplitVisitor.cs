using WUBS.Cct.Treasury.DomainModel.Entities;
using WUBS.Cct.Treasury.Mappers.Interfaces;

namespace WUBS.Cct.Treasury.Mappers.Visitors
{
    internal class OrderSplitVisitor : OrderVisitor
    {
        private readonly IVmsEventLogMapper vmsEventLogMapper;
        private readonly IOrderMapper orderMapper;

        public OrderSplitVisitor(IOrderMapper orderMapper)
        {
            this.vmsEventLogMapper = new VmsEventLogMapper();
            this.orderMapper = orderMapper;
        }

        public OrderSplitVisitor(IOrderMapper orderMapper, IVmsEventLogMapper vmsEventLogMapper)
        {
            this.vmsEventLogMapper = vmsEventLogMapper;
            this.orderMapper = orderMapper;
        }

        public override void Visit(Order order)
        {
            var originalOrderId = vmsEventLogMapper.GetOrderIdByNewOrderId(order.Id);
            if (originalOrderId > 0)
            {
                var originalOrder = orderMapper.GetOrder(originalOrderId);
                if (originalOrder != null && originalOrder.ConfirmationNumber != null)
                    order.SplitOriginalConfirmationNo = originalOrder.ConfirmationNumber;
            }
        }
    }
}