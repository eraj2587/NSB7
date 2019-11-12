using System;
using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts.ComplianceContracts
{
    [DataContract]
    public class ComplianceScanLog
    {
        [DataMember]
        public long ComplianceScanLogId { get; set; }
        [DataMember]
        public long MessageId { get; set; }
        [DataMember]
        public long Identifier { get; set; }
        [DataMember]
        public EntityType EntityType { get; set; }
        [DataMember]
        public Source Source { get; set; }
        [DataMember]
        public DateTimeOffset TimeStamp { get; set; }
        [DataMember]
        public string Request { get; set; }
        [DataMember]
        public string Response { get; set; }
        [DataMember]
        public DateTimeOffset? RequestDate { get; set; }
        [DataMember]
        public DateTimeOffset? ResponseDate { get; set; }
        [DataMember]
        public ComplianceScanStatus ScanStatus { get; set; }
    }
}
