using System;
using System.Linq;
using WUBS.Cct.Treasury.DomainModel.Entities;
using WUBS.Cct.Treasury.Mappers.Interfaces;
using WUBS.Cct.Treasury.Services;

namespace WUBS.Cct.Treasury.Mappers.Visitors
{
    internal class ReissueVisitor : OrderVisitor
    {
        private readonly IOrderMapper orderMapper;
        private readonly ICctTreasuryOrderService orderService;

        public ReissueVisitor(ICctTreasuryOrderService orderService, IOrderMapper orderMapper)
        {
            this.orderService = orderService;
            this.orderMapper = orderMapper;
        }

        public override void Visit(Order order)
        {
            var reissue = order as Reissue;

            if (reissue != null)
            {
                var repurchaseId = orderMapper.GetRepurchaseOrderIdFromReissueOrderId(reissue.Id);

                if (repurchaseId < 1)
                    throw new ArgumentException(string.Format("Unable to find repurchase for reissue order Id {0}", reissue.Id), "reissueOrder");

                reissue.Repurchase = orderService.GetOrder(repurchaseId);

                if (reissue.Repurchase == null)
                    throw new ArgumentException(string.Format("invalid repurchase order id {0}", repurchaseId), "repurchaseId");
            }
        }
    }
}
