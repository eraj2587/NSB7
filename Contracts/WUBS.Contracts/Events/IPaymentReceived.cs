using System;

namespace WUBS.Contracts.Events
{
    [Endpoint("WUBS.Adaptor.CCTPayment.Inbound")]
    public interface IPaymentReceived
    {
        int OpsLogId { get; set; }
        int CctStatusId { get; set; }
        int OrderDetailId { get; set; }
        bool IsHold { get; set; }
        string HoldReason { get; set; }
        //PYT- 3592
        DateTime? CreatedDateTime { get; set; }
        bool IsAutoRelease { get; set; }
        int ClientOrderId { get; set; }
    }
}
