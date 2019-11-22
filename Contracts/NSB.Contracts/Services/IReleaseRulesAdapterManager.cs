using System.Collections.Generic;
using System.ServiceModel;

namespace NSB.Contracts.Services
{
    [ServiceContract(Namespace = "http://schema.business.test.com/contracts/")]
    public interface IReleaseRulesAdapterManager
    {
        [OperationContract]
        int GetNostroBankAccountChannelByOpsEssId(int cctOpsESSAccountId);

        [OperationContract]
        Dictionary<int, int> GetAllNostroBankAccountChannelsMapping();
    }
}