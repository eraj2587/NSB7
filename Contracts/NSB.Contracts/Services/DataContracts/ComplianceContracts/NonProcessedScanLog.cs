using System;
using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts.ComplianceContracts
{
    [DataContract]
    public class NonProcessedScanLog
    {
        [DataMember]
        public long NonProcessedScanLogId { get; set; }
        [DataMember]
        public long? ScanLogId { get; set; }
        [DataMember]
        public long EntityId { get; set; }
        [DataMember]
        public EntityType EntityType { get; set; }
        [DataMember]
        public string Identifier { get; set; }
        [DataMember]
        public DateTimeOffset TimeStamp { get; set; }
        [DataMember]
        public string LogReason { get; set; }
        [DataMember]
        public int ProcessForScan { get; set; }
    }
}
