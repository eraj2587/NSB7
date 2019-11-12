using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts
{
    [DataContract]
    public enum FundingMethod
    {
        [EnumMember]
        None,
        [EnumMember]
        Drawdown,
        [EnumMember]
        FutFxTrade,
        [EnumMember]
        Forward,
        [EnumMember]
        Multiple,
        [EnumMember]
        Ruesch,
        [EnumMember]
        Holding = 81
    }
}
