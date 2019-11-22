using NSB.Contracts.Events;

namespace NSB.Contracts.Commands
{
    [Endpoint("NSB.Gateways.SalesForce")]
    public class InvalidOutgoingPaymentCommand
    {
        public string PaymentId { get; set; }
    }
   
}