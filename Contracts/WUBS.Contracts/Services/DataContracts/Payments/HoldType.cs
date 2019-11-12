using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts
{
    //Mapped to HoldType table in Payment DB
    public enum HoldType : byte
    {
        [EnumMember]
        None = 0,
        [EnumMember]
        ValueDateReviewHold = 1,
        [EnumMember]
        HoldOFAC = 2,
        [EnumMember]
        HoldOther = 3,
        [EnumMember]
        HoldThreshholdBreach = 4
    }

    public enum HoldStatus : byte
    {
        [EnumMember]
        InActive = 0,
        [EnumMember]
        Active = 1,

    }
    //OfacProcessingStatus: (Need to fetch list from Fircosoft)
    public enum OfacProcessingStatus
    {
        None = 0,
        Escalated = 949,
        FalsePositive = 950,
        Ready = 951,
        Suspect = 952,
        ConfirmHit = 953,
        Complete = 954,
        Exception = 955,
        Split = 956,
        Rescan = 975,
        Reattach = 976,
        InProcess = 978,
        CancelledOrder = 979,
        ComplianceBlocked = 1203,
        ComplianceCancel = 1202,
        ComplianceHold = 1201
    }
}
