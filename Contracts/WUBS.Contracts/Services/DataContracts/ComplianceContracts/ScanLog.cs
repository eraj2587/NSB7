using System;
using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts.ComplianceContracts
{
    [DataContract]
    public class ScanLog
    {
        [DataMember]
        public long ScanLogId { get; set; }
        [DataMember]
        public long EntityId { get; set; }
        [DataMember]
        public EntityType EntityType { get; set; }
        [DataMember]
        public RequestType RequestType { get; set; }
        [DataMember]
        public DateTimeOffset TimeStamp { get; set; }
    }
}
