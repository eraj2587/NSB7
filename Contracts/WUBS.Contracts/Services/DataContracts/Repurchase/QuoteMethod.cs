using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts.Repurchase
{
    [DataContract(Namespace = "http://schemas.business.westernunion.com/2015/10/Opp")]
    public enum QuoteMethod
    {
        [EnumMember]
        MarketRate,

        [EnumMember]
        OriginalClientRate
    }
}