namespace WUBS.Contracts.Events
{
    [Endpoint("WUBS.Gateways.GPG")]
   public interface IUpdateUETRToCct
    {
         string SwiftUETR { get; set; }
         long PaymentBatchDetailId { get;set;}        
         bool IsWubs2Payment { get; set; }
    }
}
