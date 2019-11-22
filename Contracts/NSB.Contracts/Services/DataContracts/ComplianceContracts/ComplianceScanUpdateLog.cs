using System;
using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts.ComplianceContracts
{
    [DataContract]
    public class ComplianceScanUpdateLog
    {
        [DataMember]
        public long ComplianceScanUpdateLogId { get; set; }
        [DataMember]
        public long? MessageId { get; set; }
        [DataMember]
        public DateTimeOffset TimeStamp { get; set; }
        [DataMember]
        public string ApiRequest { get; set; }
        [DataMember]
        public string ApiResponse { get; set; }
    }
}
