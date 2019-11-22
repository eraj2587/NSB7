using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts
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