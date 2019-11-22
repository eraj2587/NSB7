using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts.Enums
{
    [DataContract]
    public enum PaymentReleaseType
    {
        [EnumMember]
        RBFI = 4010,
        [EnumMember]
        NSB2 = 4011
    }
}