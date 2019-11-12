using WUBS.Contracts.Events;

namespace WUBS.Contracts.Commands
{
    [Endpoint("WUBS.Gateways.SalesForce")]
    public class InvalidOutgoingPaymentCommand
    {
        public string PaymentId { get; set; }
    }
   
}