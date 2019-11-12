using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts.Enums
{
    [DataContract]
    public enum PaymentReleaseType
    {
        [EnumMember]
        RBFI = 4010,
        [EnumMember]
        WUBS2 = 4011
    }
}