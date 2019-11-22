using System.Runtime.Serialization;
using NSB.Contracts.Services.DataContracts.CurrencyContracts.Pricing;
using NSB.Contracts.Services.DataContracts.Orders;

namespace NSB.Contracts.Services.DataContracts.CurrencyContracts
{
    [DataContract]
    public class NullContract : Contract
    {
        public NullContract() : base(-1, new ContractPricingComponent() {RateDirection = RateDirection.Direct, TradeDirection = TradeDirection.NSBSell})
        {
            
        }

        public override void Book()
        {
            //do nothing;
        }

        public override void Amend(decimal newTradeAmount, decimal newSettlementAmount, bool isAmountInSettlementCcy)
        {
            //do nothing;
        }

        public override void Amend(ContractPricingComponent newPricingComponent)
        {
            //do nothing;
        }
    }
}
