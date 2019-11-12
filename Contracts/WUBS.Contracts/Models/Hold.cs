using System;

namespace WUBS.Contracts.Models
{
    public class Hold
    {
        public long PaymentId { get; set; }
        public byte? HoldType { get; set; }
        public string Reason { get; set; }
        public byte Status { get; set; }
        public string LastUpdatedBy { get; set; }
        public string HoldReasonAnother { get; set; }
        public string ReleaseHoldReason { get; set; }
        public DateTime LastUpdatedAt { get; set; }
    }
}
