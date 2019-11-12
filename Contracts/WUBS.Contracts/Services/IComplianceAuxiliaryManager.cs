using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using WUBS.Contracts.Common.Monads;
using WUBS.Contracts.Services.DataContracts.ComplianceContracts;

namespace WUBS.Contracts.Services
{
    [ServiceContract(Namespace = "http://schema.business.westernunion.com/contracts/")]
    public interface IComplianceAuxiliaryManager
    {
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void ResourceScan(ResourceScanRequest request);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        Validated<UpdateProcessForRescanResponse> UpdateProcessForRescan(UpdateProcessForRescanRequest request);
    }

    [DataContract]
    public class ResourceScanRequest
    {
        [DataMember]
        public int OrderId { get; set; }
    }

    [DataContract]
    public class UpdateProcessForRescanRequest
    {
        [DataMember]
        public List<long> EntityIds { get; set; }

        [DataMember]
        public ProcessForRescan RescanStatus { get; set; }
    }

    [DataContract]
    public class UpdateProcessForRescanResponse
    {
        [DataMember]
        public List<long> EntityIds { get; set; }

        [DataMember]
        public ProcessForRescan RescanStatus { get; set; }

        [DataMember]
        public string Status { get; set; }
    }
}
