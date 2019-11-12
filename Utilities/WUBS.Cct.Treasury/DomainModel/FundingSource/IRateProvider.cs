using WUBS.Cct.Treasury.DomainModel.Financial;

namespace WUBS.Cct.Treasury.DomainModel.FundingSource
{
    public interface IRateProvider
    {
        Rate ClientRate { get; }

    }
}
