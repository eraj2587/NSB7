namespace NSB.Contracts.Events
{
    [Endpoint("NSB.Gateways.GPG")]
   public interface IUpdateUETRToCct
    {
         string SwiftUETR { get; set; }
         long PaymentBatchDetailId { get;set;}        
         bool IsNSB2Payment { get; set; }
    }
}
