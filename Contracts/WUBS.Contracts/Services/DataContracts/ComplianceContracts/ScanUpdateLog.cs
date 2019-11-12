using System;
using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts.ComplianceContracts
{
    [DataContract]
    public class ScanUpdateLog
    {
        [DataMember]
        public long ScanUpdateLogId { get; set; }
        [DataMember]
        public long? ScanLogId { get; set; }
        [DataMember]
        public DateTimeOffset TimeStamp { get; set; }
        [DataMember]
        public ComplianceProcessingStatus ProcessingStatus { get; set; }
        [DataMember]
        public ComplianceScanStatus ScanStatus { get; set; }
        [DataMember]
        public long EntityId { get; set; }
    }
}
