using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts.PaymentInstruction
{
    [DataContract]
    public class ReleasePaymentResult
    {
        [DataMember]
        public long PaymentBatchId { get; set; }
        [DataMember]
        public bool IsValid { get; set; }
        [DataMember]
        public string ResponseMessage { get; set; }
        [DataMember]
        public bool IsReleaseViaRbfi { get; set; }
        [DataMember]
        public bool IsSendSuccessful { get; set; }
    }
}