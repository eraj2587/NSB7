using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts
{
    [DataContract]
    public enum Platform
    {
        [EnumMember]
        None = 0,
        [EnumMember]
        Spot = 1,
        [EnumMember]
        Cct = 2,
        [EnumMember]
        Fk = 3,
        [EnumMember]
        Trancentrix = 4,
        [EnumMember]
        Wubs2 = 5,
        [EnumMember]
        Bidvest = 6
    }
}