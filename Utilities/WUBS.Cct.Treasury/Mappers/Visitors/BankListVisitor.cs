using System.Collections.Generic;
using System.Linq;
using WUBS.Cct.Treasury.DomainModel.Entities;
using WUBS.Cct.Treasury.DomainModel.Enums;
using WUBS.Cct.Treasury.Mappers.Interfaces;

namespace WUBS.Cct.Treasury.Mappers.Visitors
{
    public class BankListVisitor : OrderVisitor
    {
        private readonly IBankAccountMapper bankAccountMapper;

        private readonly HashSet<OrderType> sweepOrders = new HashSet<OrderType>
        {
            OrderType.FtSweep,
            OrderType.FtSweepReversal
        };

        public BankListVisitor()
        {
            this.bankAccountMapper = new BankAccountMapper();
        }

        public BankListVisitor(IBankAccountMapper bankAccountMapper)
        {
            this.bankAccountMapper = bankAccountMapper;
        }

        public override void Visit(Order order)
        {
            if (!sweepOrders.Contains(order.OrderType)) return;

            foreach (var singleSided in order.LineItems.OfType<SingleSidedLineItem>())
            {
                singleSided.BankListCode = bankAccountMapper.GetBankListCodeByToAccountId(singleSided.BeneficiaryId);
            }
        }
    }
}
