using NSB.Contracts.Events;

namespace NSB.Contracts.Commands
{
    [Endpoint("NSB.Gateways.SalesForce")]
    public class RejectOutgoingPaymentCommand
    {

        public long PaymentBatchDetailId { get; set; }
        public string ErrorCode { get; set; }
        public string AdditionalInfo { get; set; }
        public string Status { get; set; }
    }
}
