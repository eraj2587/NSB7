using WUBS.Contracts.Events;

namespace WUBS.Contracts.Commands
{
    [Endpoint("WUBS.Gateways.SalesForce")]
    public class RejectOutgoingPaymentCommand
    {

        public long PaymentBatchDetailId { get; set; }
        public string ErrorCode { get; set; }
        public string AdditionalInfo { get; set; }
        public string Status { get; set; }
    }
}
