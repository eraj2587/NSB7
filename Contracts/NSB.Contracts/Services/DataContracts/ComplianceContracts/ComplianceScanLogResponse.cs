using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts.ComplianceContracts
{
    [DataContract]
    public abstract class ComplianceScanLogResponse
    {
        [DataMember]
        public long ComplianceScanLogId { get; set; }
    }

    [DataContract]
    public class ComplianceQueryResponse : ComplianceScanLogResponse
    {
        [DataMember]
        public string Request { get; set; }
    }
}
