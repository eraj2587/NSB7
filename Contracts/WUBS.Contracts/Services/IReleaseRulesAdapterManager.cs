using System.Collections.Generic;
using System.ServiceModel;

namespace WUBS.Contracts.Services
{
    [ServiceContract(Namespace = "http://schema.business.westernunion.com/contracts/")]
    public interface IReleaseRulesAdapterManager
    {
        [OperationContract]
        int GetNostroBankAccountChannelByOpsEssId(int cctOpsESSAccountId);

        [OperationContract]
        Dictionary<int, int> GetAllNostroBankAccountChannelsMapping();
    }
}