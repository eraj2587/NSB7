namespace WUBS.Contracts.Events
{

    [Endpoint("WUBS.Gateways.GPG")]
    public interface IPaymentAccepted
    {
        long PaymentBatchDetailId { get; set; }
        
    }
}
