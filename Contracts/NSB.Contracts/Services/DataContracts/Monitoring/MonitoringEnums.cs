using System.ComponentModel;
using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts.Monitoring
{
    public enum MonitoringEntityType:byte
    {
        Payment=1
    }
    /// <summary>
    /// Whenever a new Enum member is added over here, ensure to add the same in PaymentMonitoringEvent file in MonitoringService.sln
    /// </summary>
    public enum PaymentMonitoringEvent
    {
        [EnumMember]
        None = 0,
        [Description("Payment Failed To AutoRelease")]
        [EnumMember]
        PaymentFailedToAutoRelease = 1,
        [EnumMember]
        PaymentFileForGPGFailedToCreate = 2,
        [EnumMember]
        PaymentFileFailedToSend = 3,
        [EnumMember]
        PaymentFileFailedToReceivedByGPG = 4,
        [EnumMember]
        PaymentFileFailedToConfirmAutomatically = 5,
        [EnumMember]
        PaymentThresholdBreachedEvent = 11,
        [EnumMember]
        PaymentOnHoldEvent = 12,
        [EnumMember]
        [Description("Auto Case Opened")]
        AutoCaseOpenedInvalidPayment = 20,
        [Description("Auto Case Opened")]
        [EnumMember]
        AutoCaseOpenedRejectedPayment = 21,
        [EnumMember]
        [Description("Manual Case Opened")]
        ManualCaseOpenedAfr = 22,
        [Description("Manual Case Opened")]
        [EnumMember]
        ManualCaseOpenedReleased = 23,
        [Description("Payment Accepted")]
        [EnumMember]
        PaymentAccepted = 24,
        [Description("Payment File Recieved by GPG")]
        [EnumMember]
        PaymentFileRecievedByGpg = 25,
        [EnumMember]
        [Description("Payment became Available for Release")]
        PaymentAvailableFoRelease = 26,
        [Description("Payment Rejected")]
        [EnumMember]
        PaymentRejected = 27
        //[Description("Manual Hold Placed")]
        //[EnumMember]
        //ManualHoldOtherApplied = 26

    }
}
