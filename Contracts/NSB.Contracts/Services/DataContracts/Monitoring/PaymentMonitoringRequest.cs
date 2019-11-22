using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts.Monitoring
{
    [DataContract]
    public class PaymentMonitoringRequest
    {
        [DataMember]
        public int PaymentId { get; set; }
    }
}
