namespace NSB.Contracts.Events
{

    [Endpoint("NSB.Gateways.GPG")]
    public interface IPaymentAccepted
    {
        long PaymentBatchDetailId { get; set; }
        
    }
}
