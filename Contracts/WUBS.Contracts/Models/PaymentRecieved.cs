using System;

namespace WUBS.Contracts.Models
{
    public class PaymentRecieved
    {
        public int OpsEssId { get; set; }
        public int CctStatusId { get; set; }
        public bool IsIncoming { get; set; }
        public int OrderDetailId { get; set; }
        public bool IsPaymentOnHold { get; set; }
        public string HoldReason { get; set; }
        public string PaymentId { get; set; }
        public bool IsAutoRelease { get; set; }

        public DateTime CreatedDateTime { get; set; }
        public int ClientOrderId { get; set; } 
    }
}
