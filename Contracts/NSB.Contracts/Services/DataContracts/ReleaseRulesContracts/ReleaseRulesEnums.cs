using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts.ReleaseRulesContracts
{
    public enum ReleaseRulesDataType
    {
        BankHoliday,
        WindowsTimeZone,
        NostroBankAccount,
        NostroBankAccountChannel
    }

    [DataContract]
    public enum ChannelBusinessDays : byte
    {
        [EnumMember]
        Mon_Fri = 0,
        [EnumMember]
        Mon_Sat = 1,
        [EnumMember]
        Sun_Thu = 2,
        [EnumMember]
        Sun_Fri = 3,
        [EnumMember]
        Sun_Sun = 4
    }
}
