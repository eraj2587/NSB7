using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts.Monitoring
{
    [DataContract]
    public class PaymentMonitoringAdditionalInfo
    {
        [DataMember]
        public string SfCaseNumber { get; set; }
        [DataMember]
        public string HoldReason { get; set; }
        [DataMember]
        public long? PaymentBatchId { get; set; }
        [DataMember]
        public long? PaymentBatchDetailsId { get; set; }
        [DataMember]
        public string PaymentWarning { get; set; }
    }
}
