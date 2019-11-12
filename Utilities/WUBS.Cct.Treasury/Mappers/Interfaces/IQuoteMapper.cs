using WUBS.Cct.Treasury.DomainModel.Entities;
using WUBS.Cct.Treasury.DomainModel.Enums;
using WUBS.Cct.Treasury.DomainModel.Financial;
using WUBS.Cct.Treasury.DomainModel.Trading;

namespace WUBS.Cct.Treasury.Mappers.Interfaces
{
    public interface IQuoteMapper
    {
        LineItemQuote GetLineItemQuote(int lineItemQuoteId);
        
        LineItemQuote GetRepurchaseLineItemQuote(decimal itemRate, ClientRateComponent relatedClientRateComponent);
        int GetLatestRateRunId();
        Rate GetMidRate(Currency targetCurrency, Currency refCurrency, int rateRunId, TradeDirection tradeDirection);
    }
}