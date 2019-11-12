using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using WUBS.Contracts.Common.Monads;
using WUBS.Contracts.Services.DataContracts.ComplianceContracts;

namespace WUBS.Contracts.Services
{
    [ServiceContract(Namespace = "http://schema.business.westernunion.com/contracts/")]
    public interface IComplianceManager
    {
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        Validated<ResourceScanStatusUpdateResponse> ResourceScanStatusUpdate(ResourceScanStatusUpdateRequest request);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void LogResourceScanStatusUpdate(LogResourceScanStatusUpdateRequest request);
    }

    [DataContract]
    public class LogResourceScanStatusUpdateRequest
    {
        [DataMember]
        public long? MessageId { get; set; }

        [DataMember]
        public string ApiRequest { get; set; }

        [DataMember]
        public string ApiResponse { get; set; }
    }

    [DataContract]
    public class ResourceScanStatusUpdateRequest
    {
        [DataMember]
        public long MessageId { get; set; }

        [DataMember]
        public EntityType EntityType { get; set; }

        [DataMember]
        public ScanStatus ScanStatus { get; set; }

        [DataMember]
        public Reason Reason { get; set; }

        [DataMember]
        public DateTime? Validity { get; set; }
    }

    [DataContract]
    public class ResourceScanStatusUpdateResponse
    {
        [DataMember]
        public long MessageId { get; set; }

        [DataMember]
        public ComplianceScanStatus ScanStatus { get; set; }
    }
}
