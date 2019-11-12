using WUBS.Cct.Treasury.DomainModel.Entities;
using WUBS.Cct.Treasury.DomainModel.FundingSource;
using WUBS.Cct.Treasury.DomainModel.Trading;

namespace WUBS.Cct.Treasury.Mappers.Factories
{
    public class FundingSourceFactoryHelper
    {
        internal static LineItemFundingSource CreateFxFundingSource(int quoteId, ClientRateComponent clientRateComponent)
        {
            return new FxFundingSource
            {
                QuoteId = quoteId,
                ClientRateComponent = clientRateComponent
            };
        }
        
        internal static PredeliveryFundingSource CreatePredeliveryFundingSource(int quoteId, Order forwardOrderWithContributingLineItem, ClientRateComponent clientRateComponent)
        {
            return new PredeliveryFundingSource
            {
                QuoteId = quoteId,
                ForwardOrderWithContributingLineItem = forwardOrderWithContributingLineItem,
                ClientRateComponent = clientRateComponent
            };
        }

        internal static ForwardContractFundingSource CreateForwardContractFundingSource(int quoteId, Order forwardOrderWithContributingLineItem, ClientRateComponent clientRateComponent)
        {
            return new ForwardContractFundingSource
            {
                QuoteId = quoteId,
                ForwardOrderWithContributingLineItem = forwardOrderWithContributingLineItem,
                ClientRateComponent = clientRateComponent
            };
        }

        internal static ClientRateComponent CreateClientRateComponent(LineItemQuote lineItemQuote)
        {
            return new ClientRateComponent
            {
                ClientRate = lineItemQuote.ClientRate,
                CostRateComponent = new CostRateComponent
                {
                    SpotRate = lineItemQuote.SpotRate,
                    ForwardPoints = lineItemQuote.ForwardPoints
                }
            };
        }
    }
}
