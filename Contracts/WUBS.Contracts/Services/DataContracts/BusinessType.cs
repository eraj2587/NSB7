using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts
{
    public enum BusinessType
    {
        [EnumMember]
        None,

        [EnumMember]
        Corporation,

        [EnumMember]
        Partnership
    }
}