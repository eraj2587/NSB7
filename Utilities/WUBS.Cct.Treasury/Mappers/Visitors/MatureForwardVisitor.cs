using System;
using WUBS.Cct.Treasury.DomainModel.Entities;
using WUBS.Cct.Treasury.DomainModel.Enums;
using WUBS.Cct.Treasury.DomainModel.Financial;

namespace WUBS.Cct.Treasury.Mappers.Visitors
{
    public class MatureForwardVisitor : OrderVisitor
    {
        public override void Visit(Order order)
        {
            if (order.OrderType == OrderType.MatureForward)
            {
                order.LineItems.ForEach(SetSettlementAmount);
            }
        }

        private void SetSettlementAmount(LineItem lineItem)
        {
            if (lineItem.SettlementMoney.Amount == 0)
            {
                var clientRate = lineItem.FundingSource.ClientRateComponent.ClientRate;
                if (clientRate == 0)
                    throw new InvalidOperationException(string.Format("Cannot set settlement amount when client rate is 0. Line item: {0}", lineItem.Id));

                    var amount = clientRate.IsDirect()
                    ? lineItem.TradeMoney.Amount * clientRate
                    : lineItem.TradeMoney.Amount / clientRate;

                lineItem.SettlementMoney = new Money(lineItem.SettlementMoney.Currency,
                    Math.Round(amount, lineItem.SettlementMoney.Currency.NumberOfDecimals));

            }
        }
    }
}
