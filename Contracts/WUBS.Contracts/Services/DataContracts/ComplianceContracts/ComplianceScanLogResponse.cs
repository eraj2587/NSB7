using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts.ComplianceContracts
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
