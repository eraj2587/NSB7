using WUBS.Cct.Treasury.DomainModel.Trading;

namespace WUBS.Cct.Treasury.DomainModel.FundingSource
{
    public interface IClientRateComponentProvider
    {
        ClientRateComponent ClientRateComponent { get; }
    }
}
