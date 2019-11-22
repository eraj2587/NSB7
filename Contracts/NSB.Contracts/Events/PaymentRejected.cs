namespace NSB.Contracts.Events
{

    [Endpoint("NSB.Gateways.GPG")]
    public interface IPaymentRejected
    { 
      long PaymentBatchDetailId { get; set; }
      string AdditionalInfo { get; set; }
    }
}
