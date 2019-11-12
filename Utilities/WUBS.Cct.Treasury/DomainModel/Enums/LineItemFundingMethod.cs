using WUBS.Cct.Treasury.DomainModel.Enums.Utility;

namespace WUBS.Cct.Treasury.DomainModel.Enums
{
    public enum LineItemFundingMethod
    {
        [CctCode("Consign")]
        Holding,
        [CctCode("Drawdown")]
        Drawdown,
        [CctCode("FutFxTrade")]
        FutFxTrade,
        [CctCode("Forward")]
        Forward,
        [CctCode("Multiple")]
        Multiple,
        [CctCode("Ruesch")]
        Ruesch
    }
}
