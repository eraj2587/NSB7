using System.ComponentModel;
using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts.Enums
{
    [DataContract]
    public enum PainFileFormat
    {
        [Description("None")]
        [EnumMember]
        None = 0,
        [Description("pain.001")]
        [EnumMember]
        IsoPain001 = 1,
        [EnumMember]
        [Description("pain.008")]
        IsoPain008 = 2,
        [EnumMember]
        [Description("MT110")]
        Mt110 = 3,
        [EnumMember]
        Recon = 4
    }

    [DataContract]
    public enum ReconPaymentType
    {
        [EnumMember]
        Credit = 3164,
        [EnumMember]
        Debit = 3165
    }

    [DataContract]
    public enum BatchType
    {
        [EnumMember]
        FileBatch = 1772,
        [EnumMember]
        TimeBatch = 1773,
        [EnumMember]
        NoBatching = 1774,
        [EnumMember]
        BatchByBatch = 2874,
        [EnumMember]
        BatchByGpg = 3155
    }

    [DataContract]
    public enum ReconBatchHeaderStatus
    {
        [EnumMember]
        NewBatchHeader = 830,
        [EnumMember]
        BatchHeaderExported = 831,
        [EnumMember]
        BatchHeaderPosted = 832
    }

    [DataContract]
    public enum Users
    {
        [EnumMember]
        SysAdmin = 58
    }
}