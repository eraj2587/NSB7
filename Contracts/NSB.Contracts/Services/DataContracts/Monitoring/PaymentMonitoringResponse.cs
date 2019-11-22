using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts.Monitoring
{
    /// <summary>
    /// If there are any changes in the data contract, ensure to add the same in MonitoringService.sln
    /// </summary>
    [DataContract]
    public class PaymentMonitoringResponse
    {
        [DataMember]
        public int PaymentId { get; set; }
        [DataMember]
        public string EventDescription { get; set; }
        [DataMember]
        public PaymentMonitoringAdditionalInfo AdditionalInformation { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
        [DataMember]
        public DateTime CreatedDate { get; set; }
    }

    [DataContract]
    public class PaymentsMonitoringResponse
    {
        [DataMember]
        public List<PaymentMonitoringResponse> PaymentsMonitoring { get; set; }
    }
}
