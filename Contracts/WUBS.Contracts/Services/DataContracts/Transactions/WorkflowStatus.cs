using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts.Transactions
{
    [DataContract]
    public enum WorkflowStatus
    {
        [EnumMember]
        Undefined,

        //pre-IT statuses
        [EnumMember]
        PendingVerification,

        [EnumMember]
        HeldInVMS,

        [EnumMember]
        PendingSanctionsReview,

        [EnumMember]
        HeldInOFAC,

        [EnumMember]
        InvoiceOrConfirmationSent,

        //post-IT statuses
        [EnumMember]
        SettlementRequestInitiated,

        [EnumMember]
        SettlementReceived,
        
        [EnumMember]
        SettlementNotPaid,

        [EnumMember]
        SettlementPartiallyPaid,

        [EnumMember]
        AvailableForRelease,

        [EnumMember]
        Released,

        [EnumMember]
        Held,

        [EnumMember]
        Cleared

    }
}