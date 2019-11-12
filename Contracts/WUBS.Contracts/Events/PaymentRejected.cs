namespace WUBS.Contracts.Events
{

    [Endpoint("WUBS.Gateways.GPG")]
    public interface IPaymentRejected
    { 
      long PaymentBatchDetailId { get; set; }
      string AdditionalInfo { get; set; }
    }
}
