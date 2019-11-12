using System;
using System.Linq;
using WUBS.Cct.Treasury.DomainModel.Entities;
using WUBS.Cct.Treasury.DomainModel.Enums;
using WUBS.Cct.Treasury.DomainModel.FundingSource;
using WUBS.Cct.Treasury.DomainModel.Trading;
using WUBS.Cct.Treasury.Exceptions;
using WUBS.Cct.Treasury.Mappers.Interfaces;

namespace WUBS.Cct.Treasury.Mappers.Factories
{
    public interface IFundingSourceFactory
    {
        LineItemFundingSource Create(LineItem lineItem);
    }

    public class FundingSourceFactory : IFundingSourceFactory
    {
        private readonly IQuoteMapper quoteMapper;
        public FundingSourceFactory(IQuoteMapper quoteMapper)
        {
            this.quoteMapper = quoteMapper;
        }

        public LineItemFundingSource Create(LineItem lineItem)
        {
            return CreateFundingSource(lineItem);
        }

        private LineItemFundingSource CreateFundingSource(LineItem lineItem)
        {
            if (lineItem.QuoteId == 0 && lineItem.LineItemFundingMethod != LineItemFundingMethod.Drawdown)
                return new NullLineItemFundingSource();

            switch (lineItem.LineItemFundingMethod)
            {
                case LineItemFundingMethod.Ruesch:
                    return CreateFxFundingSource(lineItem.QuoteId);
                case LineItemFundingMethod.Holding:
                    return CreateHoldingFundingSource(lineItem.QuoteId);
                case LineItemFundingMethod.Drawdown:
                    return new ReplacedByForwardContractFundingSourceVisitor();
                default:
                    throw new InvalidOperationException(string.Format("Line item {0} has unexpected funding method.", lineItem.Id));
            }
        }


        private LineItemFundingSource CreateFxFundingSource(int quoteId)
        {
            return new FxFundingSource
            {
                QuoteId = quoteId,
                ClientRateComponent = FundingSourceFactoryHelper.CreateClientRateComponent(quoteMapper.GetLineItemQuote(quoteId))
            };
        }

        private LineItemFundingSource CreateHoldingFundingSource(int quoteId)
        {
            return new HoldingFundingSource { QuoteId = quoteId };
        }
        
    }

    
}
