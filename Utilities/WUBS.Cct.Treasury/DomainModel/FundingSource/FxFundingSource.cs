using System;
using WUBS.Cct.Treasury.DomainModel.Enums;
using WUBS.Cct.Treasury.DomainModel.Financial;

namespace WUBS.Cct.Treasury.DomainModel.FundingSource
{
    [Serializable]
    public class FxFundingSource : LineItemFundingSource, IRateProvider, IClientRateComponentProvider
    {
        public override LineItemFundingMethod FundingMethod
        {
            get { return LineItemFundingMethod.Ruesch; }
        }

        public override int QuoteId { get; set; }
        
        public Rate ClientRate
        {
            get { return ClientRateComponent != null ? ClientRateComponent.ClientRate : Rate.NullRate; }
        }
    }
}
