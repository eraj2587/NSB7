using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace NSB.Contracts.Services
{
    [ServiceContract(Namespace = "http://schema.business.test.com/contracts/")]
    public interface IComplianceCctAdapterManager
    {
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        List<GenerateResourceScanResponse> GenerateResourceScan(GenerateResourceScanRequest request);
    }

    [DataContract]
    public class GenerateResourceScanRequest
    {
        [DataMember]
        public int[] LineItemIds { get; set; }
    }

    [DataContract]
    public class GenerateResourceScanResponse
    {
        [DataMember]
        public int LineItemId { get; set; }

        [DataMember]
        public string Message { get; set; }
    }
}
