using System.Collections.Generic;
using System.ServiceModel;

namespace WUBS.Contracts.Services
{
    [ServiceContract(Namespace = "http://schema.business.westernunion.com/contracts/")]
    public interface IPaymentReleaseRulesAdapter
    {
        [OperationContract]
        int GetNostroBankAccountByOpsEssId(int cctOpsESSAccountId);

        [OperationContract]
        Dictionary<int, int> GetAllNostroBankAccountsMapping();
    }
}