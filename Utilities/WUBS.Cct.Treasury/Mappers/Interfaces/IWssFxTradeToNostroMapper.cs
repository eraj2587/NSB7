using WUBS.Cct.Treasury.DomainModel.VendorDeals;

namespace WUBS.Cct.Treasury.Mappers.Interfaces
{
    public interface IWssFxTradeToNostroMapper
    {
        WssFxTrade Save(WssFxTrade deal);
    }
}
