using System.ComponentModel;
using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts
{
    [DataContract]
    public enum OutgoingPaymentStatus : byte
    {
        //API-2132: Edge Condition
        [EnumMember]
        [Description("None")]
        None = 0,
        [EnumMember]
        [Description("Created")]
        Created = 1,
        [EnumMember]
        [Description("Available For Release")]
        Fulfilled = 2,
        [EnumMember]
        [Description("Repurchased/Deleted")]
        Cancelled = 3,
        [EnumMember]
        [Description("Issued")]
        Issued = 4,
        [EnumMember]
        [Description("Released")]
        Reconciled = 5,
        [EnumMember]
        [Description("Release In Process")]
        ReleaseInProcess = 6
    }

    [DataContract]
    public enum IncomingPaymentStatus : byte
    {
        [EnumMember]
        Created = 1,
        [EnumMember]
        Cancelled = 2,
        [EnumMember]
        Received = 3,
        [EnumMember]
        WritenOff = 4,
        [EnumMember]
        Offset = 5,
        [EnumMember]
        Rejected = 6,
        [EnumMember]
        Deposited = 7,
        [EnumMember]
        Submitted = 8,
        [EnumMember]
        Reconciled = 9
    }

    [DataContract]
    public enum SpotPaymentStatus
    {
        [EnumMember]
        PaymentBooked = 1,
        [EnumMember]
        AwaitingFunds = 2,
        [EnumMember]
        FundsReceived = 3,
        [EnumMember]
        FundsClearing = 4,
        [EnumMember]
        FundsCleared = 5,
        [EnumMember]
        PaymentSent = 6,
        [EnumMember]
        Cancelled = 7,
        [EnumMember]
        PaymentReturned = 8
    }

    [DataContract]
    public enum PaymentInstructionsStatus : byte
    {
        [EnumMember]
        None = 0,
        [EnumMember]
        Created = 1,
        [EnumMember]
        Fulfilled = 2,
        [EnumMember]
        InProcess = 3,
        [EnumMember]
        Released = 4,
        [Description("Validation Failed")]
        [EnumMember]
        ValidationFailed = 5,
        [EnumMember]
        Disposed = 6,
        [EnumMember]
        ReleaseFailed = 7,
        [EnumMember]
        AchievableValueDateMissed = 8,
        [Description("Released without instructions")]
        [EnumMember]
        GatewayNotSupported = 9

    }
}
